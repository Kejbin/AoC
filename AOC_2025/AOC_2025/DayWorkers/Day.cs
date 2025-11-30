using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2025.DayWorkers
{
    public abstract class Day
    {
        public abstract string Execute(string data);
        protected abstract string PartOne(object data);
        protected abstract string PartTwo(object data);
    }
}
