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
                    var row = Compare(pattern.Select(s => s.ToList()).ToList());

                    if (row > 0)
                    {
                        sum += 100 * row;
                        continue;
                    }

                    List<List<char>> cols = new();
                    for (int i = 0; i < pattern[0].Length; i++)
                    {
                        var colL = new List<char>();
                        for (int j = 0; j < pattern.Length; j++)
                            colL.Add(pattern[j][i]);

                        cols.Add(colL);
                    }

                    var col = Compare(cols);
                    sum += col;
                }
            }

            return $"Result Part 1: {sum}";
        }

        private int Compare(List<List<char>> pattern)
        {
            var res = 0;
            for (int i = 0; i < pattern.Count; i++)
            {
                for (int j = i + 1; j < pattern.Count; j++)
                {
                    if (j < 0)
                        break;   

                    if (pattern[i].SequenceEqual(pattern[j]))
                    {
                        i++;
                        j -= 2;
                    }
                    else if (i > 0)
                        break;
                }
            }

            return res;
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
