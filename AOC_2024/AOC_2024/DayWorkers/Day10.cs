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

namespace AOC_2024.DayWorkers
{
    internal class Day10 : Day
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

                sum = FindTrails(str, false);

                sw.Stop();
            }

            return $"Result Part 1: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }

        private long FindTrails(string str, bool withRating)
        {
            var input = str.Split(Environment.NewLine).Select(l => l.ToCharArray().Select(s => int.Parse(s.ToString())).ToArray()).ToArray();

            var starts = new List<(int, int)>();
            for (int i = 0; i < input.Length; i++)
                for (int j = 0; j < input[0].Length; j++) {
                    if (input[i][j] == 0)
                        starts.Add((i, j));
                }

            var countPaths = 0;
            foreach (var item in starts)
            {
                if(withRating)
                    countPaths += GetPathsWithRating(item, input);
                else
                    countPaths += GetPaths(item, input);
            }


            return countPaths;
        }

        private int GetPathsWithRating((int x, int y) item, int[][] input)
        {
            int paths = 0;
            CheckDirection(input, item.x + 1, item.y, input[item.x][item.y], ref paths);
            CheckDirection(input, item.x - 1, item.y, input[item.x][item.y], ref paths);
            CheckDirection(input, item.x, item.y + 1, input[item.x][item.y], ref paths);
            CheckDirection(input, item.x, item.y - 1, input[item.x][item.y], ref paths);
            return paths;
        }

        private int GetPaths((int x , int y) item, int[][] input)
        {
            HashSet<(int x, int y)> visitedTrailheads = new();
            CheckDirection(input, item.x + 1, item.y, input[item.x][item.y], visitedTrailheads);
            CheckDirection(input, item.x - 1, item.y, input[item.x][item.y], visitedTrailheads);
            CheckDirection(input, item.x, item.y + 1, input[item.x][item.y], visitedTrailheads);
            CheckDirection(input, item.x, item.y - 1, input[item.x][item.y], visitedTrailheads);
            return visitedTrailheads.Count;
        }

        private void CheckDirection(int[][] input, int x, int y, int v, HashSet<(int x, int y)> visitedTrailheads)
        {
            if (x >= input.Length || y >= input[0].Length || x < 0 || y < 0)
                return;

            v++;
            if (input[x][y] != v)
                return;

            if(v == 9)
            {
                if (!visitedTrailheads.Contains((x, y)))
                    visitedTrailheads.Add((x, y));

                return;
            }

            CheckDirection(input, x + 1, y, input[x][y], visitedTrailheads);
            CheckDirection(input, x - 1, y, input[x][y], visitedTrailheads);
            CheckDirection(input, x, y + 1, input[x][y], visitedTrailheads);
            CheckDirection(input, x, y - 1, input[x][y], visitedTrailheads);
        }

        private void CheckDirection(int[][] input, int x, int y, int v, ref int paths)
        {
            if (x >= input.Length || y >= input[0].Length || x < 0 || y < 0)
                return;

            v++;
            if (input[x][y] != v)
                return;

            if (v == 9)
            {
                paths++;
                return;
            }

            CheckDirection(input, x + 1, y, input[x][y], ref paths);
            CheckDirection(input, x - 1, y, input[x][y], ref paths);
            CheckDirection(input, x, y + 1, input[x][y], ref paths);
            CheckDirection(input, x, y - 1, input[x][y], ref paths);
        }

        protected override string PartTwo(object data)
        {
            long sum = 0;
            Stopwatch sw = new();
            if (data is string str)
            {
                sw.Start();

                sum = FindTrails(str, true);

                sw.Stop();
            }

            return $"Result Part 2: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }
    }
}
