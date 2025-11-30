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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AOC_2024.DayWorkers
{
    internal class Day12 : Day
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

                sum = FencePricingByPiece(str);

                sw.Stop();
            }

            return $"Result Part 1: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }

        private long FencePricingByPiece(string str)
        {
            var input = str.Split(Environment.NewLine).Select(s => s.ToCharArray()).ToArray();
            var visited = new HashSet<(int, int)>();
            var sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    if (visited.Contains((i, j)))
                        continue;

                    sum += GetPrice(input, i, j, visited);
                }
            }

            return sum;
        }

        private int GetPrice(char[][] input, int i, int j, HashSet<(int, int)> visited)
        {
            var area = 1;
            var plot = 0;
            var region = input[i][j];

            visited.Add((i, j));

            var r = GetAreaAndPlot(region, input, i + 1, j, visited);
            var l = GetAreaAndPlot(region, input, i - 1, j, visited);
            var d = GetAreaAndPlot(region, input, i, j + 1, visited);
            var u = GetAreaAndPlot(region, input, i, j - 1, visited);

            area = area + r.area + l.area + d.area + u.area;
            plot = plot + r.plot + l.plot + d.plot + u.plot;

            return area * plot;
        }

        private (int area, int plot) GetAreaAndPlot(char region, char[][] input, int i, int j, HashSet<(int, int)> visited)
        {
            if (i < 0 || j < 0 || i >= input.Length || j >= input[0].Length)
                return (0, 1);

            if (visited.Contains((i, j)) && input[i][j] == region)
                return (0, 0);

            if (visited.Contains((i, j)) || input[i][j] != region)
                return (0, 1);

            visited.Add((i, j));
            var area = 1;
            var plot = 0;

            var r = GetAreaAndPlot(region, input, i + 1, j, visited);
            var l = GetAreaAndPlot(region, input, i - 1, j, visited);
            var d = GetAreaAndPlot(region, input, i, j + 1, visited);
            var u = GetAreaAndPlot(region, input, i, j - 1, visited);

            area = area + r.area + l.area + d.area + u.area;
            plot = plot + r.plot + l.plot + d.plot + u.plot;

            return (area, plot);
        }

        protected override string PartTwo(object data)
        {
            long sum = 0;
            Stopwatch sw = new();
            if (data is string str)
            {
                sw.Start();

                sum = FencePricingByWall(str);

                sw.Stop();
            }

            return $"Result Part 2: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }

        private long FencePricingByWall(string str)
        {
            var input = str.Split(Environment.NewLine).Select(s => s.ToCharArray()).ToArray();
            var visited = new HashSet<(int, int)>();
            var sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    if (visited.Contains((i, j)))
                        continue;

                    sum += GetPriceByWall(input, i, j, visited);
                }
            }

            return sum;
        }


        private int GetPriceByWall(char[][] input, int i, int j, HashSet<(int, int)> visited)
        {
            var area = 1;
            var walls = 0;
            var region = input[i][j];

            visited.Add((i, j));
            var borders = new List<(int, int)>();

            var r = GetAreaAndWalls(region, input, i + 1, j, visited, borders);
            var l = GetAreaAndWalls(region, input, i - 1, j, visited, borders);
            var d = GetAreaAndWalls(region, input, i, j + 1, visited, borders);
            var u = GetAreaAndWalls(region, input, i, j - 1, visited, borders);

            var orderX = borders.OrderBy(o => o.Item1).ThenBy(o => o.Item2).ToList();
            var orderY = borders.OrderBy(o => o.Item2).ThenBy(o => o.Item1).ToList();
            
            var groupX = orderX.GroupBy(o => o.Item1);
            var groupY = orderY.GroupBy(o => o.Item2);

            foreach (var group in groupX)
            {
                var items = group.ToArray();
                for (int k = 0; k < items.Length - 1; k++)
                {
                    if (Math.Abs(items[k].Item2 - items[k + 1].Item2) == 1)
                    {
                        orderY.Remove(items[k]);
                        orderY.Remove(items[k+1]);
                        continue;
                    }
                }
            }

            foreach (var group in groupY)
            {
                var items = group.ToArray();
                for (int k = 0; k < items.Length - 1; k++)
                {
                    if (Math.Abs(items[k].Item1 - items[k + 1].Item1) == 1)
                    {
                        orderX.Remove(items[k]);
                        orderX.Remove(items[k+1]);  
                        continue;
                    }
                }
            }

            var g1 = orderX.Distinct().GroupBy(x => x.Item1);
            var g2 = orderY.Distinct().GroupBy(x => x.Item2);

            area = area + r + l + d + u;

            walls = g1.Count() + g2.Count();

            return area * walls;
        }
        private int GetAreaAndWalls(char region, char[][] input, int i, int j, HashSet<(int, int)> visited, List<(int, int)> borders)
        {
            if (i < 0 || j < 0 || i >= input.Length || j >= input[0].Length)
            {
                borders.Add((i, j));
                return 0;
            }

            if (visited.Contains((i, j)) && input[i][j] == region)
                return 0;

            if (visited.Contains((i, j)) || input[i][j] != region)
            {
                borders.Add((i, j));
                return 0;
            }

            visited.Add((i, j));
            var area = 1;

            //If i and j stays the same its a line so no increase in plot
            var r = GetAreaAndWalls(region, input, i + 1, j, visited, borders);
            var l = GetAreaAndWalls(region, input, i - 1, j, visited, borders);
            var d = GetAreaAndWalls(region, input, i, j + 1, visited, borders);
            var u = GetAreaAndWalls(region, input, i, j - 1, visited, borders);

            area = area + r + l + d + u;

            return area;
        }
    }
}
