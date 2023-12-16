using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day8 : Day
    {
        public override string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split("\r\n")
                            .Where(w => !string.IsNullOrEmpty(w))
                            .Select(s => s.Split(' ').Where(s => s != "=").ToList())
                            .ToList();

            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";

        }

        protected override string PartOne(object data)
        {
            int sum = 0;

            if (data is List<List<string>> input)
            {
                var path = input.First()[0];
                var crossroads = input.Skip(1).ToDictionary(s => s[0], v => new Direction(v[1], v[2]));

                var curentCrossroad = "AAA";
                for (var i = 0; i < path.Length; i++)
                {
                    if (crossroads.TryGetValue(curentCrossroad, out Direction? dir))
                    {
                        if (path[i] == 'L')
                        {
                            sum++;

                            if (dir.Left == "ZZZ")
                                break;

                            curentCrossroad = dir.Left;
                        }

                        if (path[i] == 'R')
                        {
                            sum++;

                            if (dir.Right == "ZZZ")
                                break;

                            curentCrossroad = dir.Right;
                        }
                    }

                    if (i == path.Length - 1)
                        i = -1;
                }
            }

            return $"Result Part 1: {sum}";
        }

        protected override string PartTwo(object data)
        {
            long sum = 0;

            if (data is List<List<string>> input)
            {
                var path = input.First()[0];
                var crossroads = input.Skip(1).ToDictionary(s => s[0], v => new Direction(v[1], v[2]));

                List<Task<int>> tasks = new List<Task<int>>();

                var endsWithA = crossroads.Where(s => s.Key.EndsWith('A')).Select(s => s.Key);
                foreach (var start in endsWithA)
                    tasks.Add(Task.Run(() => Worker(start, crossroads, path)));

                var res = Task.WhenAll(tasks).Result;
                sum = GetLCM(res);
            }

            return $"Result Part 2: {sum}";
        }

        private long GetLCM(int[] res)
        {
            return res.Select(s => Convert.ToInt64(s)).Aggregate((a, b) => LCM(a,b));
        }

        private long LCM(long a, long b)
        {
            return a / GCF(a, b) * b;
        }

        private long GCF(long a, long b)
        {
            while(b != 0)
            {
                var c = b;
                b = a % b;
                a = c;
            }

            return a;
        }

        public int Worker(string start, Dictionary<string, Direction> crossroads, string path) 
        {
            int sum = 0;
            for (var i = 0; i < path.Length; i++)
            {
                if (crossroads.TryGetValue(start, out Direction? dir))
                {
                    if (path[i] == 'L')
                    {
                        sum++;

                        if (dir.Left.EndsWith('Z'))
                            break;

                        start = dir.Left;
                    }

                    if (path[i] == 'R')
                    {
                        sum++;

                        if (dir.Right.EndsWith('Z'))
                            break;

                        start = dir.Right;
                    }
                }

                if (i == path.Length - 1)
                    i = -1;
            }

            return sum;
        }
    }

    public class Direction
    {
        public Direction(string l, string r)
        {
            Left = l.Substring(1,3);
            Right = r.Substring(0,3);
        }

        public string Left { get; private set; }
        public string Right { get; private set; }
    }
}
