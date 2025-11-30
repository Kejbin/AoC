using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC_2024.DayWorkers
{
    internal class Day7 : Day
    {
        public override string Execute(string data)
        {
            return PartOne(data) + "\r\n" + PartTwo(data);
        }

        protected override string PartOne(object data)
        {
            long sum = 0;
            Stopwatch sw = new();
            if (data is string str)
            {
                sw.Start();

                sum = GetCorrectTestsCount(str, false);

                sw.Stop();
            }            
           
            return $"Result Part 1: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }

        private long GetCorrectTestsCount(string str, bool withConcat)
        {
            var input = str.Split(Environment.NewLine)
                .Select(s => s.Split(": "))
                .Select(ss => (long.Parse(ss[0]), ss[1].Split(' ')
                                                      .Select(long.Parse)
                                                      .ToArray()));

            var count = 0L;

            foreach (var row in input)
            {
                var options = new List<char> { '+', '*' };
                if (withConcat)
                    options.Add('|');

                var operations = row.Item2.Length - 1;
                var setsCount = (int)Math.Pow(2, operations);

                List<char[]> combinations = new List<char[]>(setsCount);
                GetCombinations(options, combinations, setsCount, operations, 0);

                foreach (var combination in combinations)
                {
                    var sum = row.Item2[0];
                    for (var i = 0; i < combination.Length; i++)
                    {
                        if (combination[i] == '+')
                            sum = sum + row.Item2[i + 1];
                        else if (combination[i] == '*')
                            sum = sum * row.Item2[i + 1];
                        else if (combination[i] == '|')
                            sum = long.Parse($"{sum}{row.Item2[i + 1]}");
                    }   

                    if (sum == row.Item1)
                    {
                        count+=sum;
                        break;
                    }
                }
            }

            return count;
        }

        private void GetCombinations(List<char> options, List<char[]> combinations, int setsCount, int operations, int index, char[] combination = null)
        {
            if (index == operations)
            {
                combinations.Add(combination);
                return;
            }

            for (int i = 0; i < options.Count; i++)
            {
                var copyComb = new char[operations];
                if(combination != null)
                    Array.Copy(combination, copyComb, operations);

                copyComb[index] = options[i];
                GetCombinations(options, combinations, setsCount, operations, index + 1, copyComb);
            }
        }

        protected override string PartTwo(object data)
        {
            long sum = 0;
            Stopwatch sw = new();
            if (data is string str)
            {
                sw.Start();

                sum = GetCorrectTestsCount(str, true);

                sw.Stop();
            }

            return $"Result Part 2: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }
    }
}
