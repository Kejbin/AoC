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
                    var row = 0;
                    var col = 0;
                    for (int i = 0; i < pattern.Length; i++)
                    {
                        for (int j = pattern.Length - 1; j > i; j--)
                        {
                            if (pattern[i] == pattern[j])
                                i++;
                            else if(i != 0)
                                break;

                            if (j - 1 <= i)
                                row = i;
                        }

                        if (row > 0)
                            break;
                    }

                    List<List<char>> cols = new();
                    for (int i = 0; i < pattern[0].Length; i++)
                    {
                        var colL = new List<char>();
                        for (int j = 0; j < pattern.Length; j++)
                            colL.Add(pattern[j][i]);

                        cols.Add(colL);
                    }

                    for (int i = 0; i < cols.Count; i++)
                    {
                        for (int j = cols.Count - 1; j > i; j--)
                        {
                            if (cols[i].SequenceEqual(cols[j]))
                                i++;
                            else if(i != 0)
                                break;

                            if (j - 1 <= i)
                                col = i;
                        }

                        if (col > 0)
                            break;
                    }

                    if (row > 0)
                        sum += 100 * row;
                    else
                        sum += col;
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
