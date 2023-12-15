using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOC_2023.DayWorkers;

namespace AOC_2023
{
    public static class DaySelector
    {
        public static IDay? GetDay(string day) => day switch
        {
            "1" => new Day1(),
            "2" => new Day2(),
            "3" => new Day3(),
            "4" => new Day4(),
            "5" => new Day5(),
            "6" => new Day6(),
            "7" => new Day7(),
            "8" => new Day8(),
            "9" => new Day9(),
            "10" => new Day10(),
            "11" => new Day11(),
            "12" => new Day12(),
            "13" => new Day13(),
            "14" => new Day14(),
            "15" => new Day15(),
            _ => null
        };
    }
}
