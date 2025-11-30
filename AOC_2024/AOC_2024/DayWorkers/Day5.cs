using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC_2024.DayWorkers
{
    internal class Day5 : Day
    {
        public override string Execute(string data)
        {
            return PartOne(data) + "\r\n" + PartTwo(data);
        }

        protected override string PartOne(object data)
        {
            int sum = 0;
            Stopwatch sw = new();
            if (data is string str)
            {
                sw.Start();
                sum = FindCorrectPrints(str);
                sw.Stop();
            }            
           
            return $"Result Part 1: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }

        private int FindCorrectPrints(string str)
        {
            var split = str.Split(Environment.NewLine);

            var rules = split.TakeWhile(tk => tk.Contains('|'))
                .Select(s => s.Split('|').Select(ss => int.Parse(ss)));

            var rulesUp = rules.GroupBy(s => s.First())
                               .ToDictionary(k => k.Key, v => v.Select(sm => sm.Last()).ToList());

            var rulesDown = rules.GroupBy(s => s.Last())
                                 .ToDictionary(k => k.Key, v => v.Select(sm => sm.First()).ToList());


            var prints = split.Where(tk => tk.Contains(',')).Select(s => s.Split(',').Select(ss => int.Parse(ss)).ToArray()).ToArray();

            var count = 0;
            for (int i = 0; i < prints.Length; i++)
            {
                var skip = false;
                for (int j = 0; j < prints[i].Length - 1; j++)
                {
                    for (var k = 0; k < prints[i].Length; k++)
                    {
                        if (k == j)
                            continue;

                        if(k < j)
                        {
                            if (rulesUp.TryGetValue(prints[i][j], out List<int> over) && over.Contains(prints[i][k]))
                            {
                                skip = true;
                                break;
                            }
                        }

                        if(k > j)
                        {
                            if (rulesDown.TryGetValue(prints[i][j], out List<int> under) && under.Contains(prints[i][k]))
                            {
                                skip = true;
                                break;
                            }
                        }
                    }
                }

                if (!skip)
                    count+= prints[i][prints[i].Length/2];
            }

            return count;
        } 

        protected override string PartTwo(object data)
        {
            int sum = 0;
            Stopwatch sw = new();
            if (data is string str)
            {
                sw.Start();
                sum = FindAndFixIncorrectPrints(str);
                sw.Stop();
            }

            return $"Result Part 2: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }

        private int FindAndFixIncorrectPrints(string str)
        {
            var split = str.Split(Environment.NewLine);

            var rules = split.TakeWhile(tk => tk.Contains('|'))
                .Select(s => s.Split('|').Select(ss => int.Parse(ss)));

            var rulesUp = rules.GroupBy(s => s.First()).OrderBy(s => s.Key)
                               .ToDictionary(k => k.Key, v => v.Select(sm => sm.Last()).ToList());

            var rulesDown = rules.GroupBy(s => s.Last()).OrderBy(s => s.Key)
                                 .ToDictionary(k => k.Key, v => v.Select(sm => sm.First()).ToList());

            var allRulesNumbers = rulesUp.Keys.Concat(rulesDown.Keys).Distinct().ToArray();

            //var orderedRules = BuildOrderedRules(allRulesNumbers, rulesUp);

            var prints = split.Where(tk => tk.Contains(',')).Select(s => s.Split(',').Select(ss => int.Parse(ss)).ToArray()).ToArray();

            var count = 0;
            for (int i = 0; i < prints.Length; i++)
            {
                var toFix= false;
                for (int j = 0; j < prints[i].Length - 1; j++)
                {
                    for (var k = 0; k < prints[i].Length; k++)
                    {
                        if (k == j)
                            continue;

                        if (k < j)
                        {
                            if (rulesUp.TryGetValue(prints[i][j], out List<int> over) && over.Contains(prints[i][k]))
                            {
                                toFix = true;
                                break;
                            }
                        }

                        if (k > j)
                        {
                            if (rulesDown.TryGetValue(prints[i][j], out List<int> under) && under.Contains(prints[i][k]))
                            {
                                toFix = true;
                                break;
                            }
                        }
                    }
                }

                if (toFix)
                {
                    var list = BuildOrderedRules(prints[i], rulesUp, rulesDown);
                    count += list[list.Count/ 2];
                }
            }

            return count;
        }

        private List<int> BuildOrderedRules(int[] allRulesNumbers, Dictionary<int, List<int>> rulesUp, Dictionary<int, List<int>> rulesDown)
        {
            var orderedList = new List<int>(allRulesNumbers);

            foreach (var rule in allRulesNumbers)
            {
                if (rulesUp.TryGetValue(rule, out List<int> rules))
                {
                    var index = 0;
                    foreach (var item in orderedList)
                    {
                        if (rules.Contains(item))
                            index = orderedList.IndexOf(item);
                    }

                    orderedList.Remove(rule);
                    orderedList.Insert(index, rule);
                }

                if (rulesDown.TryGetValue(rule, out rules))
                {
                    var index = 0;
                    foreach (var item in orderedList)
                    {
                        if (rules.Contains(item))
                            index = orderedList.IndexOf(item);
                    }

                    orderedList.Remove(rule);
                    if (orderedList.Count < index + 1)
                        orderedList.Add(rule);
                    else
                        orderedList.Insert(index + 1, rule);
                }
            }

            orderedList.Reverse();

            return orderedList;
        }
    }
}
