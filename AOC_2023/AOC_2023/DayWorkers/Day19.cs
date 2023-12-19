using System.Data;
using System.Diagnostics;

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
                                               .Select(sss => new Part { Category = sss[0], Value = Convert.ToInt32(sss[1]) })
                                               .ToList())
                                .ToList();

            return PartOne((rules, parts)) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
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
                    rules.Add(new Rule { Result = item });

            }

            return rules;
        }

        protected override string PartOne(object data)
        {
            int sum = 0;
            if (data is (Dictionary<string, List<Rule>> Rules, List<List<Part>> Parts))
            {

            }

            return $"Result Part 1: {sum}";
        }

        protected override string PartTwo(object data)
        {
            int sum = 0;
            if (data is object obj)
            {

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
        public string Category { get; set; }
        public int Value { get; set; }
    }
}
