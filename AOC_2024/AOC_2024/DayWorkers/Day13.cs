using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AOC_2024.DayWorkers
{
    internal class Day13 : Day
    {
        public override string Execute(string data)
        {
            return PartOne(data) + "\r\n" + PartTwo(data);
        }

        protected override string PartOne(object data)
        {
            long sum = 0;
            Stopwatch sw = new();
            if (data is string str)
            {
                sw.Start();

                sum = AmountOfTokes(str);

                sw.Stop();
            }

            return $"Result Part 1: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }

        class ButtonCombination
        {
            public long AX { get; set; }
            public long AY { get; set; }
            public long BX { get; set; }
            public long BY { get; set; }
            public long PX { get; set; }
            public long PY { get; set; }
        }

        private long AmountOfTokes(string str, bool extend = false)
        {
            var input = str.Split(Environment.NewLine + Environment.NewLine)
                           .Select(s => s.Split(Environment.NewLine)
                                         .Select(ss => ss.Split(new string[] { ": ", ", " }, StringSplitOptions.None).Skip(1).Select(ssss => ssss.Split('+', '=')).ToArray()
                                  ).ToArray()
                           ).ToArray()
                           .Select(s => new ButtonCombination
                           {
                               AX = long.Parse(s[0][0][1]),
                               AY = long.Parse(s[0][1][1]),
                               BX = long.Parse(s[1][0][1]),
                               BY = long.Parse(s[1][1][1]),
                               PX = extend ? 1000000000000 + long.Parse(s[2][0][1]) : long.Parse(s[2][0][1]),
                               PY = extend ? 1000000000000 + long.Parse(s[2][1][1]) : long.Parse(s[2][1][1])
                           });

            var sum = 0L;
            foreach (var item in input)
            {
                var min = 0L;
                for (var i = item.PX/item.AX; i >= 0; i--)
                {
                    var diff = item.PX - i * item.AX;
                    if(diff % item.BX == 0)
                    {
                        if (item.PY == (item.AY * i + item.BY * diff / item.BX))
                        {
                            var temp = i * 3 + diff / item.BX;
                            if(temp < min || min == 0)
                                min = temp;
                        }
                    }
                }

                sum+=min;
            }

            return sum;
        }

        protected override string PartTwo(object data)
        {
            long sum = 0;
            Stopwatch sw = new();
            if (data is string str)
            {
                sw.Start();

                sum = AmountOfTokes(str, true);

                sw.Stop();
            }

            return $"Result Part 2: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }
    }
}
