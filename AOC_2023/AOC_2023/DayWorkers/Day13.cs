using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day13 : IDay
    {
        public string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split($"{Environment.NewLine}{Environment.NewLine}")
                            .Where(s => !string.IsNullOrEmpty(s))
                            .Select(s => s.Split(Environment.NewLine)).ToArray();

            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        public string PartOne(object data)
        {
            int sum = 0;
            if (data is string[][] input)
            {
                foreach (var pattern in input)
                {
                    
                }
            }

            return $"Result Part 1: {sum}";
        }

        public string PartTwo(object data)
        {
            int sum = 0;
            if (data is string[][] input)
            {

            }

            return $"Result Part 2: {sum}";
        }
    }
}
