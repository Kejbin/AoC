using System.Diagnostics;

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
                            .Select(s => s.Split(' '));


            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        protected override string PartOne(object data)
        {
            long sum = 0;
            if (data is IEnumerable<string[]> inp)
            {
                var input = inp.Select(sp => new MoveWithColor(sp[0], sp[1], sp[2]))
                               .ToList();

                sum = CalculateArea(input);
            }

            return $"Result Part 1: {sum}";
        }

        private long CalculateArea(List<MoveWithColor> input)
        {
            int x = 0;
            int y = 0;
            List<Coord> coords = new List<Coord>();
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

                    coords.Add(new Coord(x, y));
                }
            }

            long area = 0;
            var j = coords.Count - 1;

            for (var i = 0; i < coords.Count; i++)
            {
                area += (coords[j].X + coords[i].X) * (coords[j].Y - coords[i].Y);
                j = i;
            }

            var A = Math.Abs(area) / 2;

            return A + 1 - coords.Count / 2 + coords.Count;
        }

        protected override string PartTwo(object data)
        {
            long sum = 0;
            if (data is IEnumerable<string[]> inp)
            {
                var input = inp.Select(sp => new MoveWithColor(sp[0], sp[1], sp[2], true))
                               .ToList();

                sum = CalculateAreaPartTwo(input);
            }

            return $"Result Part 2: {sum}";
        }

        private long CalculateAreaPartTwo(List<MoveWithColor> input) //GOTTA GO FAST ~ 18ms
        {
            var point = new Point(0, 0);
            var lastPoint = new Point(0, 0);

            int count = 0;
            long area = 0;

            foreach (var item in input)
            {
                if (item.MoveDirection == 'D')
                {
                    lastPoint.Y = point.Y + item.MoveDistance - 1;
                    point.Y = point.Y + item.MoveDistance;
                }
                if (item.MoveDirection == 'U')
                {
                    lastPoint.Y = point.Y - item.MoveDistance + 1;
                    point.Y = point.Y - item.MoveDistance;
                }
                if (item.MoveDirection == 'R')
                {
                    lastPoint.X = point.X + item.MoveDistance - 1;
                    point.X = point.X + item.MoveDistance;
                }
                if (item.MoveDirection == 'L')
                {
                    lastPoint.X = point.X - item.MoveDistance + 1;
                    point.X = point.X - item.MoveDistance;
                }

                area += (lastPoint.X + point.X) * (lastPoint.Y - point.Y) * item.MoveDistance;
                count += item.MoveDistance;

                lastPoint = new Point(point.X, point.Y);
            }

            var A = Math.Abs(area) / 2;
            return A + 1 - count / 2 + count;
        }
    }

    public class MoveWithColor
    {
        public MoveWithColor(string direction, string distance, string c, bool isPart2 = false)
        {
            if (isPart2)
            {
                c = c.Substring(1, 7);
                MoveDirection = GetDirection(c.Last());
                MoveDistance = Convert.ToInt32(c.Substring(1, 5), 16);
            }
            else
            {
                MoveDirection = direction[0];
                MoveDistance = Convert.ToInt32(distance);
            }
        }

        public char MoveDirection { get; private set; }
        public int MoveDistance { get; private set; }

        private char GetDirection(char s) => s switch {
            '0' => 'R',
            '1' => 'D',
            '2' => 'L',
            '3' => 'U',
            _ => ' '
        };
    }

    public class Point
    {
        public Point(long x, long y)
        {
            X = x;
            Y = y;
        }

        public long X { get; set; }
        public long Y { get; set; }
    }
}
