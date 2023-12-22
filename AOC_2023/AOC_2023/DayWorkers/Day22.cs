using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;

namespace AOC_2023.DayWorkers;

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

        Dictionary<int, List<(int, int, int)>> bricks = new();
        int id = 0;
        foreach (var c in input)
        {
            id++;
            var start = c.First();
            var end = c.Last();
            List<(int, int, int)> cubes = new();
            for (var x = start[0]; x <= end[0]; x++)
            {
                for (var y = start[1]; y <= end[1]; y++)
                {
                    for (var z = start[2]; z <= end[2]; z++)
                    {
                        cubes.Add((x, y, z));
                    }
                }
            }

            bricks.Add(id, cubes.OrderByDescending(o => o.Item3).ToList());
        }

        //Order by Z
        bricks = bricks.OrderBy(b => b.Value.Last().Item3).ToDictionary();

        return PartOne(bricks) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
    }

    protected override string PartOne(object data)
    {
        //https://www.desmos.com/3d?lang=pl
        int sum = 0;
        if (data is Dictionary<int, List<(int x, int y, int z)>> bricks)
        {
            var dependencies = MoveAndBuildStack(bricks);
            var test = new List<KeyValuePair<int, (List<int> Supports, List<int> IsSupportedBy)>>();
            // 469 < ? < 544
            foreach (var item in dependencies)
            {
                if (item.Value.IsSupportedBy.Count == 0)
                {
                    test.Add(item);
                    continue;
                }

                if (item.Value.Supports.Count == 0 
                 || item.Value.Supports.All(s =>  dependencies[s].IsSupportedBy.SkipWhile(sw => sw == item.Key).Count() > 0))
                    sum++;
                else
                    test.Add(item);
            }
        }

        return $"Result Part 1: {sum}";
    }

    private Dictionary<int, (List<int> Supports, List<int> IsSupportedBy)> MoveAndBuildStack(Dictionary<int, List<(int x, int y, int z)>> bricks)
    {
        var references = new Dictionary<int, (List<int> Supports, List<int> IsSupportedBy)>();
        var occupied = new Dictionary<(int x, int y, int z), int>();
        foreach (var brick in bricks)
        {
            if (brick.Value.Any(a => a.z == 0))
                continue;

            //Find lowest possible place to move, so check for all coordinates which is max that can go at 'z' axle
            var diffZ = 0;
            var listZ = new List<int>();
            foreach (var coords in brick.Value)
            {
                for (int i = brick.Value.Last().z - 1; i >= -1; i--)
                {
                    //If that coord is add previous position to list;
                    if (i == -1 || occupied.ContainsKey((coords.x, coords.y, i)))
                    {
                        listZ.Add(diffZ);
                        break;
                    }

                    diffZ++;
                }

                diffZ = 0;
            }

            diffZ = listZ.Min();

            //Move down
            bricks[brick.Key] = brick.Value.Select(v => (v.x, v.y, v.z - diffZ)).ToList();
            bricks[brick.Key].ForEach(b => occupied.Add(b, brick.Key));
        }

        //Fill references
        foreach (var brick in bricks)
        {
            references.Add(brick.Key, (new List<int>(), new List<int>()));
            foreach (var item in bricks[brick.Key])
            {
                if (occupied.ContainsKey((item.x, item.y, item.z + 1)) && !bricks[brick.Key].Contains((item.x, item.y, item.z + 1)))
                {
                    var supports = occupied[(item.x, item.y, item.z + 1)];

                    if (!references[brick.Key].Supports.Contains(supports))
                            references[brick.Key].Supports.Add(supports);            
                }

                if (occupied.ContainsKey((item.x, item.y, item.z - 1)) && !bricks[brick.Key].Contains((item.x, item.y, item.z - 1)))
                {
                    var supporter = occupied[(item.x, item.y, item.z - 1)];

                    if (!references[brick.Key].IsSupportedBy.Contains(supporter))
                        references[brick.Key].IsSupportedBy.Add(supporter);
                }
            }
        }

        return references;
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
