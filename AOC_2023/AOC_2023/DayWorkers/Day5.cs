using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day5 : IDay
    {
        public string Execute(string data)
        {
            return PartOne(data) + "\r\n" + PartTwo(data);
        }

        public string PartOne(object data)
        {
            long min = 0;
            if (data is string str)
            {
                var input = str.Split("\r\n");
                var seeds = input[0].Split(' ').Skip(1).Select(c => Convert.ToInt64(c));
                var map = new List<List<(long Src, long Dest, long Range)>>();
                var list = new List<(long Src, long Dest, long Range)>();
                foreach (var item in input.Skip(2).Where(w => !string.IsNullOrEmpty(w)))
                {
                    if (!Char.IsDigit(item[0]))
                    {
                        list = new List<(long Src, long Dest, long Range)>(); ;
                        map.Add(list);
                    }
                    if (Char.IsDigit(item[0]))
                    {
                        var coords = item.Split(' ').Select(s => Convert.ToInt64(s)).ToArray();
                        list.Add((coords[0], coords[1], coords[2]));
                    }
                }

                var locations = new List<long>();
                foreach (var seed in seeds)
                {
                    var value = seed;
                    foreach (var m in map)
                    {
                        foreach (var coords in m)
                            if (value >= coords.Dest && value <= coords.Dest + coords.Range)
                            {
                                value = value + coords.Src - coords.Dest;
                                break;
                            }
                    }

                    locations.Add(value);
                }

                min = locations.Min();
            }

            return $"Result Part 1: {min}";
        }

        public string PartTwo(object data)
        {
            long min = 0;
            if (data is string str)
            {
                var input = str.Split("\r\n");
                var initSeeds = input[0].Split(' ').Skip(1).Select(c => Convert.ToInt64(c)).ToArray();
                var map = new List<List<(long Src, long Dest, long Range)>>();
                var list = new List<(long Src, long Dest, long Range)>();
                foreach (var item in input.Skip(2).Where(w => !string.IsNullOrEmpty(w)))
                {
                    if (!Char.IsDigit(item[0]))
                    {
                        list = new List<(long Src, long Dest, long Range)>(); ;
                        map.Add(list);
                    }
                    if (Char.IsDigit(item[0]))
                    {
                        var coords = item.Split(' ').Select(s => Convert.ToInt64(s)).ToArray();
                        list.Add((coords[0], coords[1], coords[2]));
                    }
                }

                var pairs = new List<(long Start, long End)>();

                for (int i = 0; i < initSeeds.Length; i += 2)
                    pairs.Add((initSeeds[i],initSeeds[i + 1]));

                var locations = new List<long>();
                foreach (var pair in pairs) { 

                    long lastMin = long.MaxValue;
                    for (long j = pair.Start, loopTo = pair.End; j < loopTo; j++)
                    {
                        var value = j;
                        for (int k = 0, loopToMap = map.Count(); k < loopToMap; k++)
                        {
                            for (int l = 0, loopToCoords = map[k].Count; l < loopToCoords; l++)
                            {
                                if (value >= map[k][l].Dest && value <= map[k][l].Dest + map[k][l].Range)
                                {
                                    value = value + map[k][l].Src - map[k][l].Dest;
                                    break;
                                }
                            }

                        }

                        
                        if (value < lastMin)
                            lastMin = value;
                    }

                    locations.Add(lastMin);
                }

                min = locations.Min();
            }

            return $"Result Part 2: {min}";
        }
    }
}
