using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day22 : Day
    {
        public override string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split(Environment.NewLine)
                            .Where(s => !string.IsNullOrEmpty(s))
                            .Select(s => s.Split('~')
                                          .Select(ss => ss.Split(',')
                                                          .Select(sss => Convert.ToInt32(sss))
                                                          .ToList())
                                          .ToList())
                            .ToList();

            List<(int, List<(int, int, int)>)> bricks = new();
            int id = 0;
            foreach (var c in input)
            {
                id++;
                var start = c.First();
                var end = c.Last();
                List<(int, int, int)> cubes = new();
                for(var i = start[0]; i <= end[0]; i++) 
                {
                    for (var j = start[1]; j <= end[1]; j++)
                    {
                        for (var k = start[2]; k <= end[2]; k++)
                        {
                            cubes.Add((i, j, k));
                        }
                    }
                }

                bricks.Add((id, cubes));
            }

            return PartOne(bricks) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        protected override string PartOne(object data)
        {
            //https://www.desmos.com/3d?lang=pl
            int sum = 0;
            if (data is List<(int Id, List<(int x, int y, int z)> Brick)> bricks)
            {
                List<(int Id, List<int> References, List<int> Ref2)> dependencies = new();
                foreach (var item in bricks)
                {
                    var depsUp = bricks.Where(b => b.Brick.Any(cc => item.Brick.Any(c => c.x == cc.x
                                                                                      && c.y == cc.y
                                                                                      && c.z < cc.z)
                                                                                    && item.Id != b.Id));

                    var depsDown = bricks.Where(b => b.Brick.Any(cc => item.Brick.Any(c => c.x == cc.x
                                                                                        && c.y == cc.y
                                                                                        && c.z > cc.z)
                                                                                        && item.Id != b.Id));

                    dependencies.Add((item.Id, depsUp.OrderBy(o => o.Brick.Select(z => z.z).Min()).Select(s => s.Id).ToList(), depsDown.OrderByDescending(o => o.Brick.Select(z => z.z).Min()).Select(s => s.Id).ToList()));
                }

                //Find where the 
                foreach (var item in dependencies)
                {
                    foreach (var id in item.References.ToList())
                    {
                        var dep = dependencies.First(f => f.Id == id);
                        //if()
                    }
                }


                //Caluclate blocks that could be removed
                foreach (var item in dependencies)
                {
                    if (!dependencies.Any(d => d.References.Contains(item.Id)))
                        continue;

                    if (item.References.Count == 0)
                        sum++;

                    if (item.References.Any(r => dependencies.Any(dr => dr.References.Contains(r) && item.Id != dr.Id)))
                        sum++;
                }
            }

            return $"Result Part 1: {sum}";
        }

        protected override string PartTwo(object data)
        {
            int sum = 0;
            if (data is List<(string Springs, List<int> DamagedSpringsNumbers)> input)
            {

            }

            return $"Result Part 2: {sum}";
        }
    }
}
