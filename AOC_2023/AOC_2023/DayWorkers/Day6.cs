using System.Diagnostics;
using System.Linq;

namespace AOC_2023.DayWorkers
{
    internal class Day6 : IDay
    {
        private List<Mapping> _mapping = new() {
            new Mapping { Time = 1, Distance = 6 },
            new Mapping { Time = 2, Distance = 10 },
            new Mapping { Time = 3, Distance = 12 },
            new Mapping { Time = 4, Distance = 12 },
            new Mapping { Time = 5, Distance = 10 },
            new Mapping { Time = 6, Distance = 6 },
        };

        public string Execute(string data)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var input = data.Split("\r\n").Select(x => x.Split(':')
                                                        .Last()
                                                        .Split(' ')
                                                        .Where(w => !string.IsNullOrWhiteSpace(w))
                                                        .Select(s => Convert.ToInt16(s))
                                                        .ToArray())
                                          .Where(c => c.Count() > 0);

            var records = new List<Mapping>();

            for (int i = 0; i < input.First().Count(); i++)
                records.Add(new Mapping { Time = input.First()[i], Distance = input.Last()[i] });

            return PartOne(records) + "\r\n" + PartTwo(records) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        public string PartOne(object data)
        {
            int min = 1;

            if(data is List<Mapping> mapping)
            {
                foreach (var item in mapping)
                {
                    var table = new List<Mapping>();
                    for (int i = 1;  i < item.Time; i++)
                        table.Add(new Mapping { Time = i, Distance = i * (item.Time - i)});

                    int counter = 0;

                    for (int i = 0; i < table.Count; i++)
                        if (table[i].Distance > item.Distance)
                            counter++;

                    min *= counter;
                }
            }

            return $"Result Part 1: {min}";
        }

        public string PartTwo(object data)
        {
            int min = 0;

            if (data is List<Mapping> mapping)
            {
                var mergedMapping = new Mapping
                {
                    Distance = Convert.ToInt64(mapping.Select(s => s.Distance.ToString()).Aggregate((a, b) => $"{a}{b}")),
                    Time = Convert.ToInt64(mapping.Select(s => s.Time.ToString()).Aggregate((a, b) => $"{a}{b}"))
                };

                for (int i = 1; i < mergedMapping.Time; i++)
                    if(i * (mergedMapping.Time - i) > mergedMapping.Distance)
                        min++;
            }

            return $"Result Part 2: {min}";
        }

        private class Mapping {
            public long Time { get; set; }
            public long Distance { get; set; }
        }
        
    }
}
