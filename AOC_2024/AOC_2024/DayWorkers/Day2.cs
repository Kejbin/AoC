using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC_2024.DayWorkers
{
    internal class Day2 : Day
    {
        public override string Execute(string data)
        {
            return PartOne(data) + "\r\n" + PartTwo(data);
        }

        protected override string PartOne(object data)
        {
            int sum = 0;
            if (data is string str)
            {
                var reports = GetReports(str);
                foreach (var report in reports)
                {
                    var add = true;
                    var dir = false;

                    dir = report[0] < report[1];

                    for (int i = 1; i < report.Length; i++)
                    {           
                        var diff = report[i - 1] - report[i];

                        if (Math.Abs(diff) > 3
                            || diff == 0
                            || dir != report[i - 1] < report[i])
                        {
                            add = false;
                            break;
                        }
                    }

                    if (add)
                        sum++;
                }
            }            
           
            return $"Result Part 1: {sum}";
        }

        private int[][] GetReports(string str)
        {
            return str.Split(Environment.NewLine)
                        .Where(s => !string.IsNullOrWhiteSpace(s))
                        .Select(r => r.Split(" ")
                                      .Select(i => int.Parse(i))
                                      .ToArray())
                        .ToArray();
        }

        protected override string PartTwo(object data)
        {
            int sum = 0;
            if (data is string str)
            {
                var reports = GetReports(str);
                foreach (var report in reports)
                {
                    var add = true;
                    var dir = false;
                    dir = report[0] < report[1];

                    for (int i = 1; i < report.Length; i++)
                    {
                        var diff = report[i - 1] - report[i];

                        if (Math.Abs(diff) > 3
                            || diff == 0
                            || dir != report[i - 1] < report[i])
                        {
                            if (!Recheck(report, i - 1, dir))
                            {
                                add = false;
                                break;
                            }
                            else
                                break;
                        }
                    }

                    if (add)
                        sum++;
                }
            }

            return $"Result Part 2: {sum}";
        }

        private bool Recheck(int[] report, int i, bool dir1)
        {
            for (int k = 0; k < report.Length; k++)
            {
                var secondChanceArray = report.Where((v, c) => c != k).ToArray();
                var add = true;

                var dir = secondChanceArray[0] < secondChanceArray[1];
                for (int j = 1; j < secondChanceArray.Length; j++)
                {
                    var diff = secondChanceArray[j - 1] - secondChanceArray[j];

                    if (Math.Abs(diff) > 3
                        || diff == 0
                        || dir != secondChanceArray[j - 1] < secondChanceArray[j])
                    {
                        add = false;
                        break;
                    }
                }

                if (add)
                    return true;
            }

            return false;
        }
    }
}
