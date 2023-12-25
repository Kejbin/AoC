using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace AOC_2023.DayWorkers
{
    internal class Day24 : Day
    {

        public override string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split(Environment.NewLine)
                            .Where(s => !string.IsNullOrEmpty(s))
                            .Select(s => s.Split(" @ ")
                                          .SelectMany(sm => sm.Split(',')
                                                              .Select(s => Convert.ToInt64(s.Trim())))
                                          .ToList())                                   
                            .Select(sm => new Hail(sm[0], sm[1], sm[2], sm[3], sm[4], sm[5]))
                            .ToList();

            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        protected override string PartOne(object data)
        {
            int sum = 0;
            if (data is List<Hail> input)
            {
                for (int i = 0; i < input.Count - 1; i++)
                {
                    if (input[i].LineRealNumbers is null)
                        input[i].LineRealNumbers = FindLinearEquation(input[i]);

                    for (int j = i + 1; j < input.Count; j++)
                    {
                        if (input[j].LineRealNumbers is null)
                            input[j].LineRealNumbers = FindLinearEquation(input[j]);

                        if ((input[i].LineRealNumbers.A - input[j].LineRealNumbers.A) == 0) // Lines never intersect or they have infinity amount of common points
                            continue;

                        var x = (input[j].LineRealNumbers.B - input[i].LineRealNumbers.B) / (input[i].LineRealNumbers.A - input[j].LineRealNumbers.A); //(d−b)/(a−c)
                        var y = (input[i].LineRealNumbers.A * input[j].LineRealNumbers.B - input[i].LineRealNumbers.B * input[j].LineRealNumbers.A) / (input[i].LineRealNumbers.A - input[j].LineRealNumbers.A); // (ad−ab)/(a−c)

                        if (InRange(x, y) && DirectionCheck(x, y, input[i]) && DirectionCheck(x, y, input[j]))
                        {
                            sum++;
                        }
                    }
                }
            }

            return $"Result Part 1: {sum}";
        }

        private bool DirectionCheck(double x, double y, Hail hail1)
        {
            //Check if after velocity change point is closer or further than intersection point
            //Compare if point hail starts outside of intersection so for line exists but not for that line segment
            var v1 = new Vector2 (hail1.Position.X, hail1.Position.Y); //Moving Object
            var v2 = new Vector2 (hail1.Velocity.X, hail1.Velocity.Y); //Vector
            var v3 = new Vector2 ((float)x, (float)y);                 //Relative point

            var v4 = v3 - v1; // Relative point vector - Moving Object vector

            /*
            Vector dot product if larger than 0 points are moving towards so colision with that point will ocure in future
            if product is 0 or lower they are moving away from each other so that mean points already crossed in past.
            */
            return Vector2.Dot(v4, v2) > 0; 
        }

        const long Lowest = 200000000000000;
        const long Highest = 400000000000000;
        private bool InRange(double x, double y)
        {
            if (x < Lowest || x > Highest || y < Lowest || y > Highest)
                return false;

            return true;
        }

        private LineRealNumbers FindLinearEquation(Hail h)
        {
            (double x, double y) p1 = (h.Position.X, h.Position.Y);
            (double x, double y) p2 = (h.Position.X + h.Velocity.X, h.Position.Y + h.Velocity.Y);

            var a = (p1.y - p2.y) / (p1.x - p2.x);
            var b = p1.y - p1.x * a;

            return new LineRealNumbers { A = a, B = b };
        }
        

        protected override string PartTwo(object data)
        {
            int sum = 0;
            if (data is List<Hail> input)
            {

            }

            return $"Result Part 2: {sum}";
        }
    }

    public class Hail
    {
        public Hail(long px, long py, long pz, long vx, long vy, long vz)
        {
            Velocity = new Point3D { X = vx, Y = vy, Z = vz };
            Position = new Point3D { X = px, Y = py, Z = pz };
        }

        public Point3D Velocity { get; set; }
        public Point3D Position { get; set; }
        public LineRealNumbers LineRealNumbers { get; set; }
    }

    public class LineRealNumbers
    {
        public double A { get; set; }
        public double B { get; set; }
    }

    public struct Point3D
    {
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }
    }
}
