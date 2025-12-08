using System.Collections.Generic;
using System.Linq;

namespace AOC_2025.DayWorkers
{
    internal class Day8 : Day
    {
        public override string Execute(string data)
        {
            return PartOne(data) + "\r\n" + PartTwo(data);
        }

        protected override string PartOne(object data)
        {
            if (data == null)
                return "";

            var junction3dMap = data.ToString()
                .Split(Environment.NewLine)
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(s => s.Split(',')
                            .Select(ss => int.Parse(ss))
                            .ToArray())
                .Select(s => new Point3D(s[0], s[1], s[2])).ToArray();

            var circuts = junction3dMap.Select(s => new HashSet<Point3D> { s }).ToList();
            var visited = new Dictionary<(Point3D, Point3D), double>();

            for (var i = 0; i < junction3dMap.Length; i++)
            {
                for (var j = 0; j < junction3dMap.Length; j++)
                {
                    if (i == j)
                        continue;

                    var tp1 = junction3dMap[i];
                    var tp2 = junction3dMap[j];

                    if (visited.ContainsKey((tp1, tp2)) || visited.ContainsKey((tp2, tp1)))
                        continue;

                    var currentLength = Math.Sqrt(Math.Pow(tp2.X - tp1.X, 2) + Math.Pow(tp2.Y - tp1.Y, 2) + Math.Pow(tp2.Z - tp1.Z, 2));
                    visited.Add((tp1, tp2), currentLength);
                }
            }

            var s = visited.OrderBy(v => v.Value).ToList();

            for (int l = 0; l < 1000; l++)
            {
                var point = s[l];

                var c1 = circuts.FirstOrDefault(a => a.Contains(point.Key.Item1));
                var c2 = circuts.FirstOrDefault(a => a.Contains(point.Key.Item2));
                if (c1 is not null && c2 is not null && !c1.Equals(c2))
                {
                    foreach (var i in c2.Where(c => !c1.Contains(c))) c1.Add(i);
                    circuts.Remove(c2);
                }
                else
                    circuts.Add(new HashSet<Point3D> { point.Key.Item1, point.Key.Item2 });
            }

            return "Part one: " + circuts.Select(s => s.Count).OrderDescending().Take(3).Aggregate((a, b) => a * b);
        }

        protected override string PartTwo(object data)
        {
            if (data == null)
                return "";


            var junction3dMap = data.ToString()
                .Split(Environment.NewLine)
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(s => s.Split(',')
                            .Select(ss => int.Parse(ss))
                            .ToArray())
                .Select(s => new Point3D(s[0], s[1], s[2])).ToArray();

            var circuts = junction3dMap.Select(s => new HashSet<Point3D> { s }).ToList();
            var visited = new Dictionary<(Point3D, Point3D), double>();

            for (var i = 0; i < junction3dMap.Length; i++)
            {
                for (var j = 0; j < junction3dMap.Length; j++)
                {
                    if (i == j)
                        continue;

                    var tp1 = junction3dMap[i];
                    var tp2 = junction3dMap[j];

                    if (visited.ContainsKey((tp1, tp2)) || visited.ContainsKey((tp2, tp1)))
                        continue;

                    var currentLength = Math.Sqrt(Math.Pow(tp2.X - tp1.X, 2) + Math.Pow(tp2.Y - tp1.Y, 2) + Math.Pow(tp2.Z - tp1.Z, 2));
                    visited.Add((tp1, tp2), currentLength);
                }
            }

            var s = visited.OrderBy(v => v.Value).ToList();
            var result = 0UL;
            for (int l = 0; l < s.Count; l++)
            {
                var point = s[l];

                var c1 = circuts.FirstOrDefault(a => a.Contains(point.Key.Item1));
                var c2 = circuts.FirstOrDefault(a => a.Contains(point.Key.Item2));
                if (c1 is not null && c2 is not null && !c1.Equals(c2))
                {
                    foreach (var i in c2.Where(c => !c1.Contains(c))) c1.Add(i);
                    circuts.Remove(c2);
                }
                else if (c1.Equals(c2))
                    continue;
                else
                    circuts.Add(new HashSet<Point3D> { point.Key.Item1, point.Key.Item2 });

                if (circuts.Count == 1)
                {
                    result = Convert.ToUInt64(point.Key.Item1.X) * Convert.ToUInt64(point.Key.Item2.X);
                    break;
                }
            }

            return "Part two: " + result;
        }

        struct Point3D
        {
            public Point3D(int x, int y, int z) {
                X = x;
                Y = y;
                Z = z;
            }

            public int X { get; }
            public int Y { get; }
            public int Z { get; }
        }
    }
}

