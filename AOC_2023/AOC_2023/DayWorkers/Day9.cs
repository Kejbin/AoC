using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day9 : IDay
    {
        public string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split(Environment.NewLine)
                            .Where(s => !string.IsNullOrEmpty(s))
                            .Select(s => s.Split(' ').Select(c => Convert.ToInt32(c)).ToArray())
                            .ToList();

            int part1 = 0, part2 = 0;
            foreach (var item in input)
            {
                var predictions = GetHistoryPredictions(item);
                part1 += predictions.Part1;
                part2 += predictions.Part2;
            }

            return PartOne(part1) + "\r\n" + PartTwo(part2) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        public string PartOne(object data)
        {
            return $"Result Part 1: {data}";
        }

        private (int Part1, int Part2) GetHistoryPredictions(int[] values)
        {
            if (values.All(v => v == 0))
                return (values.First(), 0 + values.Last());

            var newValues = new int[values.Length - 1];

            for (int i = 0; i < values.Length - 1; i++)
                newValues[i] = values[i + 1] - values[i];

            var predictions = GetHistoryPredictions(newValues);
            return (predictions.Part1 + values.Last(), values.First() - predictions.Part2);
        }

        public string PartTwo(object data)
        {
            return $"Result Part 2: {data}";
        }
    }
}
