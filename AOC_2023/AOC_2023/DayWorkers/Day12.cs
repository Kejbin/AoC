using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day12 : IDay
    {
        public string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split(Environment.NewLine)
                            .Where(s => !string.IsNullOrEmpty(s))
                            .Select(s => s.Split(' '))
                            .Select(s => (s[0], s[1].Split(',')
                                                    .Select(e => Convert.ToInt32(e))
                                                    .ToList()))
                            .ToList();

            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        public string PartOne(object data)
        {
            int sum = 0;
            if (data is List<(string Springs, List<int> DamagedSpringsNumbers)> input)
            {
                foreach (var item in input)
                {

                }
            }

            return $"Result Part 1: {sum}";
        }

        public string PartTwo(object data)
        {
            int sum = 0;
            if (data is List<(string Springs, List<int> DamagedSpringsNumbers)> input)
            {
                
            }

            return $"Result Part 2: {sum}";
        }
    }
}
