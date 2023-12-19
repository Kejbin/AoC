using System.Data;
using System.Diagnostics;
using System.IO;

namespace AOC_2023.DayWorkers
{
    internal class Day19 : Day
    {
        public override string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split(Environment.NewLine + Environment.NewLine);

            var rules = input[0].Split(Environment.NewLine)
                                .Select(s => s.Split('{'))
                                .ToDictionary(d => d[0], c => SetRules(c[1].Split(',')));
            var parts = input[1].Split(Environment.NewLine)
                                .Select(s  => s.Substring(1, s.Length - 2)
                                               .Split(',')
                                               .Select(ss => ss.Split('='))
                                               .Select(sss => new Part { Category = sss[0][0], Value = Convert.ToInt32(sss[1]) })
                                               .ToList())
                                .ToList();

            return PartOne((rules, parts)) + "\r\n" + PartTwo(rules) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        private List<Rule> SetRules(string[] strings)
        {
            var rules = new List<Rule>();

            foreach (var item in strings)
            {
                var s = item.Split(':');

                if (s.Length > 1)
                    rules.Add(new Rule { Category = s[0][0], Operator = s[0][1], Value = Convert.ToInt32(s[0].Substring(2, s[0].Length - 2)) , Result = s[1] });
                else
                    rules.Add(new Rule { Result = item.Substring(0, item.Length - 1) });

            }

            return rules;
        }

        protected override string PartOne(object data)
        {
            int sum = 0;
            if (data is (Dictionary<string, List<Rule>> Rules, List<List<Part>> Parts))
            {
                foreach (var part in Parts.ToList())
                {
                    string res = "in";
                    var rule = Rules[res];
                    while (res != "A" && res != "R")
                    {
                        for (int i = 0; i < rule.Count; i++)
                        {
                            res = rule[i].Result;

                            if (i == rule.Count - 1)
                                break;

                            var partValue = part.First(p => p.Category == rule[i].Category).Value;
                            if (rule[i].Operator == '>' && partValue > rule[i].Value)
                                break;

                            if (rule[i].Operator == '<' && partValue < rule[i].Value)
                                break;             
                        }

                        //select new rule
                        if (res != "A" && res != "R")
                            rule = Rules[res];
                    }

                    if (res == "R")
                        Parts.Remove(part);
                }

                sum += Parts.Select(s => s.Select(ss => ss.Value).Sum()).Sum();
                //Sum parts
            }

            return $"Result Part 1: {sum}";
        }

        protected override string PartTwo(object data)
        {
            int sum = 0;
            if (data is Dictionary<string, List<Rule>> Rules)
            {
                //TODO Work on ranges
            }

            return $"Result Part 2: {sum}";
        }
    }

    public class Rule
    {
        public char Category { get; set; }
        public char Operator { get; set; }
        public int Value { get; set; }
        public string Result { get; set; }
    }

    public class Part
    {
        public char Category { get; set; }
        public int Value { get; set; }
    }
}
