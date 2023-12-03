using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day4 : IDay
    {
        public string Execute(string data)
        {
            return PartOne(data) + "\r\n" + PartTwo(data);
        }

        public string PartOne(object data)
        {
            return $"Result Part 1: {data}";
        }

        public string PartTwo(object data)
        {
            return $"Result Part 2: {data}";
        }
    }
}
