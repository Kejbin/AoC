using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day18 : Day
    {
        public override string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split(Environment.NewLine)
                            .Where(s => !string.IsNullOrEmpty(s))
                            .Select(s => s.Split(' '))
                            .Select(sp => new MoveWithColor(sp[0], sp[1], sp[2]))
                            .ToList();

            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        protected override string PartOne(object data)
        {
            int sum = 0;
            if (data is List<MoveWithColor> input)
            {
                int x = 0;
                int y = 0;
                List<CoordWithColor> coords = new List<CoordWithColor>() { };
                foreach (var item in input)
                {
                    for (int i = 0; i < item.MoveDistance; i++) 
                    {
                        if (item.MoveDirection == 'D')
                            y++;
                        if (item.MoveDirection == 'U')
                            y--;
                        if (item.MoveDirection == 'R')
                            x++;
                        if (item.MoveDirection == 'L')
                            x--;
                        
                        coords.Add(new CoordWithColor(x, y, item.Color));                  
                    }
                }

                //Day 10 Part2 SolutionRequired

                var maxX = coords.Select(x => x.X).Max();
                var minX = coords.Select(x => x.X).Min();
                var maxY = coords.Select(y => y.Y).Max();
                var minY = coords.Select(y => y.Y).Min();

                var xL = maxX - minX;
                var yL = maxY - minY;

                var moveX = 0 - minX;
                var moveY = 0 - minY;

                for (int i = 0; i < yL + 2; i++)
                {
                    for (int j = 0; j < xL + 2; j++)
                    {
                        if (coords.Any(c => c.X + moveX == j && c.Y + moveY == i))
                            Console.Write('#');
                        else
                            Console.Write('.');
                    }

                    Console.Write(Environment.NewLine);
                }
            }

            return $"Result Part 1: {sum}";
        }

        protected override string PartTwo(object data)
        {
            int sum = 0;
            if (data is List<MoveWithColor> input)
            {

            }

            return $"Result Part 2: {sum}";
        }
    }

    public class MoveWithColor
    {
        public MoveWithColor(string direction, string distance, string c)
        {
            Color = ColorTranslator.FromHtml(c.Substring(1, 7));
            MoveDirection = direction[0];
            MoveDistance = Convert.ToInt32(distance);
        }

        public Color Color { get;  private set; }
        public char MoveDirection { get; private set; }
        public int MoveDistance { get; private set; }
    }

    public class CoordWithColor : Coord
    {
        public CoordWithColor(long x, long y, Color c) : base(x, y)
        {
            this.Color = c;
        }

        public Color Color { get; set; }
    }
}
