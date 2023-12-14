using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day14 : IDay
    {
        public string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split($"{Environment.NewLine}")
                            .Where(s => !string.IsNullOrEmpty(s))
                            .Select(s => s.ToCharArray()).ToList();

            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        public string PartOne(object data)
        {
            int sum = 0;
            if (data is List<char[]> inp)
            {
                var input = inp.Select(s => s.ToArray()).ToList();
                for (int i = 1; i < input.Count; i++)
                {
                    for (int j = 0, loopTo = input[i].Length; j < loopTo; j++)
                    {
                        if (input[i][j] != 'O')
                            continue;

                        int k = i;
                        while (k > 0)
                        {
                            if (input[k - 1][j] == '.')
                            {
                                var temp = input[k - 1][j];
                                input[k - 1][j] = input[k][j];
                                input[k][j] = temp;
                            }
                            else
                                break;

                            k--;
                        }
                    }
                }

                for (int i = 0; i < input.Count; i++)
                {
                    var lineValue = input.Count - i;
                    sum += input[i].Where(w => w == 'O').Count() * lineValue;
                }
            }

            return $"Result Part 1: {sum}";
        }

        public string PartTwo(object data)
        {
            int sum = 0;
            if (data is List<char[]> inp)
            {
                var input = inp.Select(s => s.ToArray()).ToList();
                for (int l = 0; l < 1000000000; l++)
                {
                    NorthCycle(input);
                    WestCycle(input);
                    SouthCycle(input);
                    EastCycle(input);
                }

                for (int i = 0; i < input.Count; i++)
                {
                    var lineValue = input.Count - i;
                    sum += input[i].Where(w => w == 'O').Count() * lineValue;
                }
            }

            return $"Result Part 2: {sum}";
        }

        private void NorthCycle(List<char[]> input)
        {
            for (int i = 1; i < input.Count; i++)
            {
                for (int j = 0, loopTo = input[i].Length; j < loopTo; j++)
                {
                    if (input[i][j] != 'O')
                        continue;

                    int k = i;
                    while (k > 0)
                    {
                        if (input[k - 1][j] != '.')
                            break;

                        k--;
                    }

                    if (k != i)
                    {
                        var temp = input[k][j];
                        input[k][j] = input[i][j];
                        input[i][j] = temp;
                    }
                }
            }
        }

        private void WestCycle(List<char[]> input)
        {
            for (int i = 1; i < input[0].Length; i++)
            {
                for (int j = 0, loopTo = input.Count; j < loopTo; j++)
                {
                    if (input[j][i] != 'O')
                        continue;

                    int k = i;
                    while (k > 0)
                    {
                        if (input[j][k - 1] != '.')
                            break;

                        k--;
                    }

                    if (k != i)
                    {
                        var temp = input[j][k];
                        input[j][k] = input[j][i];
                        input[j][i] = temp;
                    }
                }
            }
        }

        private void SouthCycle(List<char[]> input)
        {
            for (int i = input.Count - 2; i >= 0; i--)
            {
                for (int j = 0, loopTo = input[i].Length; j < loopTo; j++)
                {
                    if (input[i][j] != 'O')
                        continue;

                    int k = i;
                    while (k < input.Count - 1)
                    {
                        if (input[k + 1][j] != '.')
                            break;

                        k++;
                    }

                    if (k != i)
                    {
                        var temp = input[k][j];
                        input[k][j] = input[i][j];
                        input[i][j] = temp;
                    }

                }
            }
        }

        private void EastCycle(List<char[]> input)
        {
            for (int i = input[0].Length - 2; i >= 0; i--)
            {
                for (int j = 0, loopTo = input.Count; j < loopTo; j++)
                {
                    if (input[j][i] != 'O')
                        continue;

                    int k = i;
                    while (k < input[0].Length - 1)
                    {
                        if (input[j][k + 1] != '.')
                            break;

                        k++;
                    }

                    if (k != i)
                    {
                        var temp = input[j][k];
                        input[j][k] = input[j][i];
                        input[j][i] = temp;
                    }
                }
            }
        }
    }
}
