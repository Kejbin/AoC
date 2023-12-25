using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day23 : Day
    {
        public override string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split(Environment.NewLine)
                            .Where(s => !string.IsNullOrEmpty(s))
                            .Select(s => s.ToList())
                            .ToList();

            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        protected override string PartOne(object data)
        {
            int sum = 0;
            if (data is List<List<char>> input)
            {

                var start = input[0][input[0].IndexOf('.')];
                var end = input[input.Count - 1][input[0].IndexOf('.')];
            }

            return $"Result Part 1: {sum}";
        }

        protected override string PartTwo(object data)
        {
            int sum = 0;
            if (data is List<(string Springs, List<int> DamagedSpringsNumbers)> input)
            {

            }

            return $"Result Part 2: {sum}";
        }
    }
}
