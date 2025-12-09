using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace AOC_2025.DayWorkers
{
    internal class Day9 : Day
    {
        public override string Execute(string data)
        {
            return PartOne(data) + "\r\n" + PartTwo(data);
        }

        protected override string PartOne(object data)
        {
            if (data == null)
                return "";

            var points = data.ToString()
                            .Split(Environment.NewLine)
                            .Where(w => !string.IsNullOrWhiteSpace(w))
                            .Select(s => s.Split(',')
                                        .Select(s => long.Parse(s))
                                        .ToArray())
                            .ToArray();

            var dict = new Dictionary<(int, int), double>();

            for (int i = 0; i < points.Length; i++)
                for (int j = 0; j < points.Length; j++)
                {
                    if (dict.ContainsKey((i, j)) || dict.ContainsKey((j, i)))
                        continue;

                    var value = Math.Sqrt(Math.Pow(points[j][0] - points[i][0], 2) + Math.Pow(points[j][1] - points[i][1], 2));
                    dict.Add((i,j), value);
                }

            var largest = dict.OrderByDescending(o => o.Value).First();

            var p1 = points[largest.Key.Item1];
            var p2 = points[largest.Key.Item2];

            long area = (Math.Abs(p2[0] - p1[0]) + 1) * (Math.Abs(p2[1] - p1[1]) + 1);

            return "Part one: " + area;
        }

        protected override string PartTwo(object data)
        {
            if (data == null)
                return "";

            var points = data.ToString()
                .Split(Environment.NewLine)
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .Select(s => s.Split(',')
                            .Select(s => long.Parse(s))
                            .ToArray())
                .ToArray();

            var dict = new Dictionary<(int, int), double>();
            var visited = new HashSet<(int, int)>();

            for (int i = 0; i < points.Length; i++)
                for (int j = 0; j < points.Length; j++)
                {
                    if (i == j || visited.Contains((i, j)) || visited.Contains((j, i)))
                        continue;

                    if (IsInBounadaries(points[j], points[i], points)) 
                    {
                        var value = Math.Sqrt(Math.Pow(points[j][0] - points[i][0], 2) + Math.Pow(points[j][1] - points[i][1], 2));
                        dict.Add((i, j), value);
                    }

                    visited.Add((i, j));
                }

            var largest = dict.OrderByDescending(o => o.Value).First();

            var p1 = points[largest.Key.Item1];
            var p2 = points[largest.Key.Item2];

            long area = (Math.Abs(p2[0] - p1[0]) + 1) * (Math.Abs(p2[1] - p1[1]) + 1);

            return "Part two: " + area;
        }

        private bool IsInBounadaries(long[] pp2, long[] pp1, long[][] points)
        {
            var pointsToCheck = new HashSet<(long X, long Y)>();

            for (long i = Math.Min(pp1[1], pp2[1]); i <= Math.Max(pp1[1], pp2[1]); i++)
                for (long j = Math.Min(pp1[0], pp2[0]); j <= Math.Max(pp1[0], pp2[0]); j++)
                    if ((i == pp1[1] || i == pp2[1]) || (j == pp2[0] || j == pp1[0]))
                        pointsToCheck.Add((j, i));

            foreach (var point in pointsToCheck)
            {
                long[] p1 = points[0], p2;
                double x = point.X, y = point.Y;
                bool inside = false;

                // Loop through each edge in the polygon
                for (int i = 1; i <= points.Length; i++)
                {
                    // Get the next point in the polygon
                    p2 = points[i % points.Length];

                    // Check if the point is above the minimum y coordinate of the edge
                    if (y >= Math.Min(p1[1], p2[1]))
                    {
                        // Check if the point is below the maximum y coordinate of the edge
                        if (y <= Math.Max(p1[1], p2[1]))
                        {
                            // Check if the point is to the left of the maximum x coordinate of the edge
                            if (x <= Math.Max(p1[0], p2[0]))
                            {
                                // Calculate the x-intersection of the line connecting the point to the edge
                                var v = (y - p1[1]) * (p2[0] - p1[0]) / (p2[1] - p1[1]);
                                double xIntersection = double.IsNaN(v) ? p1[0] : v + p1[0];

                                // Check if the point is on the same line as the edge or to the left of the x-intersection
                                if (p1[0] == p2[0] || x <= xIntersection)
                                {
                                    // Flip the inside flag
                                    inside = !inside;
                                }
                            }
                        }
                    }

                    // Store the current point as the first point for the next iteration
                    p1 = p2;
                }

                // Return the value of the inside flag
                if (inside is false)
                    return false;
            }

            return true;
        }
    }
}

