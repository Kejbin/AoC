using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2025.DayWorkers
{
    internal class Day5 : Day
    {
        public override string Execute(string data)
        { 
            return PartOne(data) + "\r\n" + PartTwo(data);
        }

        protected override string PartOne(object data)
        {
            var splitedTables = data.ToString()
                .Split(Environment.NewLine + Environment.NewLine)
                .ToArray();

            var freshRanges = splitedTables[0].Split(Environment.NewLine)
                                              .Select(s => s.Split('-')
                                                            .Select(ss => long.Parse(ss)).ToArray());

            var availabledIngredients = splitedTables[1].Split(Environment.NewLine)
                                                        .Select(s => long.Parse(s));

            var fresh = 0;
            foreach (var ingridient in availabledIngredients)
            {
                foreach (var range in freshRanges)
                {
                    if (ingridient >= range[0] && ingridient <= range[1])
                    {
                        fresh++;
                        break;
                    }
                }
            }

            return "Part one: " + fresh;
        }

        protected override string PartTwo(object data)
        {
            var splitedTables = data.ToString()
                                    .Split(Environment.NewLine + Environment.NewLine)
                                    .ToArray();

            var freshRanges = splitedTables[0].Split(Environment.NewLine)
                                              .Select(s => s.Split('-')
                                                            .Select(ss => long.Parse(ss)).ToList()).ToList();

            for (var i = 0; i < freshRanges.Count; i++)
                for (var j = 0; j < freshRanges.Count; j++)
                {
                    if (i == j)
                        continue;

                    var r1 = freshRanges[i];
                    var r2 = freshRanges[j];

                    //Smarter solution:
                    //var lo = Math.Max(r1[0], r2[0]);
                    //var hi = Math.Min(r1[1], r2[1]);

                    //if (lo <= hi)

                    if (r1[0] <= r2[0] && r1[0] <= r2[1] && r1[1] >= r2[0] && r1[1] <= r2[1]
                        || r1[0] >= r2[0] && r1[0] <= r2[1] && r1[1] >= r2[0] && r1[1] >= r2[1]
                        || r1[0] <= r2[0] && r1[0] <= r2[1] && r1[1] >= r2[0] && r1[1] >= r2[1]
                        || r1[0] >= r2[0] && r1[0] <= r2[1] && r1[1] >= r2[0] && r1[1] <= r2[1])
                    {
                        var r3 = r1.Concat(r2);
                        var range = new List<long>
                        {
                            r3.Min(),
                            r3.Max()
                        };

                        if (i > j)
                        {
                            freshRanges.RemoveAt(i);
                            freshRanges.RemoveAt(j);
                        }
                        else
                        {
                            freshRanges.RemoveAt(j);
                            freshRanges.RemoveAt(i);
                        }

                        freshRanges.Add(range);
                        i = 0;
                    }

                }

            return "Part day: " + freshRanges.Sum(s => s[1] - s[0] + 1);
        }
    }
}
