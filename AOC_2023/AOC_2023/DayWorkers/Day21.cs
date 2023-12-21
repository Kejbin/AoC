using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day21 : Day
    {
        public override string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split(Environment.NewLine)
                            .Where(s => !string.IsNullOrEmpty(s))
                            .Select(s => s.ToArray())
                            .ToArray();


            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        protected override string PartOne(object data)
        {
            int sum = 0;
            if (data is char[][] input)
            {
                HashSet<(int y, int x)> points = new HashSet<(int y, int x)>() { (input[0].Length / 2, input.Length / 2) };
                var mods = new (int y, int x)[] { (0,-1), (0,1), (1,0), (-1,0) };
                HashSet<(int y, int x)> temp = new();
                for (int i = 0; i < 64; i++)
                {
                    foreach (var p in points)
                    {
                        foreach (var mod in mods)
                        {
                            (int y, int x) tp = (p.y + mod.y, p.x + mod.x);

                            if (tp.y < 0 || tp.y == input.Length || tp.x < 0 || tp.x == input[0].Length)
                                continue;

                            if (!temp.Contains(tp) && input[tp.y][tp.x] != '#')
                                temp.Add(tp);
                        }
                    }

                    points = temp.ToHashSet();
                    temp.Clear();
                }

                sum = points.Count;
            }

            return $"Result Part 1: {sum}";
        }

        protected override string PartTwo(object data)
        {
            int sum = 0;
            if (data is char[][] input)
            {

            }

            return $"Result Part 2: {sum}";
        }
    }
}
