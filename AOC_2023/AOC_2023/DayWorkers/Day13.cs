using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day13 : Day
    {
        public override string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split($"{Environment.NewLine}{Environment.NewLine}")
                            .Where(s => !string.IsNullOrEmpty(s))
                            .Select(s => s.Split(Environment.NewLine)).ToArray();

            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        protected override string PartOne(object data)
        {
            int sum = 0;
            if (data is string[][] input)
            {
                foreach (var pattern in input)
                {
                    var row = Compare(pattern.Select(s => s.ToList()).ToList());

                    if (row.HasValue)
                    {
                        sum += 100 * (row.Value + 1);
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
                    if(col.HasValue)
                        sum += (col.Value + 1);
                }
            }

            return $"Result Part 1: {sum}";
        }

        private int? Compare(List<List<char>> pattern)
        {
            int? res = 0;
            for (int i = 0; i < pattern.Count - 1; i++)
            {
                if (pattern[i].SequenceEqual(pattern[i + 1]))
                {
                    res = i;

                    var temp = i - 1;

                    if (i == pattern.Count - 2 || temp < 0)
                        return res;

                    for (int j = i + 2; temp >= 0 && j < pattern.Count; j++)
                    {
                        if (pattern[temp].SequenceEqual(pattern[j]))
                        {
                            if (temp == 0 || j == pattern.Count - 1)
                                return res;

                            temp--;
                        }
                        else
                                break;
                    }
                }

                res = null;
            }

            return res;
        }

        protected override string PartTwo(object data)
        {
            int sum = 0;
            if (data is string[][] input)
            {
                foreach (var pattern in input)
                {
                    var row = ComparePart2(pattern.Select(s => s.ToList()).ToList());

                    if (row.HasValue)
                    {
                        sum += 100 * (row.Value + 1);
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

                    var col = ComparePart2(cols);
                    if (col.HasValue)
                        sum += (col.Value + 1);
                }
            }

            return $"Result Part 2: {sum}";
        }

        private int? ComparePart2(List<List<char>> pattern)
        {
            int? res = 0;
            int diff = 0;
            for (int i = 0; i < pattern.Count - 1; i++)
            {
                diff += FindDifferences(pattern[i], pattern[i+1]);
                if (diff < 2)
                {
                    res = i;

                    var temp = i - 1;

                    if ((i == pattern.Count - 2 || temp < 0) && diff == 1)
                        return res;

                    for (int j = i + 2; temp >= 0 && j < pattern.Count; j++)
                    {
                        diff += FindDifferences(pattern[temp],pattern[j]);
                        if (diff < 2)
                        {
                            if ((temp == 0 || j == pattern.Count - 1) && diff == 1)
                                return res;

                            temp--;
                        }
                        else
                            break;
                    }
                }

                diff = 0;
                res = null;
            }

            return res;
        }

        private int FindDifferences(List<char> list1, List<char> list2)
        {
            var diffs = 0;
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i])
                    diffs++;

                if (diffs > 1)
                    return diffs;
            }

            return diffs;
        }
    }
}
