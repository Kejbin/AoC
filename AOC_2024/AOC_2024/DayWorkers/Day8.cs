using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC_2024.DayWorkers
{
    internal class Day8 : Day
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

                sum = CountAntinodes(str);

                sw.Stop();
            }            
           
            return $"Result Part 1: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }

        private long CountAntinodes(string str)
        {
            var input = str.Split(Environment.NewLine).Select(s => s.ToCharArray()).ToArray();
            var antenas = new Dictionary<char, List<(int x, int y)>>();

            var y = input.Length;
            var x = input[0].Length;

            for (int i = 0; i < y; i++)
                for (var j = 0; j < x; j++)
                {
                    if (input[j][i] == '.')
                        continue;

                    if (antenas.TryGetValue(input[j][i], out List<(int, int)> coords))
                        coords.Add((j, i));
                    else
                        antenas.Add(input[j][i], new List<(int, int)> { (j,i) });
                }

            HashSet<(int, int)> antinodes = new();
            foreach (var coords in antenas.Values)
            {
                for (int i = 0; i < coords.Count - 1;i++)
                    for (int j = i + 1; j < coords.Count; j++)
                    {
                        (int x, int y) v = (coords[i].x - coords[j].x, coords[i].y - coords[j].y);

                        (int x, int y) p1 = (coords[i].x + v.x, coords[i].y + v.y);
                        (int x, int y) p2 = (coords[j].x - v.x, coords[j].y - v.y);

                        if (!antinodes.Contains(p1) && (p1.x >= 0 && p1.x < x && p1.y >= 0 && p1.y < y))
                            antinodes.Add(p1);

                        if (!antinodes.Contains(p2) && (p2.x >= 0 && p2.x < x && p2.y >= 0 && p2.y < y))
                            antinodes.Add(p2);
                    }
            }


            return antinodes.Count;
        }

        protected override string PartTwo(object data)
        {
            long sum = 0;
            Stopwatch sw = new();
            if (data is string str)
            {
                sw.Start();

                sum = CountAntinodesInLine(str);

                sw.Stop();
            }

            return $"Result Part 2: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }

        private long CountAntinodesInLine(string str)
        {
            var input = str.Split(Environment.NewLine).Select(s => s.ToCharArray()).ToArray();
            var antenas = new Dictionary<char, List<(int x, int y)>>();

            var y = input.Length;
            var x = input[0].Length;

            for (int i = 0; i < y; i++)
                for (var j = 0; j < x; j++)
                {
                    if (input[j][i] == '.')
                        continue;

                    if (antenas.TryGetValue(input[j][i], out List<(int, int)> coords))
                        coords.Add((j, i));
                    else
                        antenas.Add(input[j][i], new List<(int, int)> { (j, i) });
                }

            HashSet<(int, int)> antinodes = new(antenas.SelectMany(s => s.Value).Distinct());
            foreach (var coords in antenas.Values)
            {
                for (int i = 0; i < coords.Count - 1; i++)
                    for (int j = i + 1; j < coords.Count; j++)
                    {
                        (int x, int y) v = (coords[i].x - coords[j].x, coords[i].y - coords[j].y);

                        (int x, int y) p1 = (coords[i].x + v.x, coords[i].y + v.y);
                        (int x, int y) p2 = (coords[j].x - v.x, coords[j].y - v.y);

                        while ((p1.x >= 0 && p1.x < x && p1.y >= 0 && p1.y < y))
                        {
                            if (!antinodes.Contains(p1))
                                antinodes.Add(p1);

                            p1 = (p1.x + v.x, p1.y + v.y);
                        }

                        while ((p2.x >= 0 && p2.x < x && p2.y >= 0 && p2.y < y))
                        {
                            if (!antinodes.Contains(p2))
                                antinodes.Add(p2);

                            p2 = (p2.x - v.x, p2.y - v.y);
                        }
                    }
            }

            return antinodes.Count;
        }
    }
}
