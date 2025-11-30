using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC_2024.DayWorkers
{
    internal class Day1 : Day
    {
        public override string Execute(string data)
        {
            return PartOne(data) + "\r\n" + PartTwo(data);
        }

        protected override string PartOne(object data)
        {
            int sum = 0;
            if (data is string str)
            {
                var (list1, list2) = GetLists(str);
                for (int i = 0; i < list1.Length; i++)
                    sum += Math.Abs(list1[i] - list2[i]);
            }

            return $"Result Part 1: {sum}";

        }

        private (int[] list1, int[] list2) GetLists(string str)
        {
            var input = str.Split(Environment.NewLine)
                        .Where(s => !string.IsNullOrWhiteSpace(s))
                        .Select(r => r.Split("   "))
                        .Select(l => (int.Parse(l[0]), int.Parse(l[1])));

            var list1 = input.Select(i => i.Item1).OrderBy(o => o).ToArray();
            var list2 = input.Select(i => i.Item2).OrderBy(o => o).ToArray();

            return (list1, list2);
        }

        protected override string PartTwo(object data)
        {
            int sum = 0;
            if (data is string str)
            {
                var (list1, list2) = GetLists(str);

                var repeated = new Dictionary<int, int>();
                for (int i = 0; i < list1.Length; i++)
                {
                    int count = 0;
                    if (repeated.TryGetValue(list1[i], out count))
                    {
                        sum += count;
                        continue;
                    }

                    count = list2.Where(w => w == list1[i]).Count();
                    var score = list1[i] * count;
                    repeated.Add(list1[i], score);

                    sum += score;
                }
            }

            return $"Result Part 2: {sum}";
        }
    }
}
