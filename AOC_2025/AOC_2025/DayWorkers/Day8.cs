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

            var circuts = junction3dMap.Select(s => new List<Point3D> { s }).ToList();

            for (int l = 1; l < 10; l++)
            {
                double connection = int.MaxValue;
                Point3D p1 = default;
                Point3D p2 = default;
                for (var i = 0; i < junction3dMap.Length; i++)
                {
                    for (var j = 0; j < junction3dMap.Length; j++)
                    {
                        if (i == j)
                            continue;

                        var tp1 = junction3dMap[i];
                        var tp2 = junction3dMap[j];

                        if(circuts.Any(a => a.Contains(tp1) && a.Contains(tp2)))
                            continue;

                        var currentLength = Math.Sqrt(Math.Pow((tp2.X - tp1.X), 2) + Math.Pow((tp2.Y - tp1.Y), 2) + Math.Pow((tp2.Z - tp1.Z), 2));
                        if (currentLength < connection)
                        {
                            connection = currentLength;
                            p1 = tp1;
                            p2 = tp2;
                        }
                    }
                }

                var c1 = circuts.FirstOrDefault(a => a.Contains(p1));
                var c2 = circuts.FirstOrDefault(a => a.Contains(p2));
                if (c1 is not null && c2 is not null && !c1.Equals(c2))
                {
                    c1.AddRange(c2.Where(c => !c1.Contains(c)));
                    circuts.Remove(c2);
                }
                else
                    circuts.Add(new List<Point3D> { p1, p2 });
            }

            return "Part one: " + circuts.Select(s => s.Count).OrderDescending().Take(3).Aggregate((a,b) => a * b);
        }

        protected override string PartTwo(object data)
        {
            if (data == null)
                return "";

            return "Part two: " + 0;
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

