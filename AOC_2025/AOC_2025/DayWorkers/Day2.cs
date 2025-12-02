using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2025.DayWorkers
{
    internal class Day2 : Day
    {
        public override string Execute(string data)
        {
            var ranges = data.ToString().Replace(Environment.NewLine, "").Split(',').Where(w => !string.IsNullOrEmpty(w)).Select(s => s.Split('-').Select(s => long.Parse(s)).ToArray());
            long response = 0;
            long response2 = 0;
            foreach (var range in ranges)
            {
                for (var i = range[0]; i <= range[1]; i++)
                {
                    if (CheckValue(i))
                        response += i;

                    if(CheckValue2(i))
                        response2 += i;
                }
            }

            return PartOne(response) + "\r\n" + PartTwo(response2);
        }

        private bool CheckValue2(long i)
        {
            var s = i.ToString();
            var isValid = false;
            for (int c = Convert.ToInt32(Math.Ceiling(s.Length / 2D)); c > 0; c--)
            {
                var ss = s.Substring(0, c);
                for (int d = c; d < s.Length; d += c)
                    if (d + c <= s.Length && s.Substring(d, c) == ss)
                        isValid = true;
                    else
                    {
                        isValid = false;
                        break;
                    }

                if (isValid)
                    break;
            }

            return isValid;
        }

        private bool CheckValue(long i)
        {
            var s = i.ToString();
            for (int c = s.Length/2; c > 0 ; c--)
            {
                var ss = s.Substring(0, c);
                for (int d = c; d <= c; d += c)
                    if (s.Substring(d) == ss)
                        return true;
                    else
                        break;
            }

            return false;
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
