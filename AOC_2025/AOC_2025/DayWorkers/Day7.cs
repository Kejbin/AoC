using System.Linq;

namespace AOC_2025.DayWorkers
{
    internal class Day7 : Day
    {
        public override string Execute(string data)
        {
            return PartOne(data) + "\r\n" + PartTwo(data);
        }

        protected override string PartOne(object data)
        {
            if (data == null)
                return "";

            var teleporterMap = data.ToString().Split(Environment.NewLine).Select(s => s.ToList()).ToList();
            var start = teleporterMap[0].IndexOf('S');

            var q = new Queue<(int, int)>();
            var beamSplits = new HashSet<(int, int)>();
            q.Enqueue((0, start));
            while (q.Count > 0)
            {
                var item = q.Dequeue();
                for (int i = item.Item1 + 1; i < teleporterMap.Count; i++)
                {
                    if (beamSplits.Contains((i, item.Item2)))
                        break;

                    if (teleporterMap[i][item.Item2] == '^')
                    {
                        if (item.Item2 - 1 > 0)
                            q.Enqueue((i, item.Item2 - 1));

                        if (item.Item2 + 1 < teleporterMap[0].Count)
                            q.Enqueue((i, item.Item2 + 1));

                        if (!beamSplits.Contains((i, item.Item2)))
                            beamSplits.Add((i, item.Item2));

                        break;
                    }
                }

            }

            return "Part one: " + beamSplits.Count;
        }

        protected override string PartTwo(object data)
        {
            if (data == null)
                return "";

            var teleporterMap = data.ToString().Split(Environment.NewLine).Where(w => w.Any(a => a != '.')).Select(s => s.ToList()).ToList();
            var start = teleporterMap[0].IndexOf('S');
            var pascalTriangle = new ulong[teleporterMap.Count, teleporterMap[0].Count];
            pascalTriangle[0, start] = 1;

            for (int i = 1; i < teleporterMap.Count; i++)
            {
                for (int j = 0; j < teleporterMap[0].Count; j++)
                {
                    if (teleporterMap[i][j] == '^')
                    {
                        var left = j - 1;
                        if (left >= 0)
                            pascalTriangle[i, left] += pascalTriangle[i - 1, j];

                        var right = j + 1;
                        if (right < teleporterMap[0].Count)
                            pascalTriangle[i, right] += pascalTriangle[i - 1, j];
                    }
                    else
                        pascalTriangle[i, j] += pascalTriangle[i - 1, j];
                }
            }

            var sum = 0UL;
            for (int i = 0; i < pascalTriangle.GetLength(1); i++)
                sum += pascalTriangle[pascalTriangle.GetLength(0) - 1, i];


            return "Part two: " + sum;
        }
    }
}

