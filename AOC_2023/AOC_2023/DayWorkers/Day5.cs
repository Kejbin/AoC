using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day5 : IDay
    {
        private List<List<(long Diff, long Start, long End)>> _map = new();

        public string Execute(string data)
        {
            var input = data.Split("\r\n");
            var seeds = input[0].Split(' ')
                                .Skip(1)
                                .Select(c => Convert.ToInt64(c))
                                .ToList();

            _map = new List<List<(long Diff, long Start, long End)>>();
            var list = new List<(long Diff, long Start, long End)>();
            foreach (var item in input.Skip(2).Where(w => !string.IsNullOrEmpty(w)))
            {
                if (!Char.IsDigit(item[0]))
                {
                    list = new List<(long Diff, long Start, long End)>();
                    _map.Add(list);
                }
                if (Char.IsDigit(item[0]))
                {
                    var coords = item.Split(' ')
                                     .Select(s => Convert.ToInt64(s))
                                     .ToArray();
                    list.Add((coords[0] - coords[1], coords[1], coords[1] + coords[2]));
                }
            }

            return PartOne(seeds) + "\r\n" + PartTwo(seeds);
        }

        public string PartOne(object data)
        {
            long min = long.MaxValue;
            if (data is List<long> seeds)
            {
                foreach (var seed in seeds)
                {
                    var value = seed;
                    foreach (var m in _map)
                    {
                        foreach (var coords in m)
                            if (value >= coords.Start && value <= coords.End)
                            {
                                value = value + coords.Diff;
                                break;
                            }
                    }

                    if(min > value)
                        min = value;
                }
            }

            return $"Result Part 1: {min}";
        }

        public string PartTwo(object data)
        {
            long min = long.MaxValue;
            if (data is List<long> seeds)
            {
                var pairs = new List<(long Start, long End)>();

                for (int i = 0; i < seeds.Count; i += 2)
                    pairs.Add((seeds[i], seeds[i] + seeds[i + 1] - 1));

                foreach (var pair in pairs)
                {
                    for (long i = pair.Start, loopTo = pair.End; i <= loopTo; i++)
                    {
                        var value = i;
                        long skipCount = long.MaxValue;
                        foreach (var map in _map)
                        {
                            foreach (var range in map)
                            {
                                if (range.Start <= value && range.End >= value)
                                {
                                    skipCount = Math.Min(range.End - value, skipCount);
                                    value = value + range.Diff;
                                    break;
                                }
                            }
                        }

                        if (value > min && skipCount != long.MaxValue && skipCount > 0)
                            i += skipCount - 1;

                        if (min > value) min = value;
                    }
                }
            }

            return $"Result Part 2: {min}";
        }
    }
}
