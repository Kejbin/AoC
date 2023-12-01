using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023
{
    public static class DaySelector
    {
        public static IDay? GetDay(string day) => day switch
        {
            "1" => new Day1(),
            "2" => new Day2(),
            _ => null
        };
    }
}
