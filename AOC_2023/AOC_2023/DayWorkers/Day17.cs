using System.Diagnostics;

namespace AOC_2023.DayWorkers
{
    internal class Day17 : Day
    {
        public override string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split(Environment.NewLine)
                            .Where(s => !string.IsNullOrEmpty(s));

            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        protected override string PartOne(object data)
        {
            int sum = 0;
            if (data is object input)
            {

            }

            return $"Result Part 1: {sum}";
        }

        protected override string PartTwo(object data)
        {
            int sum = 0;
            if (data is object input)
            {

            }

            return $"Result Part 2: {sum}";
        }
    }
}