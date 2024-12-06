using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC_2024.DayWorkers
{
    internal class Day6 : Day
    {
        public override string Execute(string data)
        {
            return PartOne(data) + "\r\n" + PartTwo(data);
        }

        protected override string PartOne(object data)
        {
            int sum = 0;
            Stopwatch sw = new();
            if (data is string str)
            {
                sw.Start();

                sum = GetGuardRoute(str);

                sw.Stop();
            }            
           
            return $"Result Part 1: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }

        private int GetGuardRoute(string str)
        {
            var map = str.Split(Environment.NewLine).Select(s => s.ToCharArray()).ToArray();
            Pos pos = new Pos();

            //Search for guard initial position
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == '^')
                    {
                        pos = new Pos(j,i);
                        i = map.Length;
                        break;
                    }
                }

            var end = false;
            HashSet<Pos> visited = new HashSet<Pos>() { pos };

            var x = pos.X;
            var y = pos.Y;

            var posNextMove = new Pos(0, -1);
            Pos newPos = pos;
            while (true)
            {
                newPos = new Pos(newPos.X + posNextMove.X, newPos.Y + posNextMove.Y);

                if (!visited.Contains(newPos))
                    visited.Add(newPos);

                if (newPos.Y + posNextMove.Y >= map.Length || newPos.Y + posNextMove.Y < 0 || newPos.X + posNextMove.X < 0 || newPos.X + posNextMove.X >= map[0].Length)
                    break;

                if (map[newPos.Y + posNextMove.Y][newPos.X + posNextMove.X] == '#')
                {
                    posNextMove = ChangeRight(posNextMove);
                }

            }

            return visited.Count;
        }

        private Pos ChangeRight(Pos posNextMove)
        {
            if (posNextMove.Y == - 1)
                return new Pos(1, 0);
            if (posNextMove.Y == 1)
                return new Pos(- 1, 0);
            if (posNextMove.X == 1)
                return new Pos(0, 1);
            else
                return new Pos(0, -1);
        }

        protected override string PartTwo(object data)
        {
            int sum = 0;
            Stopwatch sw = new();
            if (data is string str)
            {
                sw.Start();
                sum = CountLoops(str);
                sw.Stop();
            }

            return $"Result Part 2: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }

        private int CountLoops(string str)
        {
            var map = str.Split(Environment.NewLine).Select(s => s.ToCharArray()).ToArray();
            Pos pos = new Pos();

            //Search for guard initial position
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == '^')
                    {
                        pos = new Pos(j, i);
                        i = map.Length;
                        break;
                    }
                }

            var end = false;
            HashSet<Pos> visited = new HashSet<Pos>() { pos };

            var x = pos.X;
            var y = pos.Y;

            var posNextMove = new Pos(0, -1);
            Pos newPos = pos;
            while (true)
            {
                newPos = new Pos(newPos.X + posNextMove.X, newPos.Y + posNextMove.Y);

                if (!visited.Contains(newPos))
                    visited.Add(newPos);

                if (newPos.Y + posNextMove.Y >= map.Length || newPos.Y + posNextMove.Y < 0 || newPos.X + posNextMove.X < 0 || newPos.X + posNextMove.X >= map[0].Length)
                    break;

                if (map[newPos.Y + posNextMove.Y][newPos.X + posNextMove.X] == '#')
                {
                    posNextMove = ChangeRight(posNextMove);
                }

            }

            return visited.Count;
        }

        struct Pos
        {
            public Pos(int x, int y)
            {
                X= x; 
                Y = y;
            }

            public int X { get; private set; }
            public int Y { get; private set; }
        }
    }
}
