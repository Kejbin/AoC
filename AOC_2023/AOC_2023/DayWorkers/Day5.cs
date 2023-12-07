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
            long min = 0;
            if (data is List<long> seeds)
            {
                var pairs = new Queue<(long Start, long End)>();

                for (int i = 0; i < seeds.Count; i += 2)
                    pairs.Enqueue((seeds[i], seeds[i] + seeds[i + 1] - 1));

                foreach (var map in _map)
                {
                    var newRanges = new Queue<(long Start, long End)>();
                    while (pairs.Count > 0) {
                        
                        var pair = pairs.Dequeue();
                        bool requeue = true;
                        foreach (var range in map)
                        {
                            if (range.End < pair.Start || range.Start > pair.End)
                                continue;

                            requeue = false;

                            if (pair.Start < range.Start)
                                pairs.Enqueue(new(pair.Start, range.Start - 1)); //Right side without changes, add to same mapping section to check if that values are not overlapping other range

                            if (pair.End > range.End)
                                pairs.Enqueue(new(range.End + 1, pair.End)); //Left side without changes, add to same mapping section to check if that values are not overlapping other range

                            newRanges.Enqueue(new(Math.Max(pair.Start, range.Start) + range.Diff, Math.Min(pair.End, range.End) + range.Diff)); //Process overlapping
                        }

                        if(requeue)
                            newRanges.Enqueue(pair);
                    }
               
                    pairs = newRanges;
                }

                min = pairs.Select(pair => pair.Start).Min();
            }

            //Thank you programming guru P.L. for help 

            return $"Result Part 2: {min}";
        }
    }
}
