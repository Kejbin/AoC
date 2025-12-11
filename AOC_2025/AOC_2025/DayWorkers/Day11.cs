using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace AOC_2025.DayWorkers
{
    internal class Day11 : Day
    {
        public override string Execute(string data)
        {
            return PartOne(data) + "\r\n" + PartTwo(data);
        }

        protected override string PartOne(object data)
        {
            if (data == null)
                return "";

            var switches = data.ToString()
                                .Split(Environment.NewLine)
                                .Select(s => s.Split(": "))
                                .Select(s => (s[0], s[1].Split(' ')))
                                .ToDictionary(d => d.Item1, d => d.Item2);

            var q = new Stack<(string, HashSet<string>)>();
            var path = new HashSet<string>();
            var paths = new List<HashSet<string>>();
            q.Push(("you", new HashSet<string>()));

            while (q.Count > 0)
            {
                var p = q.Pop();
                if (p.Item1 == "out")
                {
                    paths.Add(p.Item2);
                    continue;
                }

                var item = switches[p.Item1];

                var newPath = p.Item2.ToHashSet();
                newPath.Add(p.Item1);

                if (p.Item2.Contains(p.Item1))
                    continue;

                foreach (var s in item)
                    q.Push((s, newPath));
            }

            return "Part one: " + paths.Count;
        }


        protected override string PartTwo(object data)
        {
            if (data == null)
                return "";

            var switches = data.ToString()
                                .Split(Environment.NewLine)
                                .Select(s => s.Split(": "))
                                .Select(s => (s[0], s[1].Split(' ')))
                                .ToDictionary(d => d.Item1, d => d.Item2);

            var q = new Stack<(string, HashSet<string>)>();
            var path = new HashSet<string>();
            var paths = new List<HashSet<string>>();
            q.Push(("svr", new HashSet<string>()));

            while (q.Count > 0)
            {
                var p = q.Pop();
                if (p.Item1 == "out")
                    if(p.Item2.Contains("fft") && p.Item2.Contains("dac"))
                    {
                        paths.Add(p.Item2);
                        continue;
                    }
                    else
                        continue;

                if (p.Item2.Contains(p.Item1))
                    continue;

                var item = switches[p.Item1];

                var newPath = p.Item2.ToHashSet();
                newPath.Add(p.Item1);

                foreach (var s in item)
                    q.Push((s, newPath));
            }

            return "Part two: " + paths.Count;
        }
    }
}

