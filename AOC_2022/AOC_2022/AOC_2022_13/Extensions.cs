using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC_2022_13
{
    internal static class Extensions
    {
        public static string[] SplitItems(this string s)
        {
            var l = new List<string>();

            if (!s.Contains(",[") && !s.Contains("],"))
                return new string[] { s };

            while (s.Contains(",[") || s.Contains("],"))
            {
                var index = 0;

                if (s.Contains("],"))
                {
                    index = s.IndexOf("],");
                    s = s.Remove(index + 1, 1);
                    l.Add(s.Substring(0, index + 1));
                    s = s.Substring(index + 1);
                }

                if (s.Contains(",["))
                {
                    index = s.IndexOf(",[");
                    s = s.Remove(index, 1);
                    l.Add(s.Substring(0, index));
                    s = s.Substring(index);
                }
            }

            l.Add(s);

            return l.ToArray();
        }
    }
}
