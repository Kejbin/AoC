using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC_2024.DayWorkers
{
    internal class Day3 : Day
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
                var muls = GetMuls(str);

                foreach (var item in muls)
                    sum += item[0] * item[1];
            }            
           
            return $"Result Part 1: {sum}";
        }

        private int[][] GetMuls(string str)
        {
            return str.Split("mul(")
                       .Where(w => char.IsDigit(w[0]) && w.Contains(')'))
                       .Select(s =>
                       {
                           var i = s.IndexOf(')');
                           return s.Substring(0, i);

                       })
                       .Select(s => s.Split(","))
                       .Where(w => 
                            w.Length == 2 && w.All(a => int.TryParse(a, out _)))
                       .Select(s => 
                            s.Select(ss => int.Parse(ss))
                            .ToArray())
                       .ToArray();
        }

        protected override string PartTwo(object data)
        {
            int sum = 0;
            if (data is string str)
            {
                var muls = GetDoDontMuls(str);

                foreach (var item in muls)
                    sum += item[0] * item[1];
            }

            return $"Result Part 2: {sum}";
        }

        private List<int[]> GetDoDontMuls(string str)
        {
            var split = str.Split("mul(");
            var list = new List<int[]>();
            var enabled = true;
            foreach (var item in split)
            {
                if (enabled && char.IsDigit(item[0]) && item.Contains(')'))
                { 
                    var i = item.IndexOf(')');
                    var producedStr = item.Substring(0, i).Split(",");

                    if (producedStr.Length == 2 && producedStr.All(a => int.TryParse(a, out _)))
                        list.Add(producedStr.Select(s => int.Parse(s)).ToArray());  
                }

                if (item.Contains("don't()"))
                {
                    enabled = false;
                    continue;
                }
                else if (item.Contains("do()"))
                {
                    enabled = true;
                    continue;
                }
            }

            return list;
        }
    }
}
