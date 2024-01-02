using System.Diagnostics;
using System.Numerics;
using System.Runtime.Intrinsics;

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
            var v1 = new Vector2(hail1.Position.X, hail1.Position.Y); //Moving Object
            var v2 = new Vector2(hail1.Velocity.X, hail1.Velocity.Y); //Vector
            var v3 = new Vector2((float)x, (float)y);                 //Relative point

            var v4 = v3 - v1; // Relative point vector - Moving Object vector

            /*
            Vector dot product if larger than 0 points are moving towards so colision with that point will occure in future
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
            // 808107736732974 < 808107747214045 < ?
            long sum = 0;
            if (data is List<Hail> input)
            {
                //https://www.reddit.com/r/adventofcode/comments/18pnycy/comment/kersplf/?utm_source=share&utm_medium=web2x&context=3
                //Get 3 lines that never cross
                var p1 = new Vector3(input[0].Position.X, input[0].Position.Y, input[0].Position.Z);
                var v1 = new Vector3(input[0].Velocity.X, input[0].Velocity.Y, input[0].Velocity.Z);
                Vector3 p2 = new Vector3();
                Vector3 v2 = new Vector3();
                Vector3 p3 = new Vector3();
                Vector3 v3 = new Vector3();
                var i = 1;
                while (i < input.Count)
                {

                    v2 = new Vector3(input[i].Velocity.X, input[i].Velocity.Y, input[i].Velocity.Z);
                    if (ExistIntersection(v1, v2))
                    {
                        p2 = new Vector3(input[i].Position.X, input[i].Position.Y, input[i].Position.Z);
                        break;
                    }

                    i++;
                }

                while (i < input.Count)
                {
                    v3 = new Vector3(input[i].Velocity.X, input[i].Velocity.Y, input[i].Velocity.Z);
                    if (ExistIntersection(v1, v3) && ExistIntersection(v2, v3))
                    {
                        p3 = new Vector3(input[i].Position.X, input[i].Position.Y, input[i].Position.Z);
                        break;
                    }

                    i++;
                }

                var (a, A) = FindPlane(p1,v1, p2, v2);
                var (b, B) = FindPlane(p1, v1, p3, v3);
                var (c, C) = FindPlane(p2, v2, p3, v3);

                var w = Lin(A, Vector3.Cross(b, c), B, Vector3.Cross(c, a), C, Vector3.Cross(a, b));
                var t = Dot(a, Cross(b, c));
                var nw = new Vector3((float)Math.Round(w.X/t), (float)Math.Round(w.Y/t), (float)Math.Round(w.Z/t));

                var w1 = Vector3.Subtract(v1, nw);
                var w2 = Vector3.Subtract(v2, nw);
                var ww = Vector3.Cross(w1, w2);

                var E = Vector3.Dot(ww, Vector3.Cross(p2, w2));
                var F = Vector3.Dot(ww, Vector3.Cross(p1, w1));
                var G = Vector3.Dot(p1, ww);
                var S = Vector3.Dot(ww, ww);

                var rock = Lin(E, w1, -F, w2, G, ww);

                sum = (long)((rock.X + rock.Y + rock.Z)/S);
            }

            return $"Result Part 2: {sum}";
        }

        private bool ExistIntersection(Vector3 v1, Vector3 v2)
        {
            var v = Vector3.Cross(v1, v2);

            return v.X != 0 || v.Y != 0 || v.Z != 0;
        }

        private (Vector3, float) FindPlane(Vector3 p1, Vector3 v1, Vector3 p2, Vector3 v2)
        {
            var p12 = Vector3.Subtract(p1, p2);
            var v12 = Vector3.Subtract(v1, v2);
            var vv = Vector3.Cross(v1, v2);

            return (Vector3.Cross(p12, v12), Vector3.Dot(p12, vv));
        }

        private (double X, double Y, double Z) Lin(double r, Vector3 a, double s, Vector3 b, double t, Vector3 c) 
        {
            var x = r * a.X + s * b.X + t * c.X;
            var y = r * a.Y + s * b.Y + t * c.Y;
            var z = r * a.Z + s * b.Z + t * c.Z;
            return (x, y, z);
        }

        private double Dot(Vector3 a, (double X, double Y, double Z) b) => a.X* b.X + a.Y* b.Y + a.Z* b.Z;
        private (double X, double Y, double Z) Cross(Vector3 a, Vector3 b) => (a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
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
