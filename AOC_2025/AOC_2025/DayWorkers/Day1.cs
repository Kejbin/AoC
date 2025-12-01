using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2025.DayWorkers
{
    internal class Day1 : Day
    {
        public override string Execute(string data)
        {
            var moves = data.ToString().Split(Environment.NewLine).Where(w => !string.IsNullOrEmpty(w)).Select(s => (s[0], int.Parse(s.Substring(1))));

            var pos = 50;
            int password = 0;
            int passed0 = 0;
            foreach (var item in moves)
            {
                var move = item.Item1;
                var range = item.Item2;
                while (range > 100)
                {
                    range -= 100;
                    passed0++;
                }

                if (move == 'R')
                {
                    if (pos + range == 100)
                        pos = 0;
                    else if (pos + range > 99)
                    {
                        if (pos != 0)
                            passed0++;
                        pos = Math.Abs(pos + range - 100);
                    }
                    else
                        pos += range;
                }

                if (move == 'L')
                {
                    if (pos - range == 0)
                        pos = 0;
                    else if (pos - range < 0)
                    {
                        if (pos != 0)
                            passed0++;
                        pos = 100 - Math.Abs(pos - range);
                    }
                    else
                        pos -= range;
                }

                if (pos == 0)
                    password++;
            }

            return PartOne(password) + "\r\n" + PartTwo(passed0 + password);
        }

        protected override string PartOne(object data)
        {
            return "Part one: " + data;
        }

        protected override string PartTwo(object data)
        {
            return "Part day: " + data;
        }
    }
}
