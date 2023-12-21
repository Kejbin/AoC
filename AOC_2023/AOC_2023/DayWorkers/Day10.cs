using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AOC_2023.DayWorkers
{
    internal class Day10 : Day
    {
        private (int X, int Y) _start;
        private List<(int x, int y)> _loop = new List<(int x, int y)>();

        public override string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split(Environment.NewLine)
                            .Where(s => !string.IsNullOrEmpty(s))
                            .Select(s => s.ToCharArray())
                            .ToList();


            var line = input.First(f => f.Contains('S'));

            _start.Y = input.IndexOf(line);
            _start.X = Array.IndexOf(line, 'S');

            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        protected override string PartOne(object data)
        {
            int steps = 0;
            if (data is List<char[]> input)
            {
                //Scan start path
                var moves = new List<(int x, int y)> { (1, 0), (-1, 0), (0, 1), (0, -1) };
                for (int i = 0; i < 4; i++)
                {
                    var x = moves[i].x + _start.X;
                    var y = moves[i].y + _start.Y;

                    var symb = input[y][x];
                    if (_start.X > x && (symb != '-' && symb != 'F' && symb != 'L' || symb == '.'))
                        continue;
                    if (_start.X < x && (symb != '-' && symb != '7' && symb != 'J' || symb == '.'))
                        continue;
                    if (_start.Y > y && (symb != '|' && symb != 'F' && symb != '7' || symb == '.'))
                        continue;
                    if (_start.Y < y && (symb != '|' && symb != 'J' && symb != 'L' || symb == '.'))
                        continue;

                    _loop.Clear();
                    if (Move(input, x, y, _start.X, _start.Y, ref steps))
                        break;

                    steps = 0;
                }
            }

            return $"Result Part 1: {(steps + 1) / 2 }";
        }

        private bool Move(List<char[]> input, int x, int y, int lastX, int lastY, ref int steps)
        {
            while (input[y][x] != 'S') 
            {
                steps++;
                _loop.Add((x, y));
                if (x < 0 || y < 0 || y >= input.Count || input[0].Length <= x || input[y][x] == '.')
                    return false;

                var newX = x;
                var newY = y;

                if (input[y][x] == '|')
                {
                    if (y > lastY)
                        newY = y + 1;
                    else
                        newY = y - 1;
                }
                else if (input[y][x] == '-')
                {
                    if (x > lastX)
                        newX = x + 1;
                    else
                        newX = x - 1;
                }
                else if (input[y][x] == 'L')
                {
                    if (x != lastX)
                        newY = y - 1;
                    else
                        newX = x + 1;
                }
                else if (input[y][x] == 'J')
                {
                    if (x != lastX)
                        newY = y - 1;
                    else
                        newX = x - 1;
                }
                else if (input[y][x] == '7')
                {
                    if (x != lastX)
                        newY = y + 1;
                    else
                        newX = x - 1;
                }
                else if (input[y][x] == 'F')
                {
                    if (x != lastX)
                        newY = y + 1;
                    else
                        newX = x + 1;
                }

                lastX = x;
                lastY = y;
                x = newX;
                y = newY;
            }

            return true;
        }

        protected override string PartTwo(object data)
        {
            int sum;
            var area = 0;
            var j = _loop.Count - 1;

            for (var i = 0; i < _loop.Count; i++)
            {
                area += (_loop[j].x + _loop[i].x) * (_loop[j].y - _loop[i].y);
                j = i;
            }

            area = Math.Abs(area) / 2;

            //Pick's theorem //Thanks again to programing Guru
            sum = area + 1 - _loop.Count / 2; //Somehow for input from file it's to high by 1;

            return $"Result Part 2: {sum}";
        }
    }
}
