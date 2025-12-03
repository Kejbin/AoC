using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2025.DayWorkers
{
    internal class Day3 : Day
    {
        public override string Execute(string data)
        {
            var ranges = data.ToString()
                            .Split(Environment.NewLine)
                            .Where(w => !string.IsNullOrEmpty(w))
                            .Select(s => s.Select(ss => int.Parse(ss.ToString())).ToList());
 

            return PartOne(ranges) + "\r\n" + PartTwo(ranges);
        }

        protected override string PartOne(object data)
        {
            var ranges = data as IEnumerable<List<int>>;
            if (ranges is null)
                return "";

            long response = 0;
            foreach (var range in ranges)
            {
                var largest1 = 0;
                var largest2 = range[range.Count - 1];
                var index = range.Count;
                for (var i = 0; i < range.Count - 1; i++)
                    if (largest1 < range[i])
                        largest1 = range[i];

                for (var i = range.IndexOf(largest1) + 1; i < range.Count - 1; i++)
                    if (largest2 < range[i])
                        largest2 = range[i];

                var temp = $"{largest1}{largest2}";
                response += int.Parse(temp);
            }

            return "Part one: " + response;
        }

        protected override string PartTwo(object data)
        {
            var ranges = data as IEnumerable<List<int>>;
            if (ranges is null)
                return "";

            long response = 0;
            foreach (var range in ranges)
            {
                var arr = new int[12];
                var nextIndex = 0;
                var previousIndex = 0;
                for (var j = 0; j < 12; j++)
                {
                    previousIndex = nextIndex;
                    var maxIndex = range.Count - (12 - j);

                    for (var i = nextIndex; i < range.Count; i++) {
                        if (arr[j] < range[i])
                        {
                            arr[j] = range[i];
                            nextIndex = i + 1;
                        }

                        if ( i == maxIndex)
                            break;
                    }
                }

                var temp = long.Parse(string.Join("", arr.Select(s => s.ToString())));
                response += temp;
            }

            return "Part day: " + response;
        }
    }
}
