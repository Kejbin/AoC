using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AOC_2023.DayWorkers
{
    internal class Day10 : IDay
    {
        public string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split(Environment.NewLine)
                            .Where(s => !string.IsNullOrEmpty(s))
                            .Select(s => s.ToCharArray())
                            .ToList();


            var line = input.First(f => f.Contains('S'));
            (int X, int Y) start;
            start.X = input.IndexOf(line);
            start.Y = Array.IndexOf(line, 'S');

            return PartOne(data) + "\r\n" + PartTwo(data) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        public string PartOne(object data)
        {
            return $"Result Part 1: {data}";
        }

        public string PartTwo(object data)
        {
            return $"Result Part 2: {data}";
        }
    }
}
