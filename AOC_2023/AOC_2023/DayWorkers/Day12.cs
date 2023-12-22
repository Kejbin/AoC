using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day12 : Day
    {
        public override string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split(Environment.NewLine)
                            .Where(s => !string.IsNullOrEmpty(s))
                            .Select(s => s.Split(' '))
                            .Select(s => (s[0], s[1].Split(',')
                                                    .Select(e => Convert.ToInt32(e))
                                                    .ToList()))
                            .ToList();

            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        protected override string PartOne(object data)
        {
            int sum = 0;
            if (data is List<(string Springs, List<int> DamagedSpringsNumbers)> input)
            {
                foreach (var item in input)
                {
                    var possibilities = 0;

                    for (int i = 0; i < item.Springs.Length; i++)
                    {
                        if (item.Springs[i] == '.' && item.Springs[i + 1] == '.')
                            continue;

                        if (item.Springs[i] == '#')
                        {

                        }

                        if (item.Springs[i] == '?')
                        {

                        }

                    }
                    //'.' next must be ?/#
                    //? get length and check for next symbol 
                    //if length <= ? and next == # -> end go to next symbol
                    //if # == lenght of spring analyze further
                    //if # < length of spring analyze next symbols at length of spring
                    //if # is last and lenght of spring reached next must be ?/.
                    //if all were accepted item can be added to possibilities
                    //

                    sum += possibilities;
                }
            }

            return $"Result Part 1: {sum}";
        }

        protected override string PartTwo(object data)
        {
            int sum = 0;
            if (data is List<(string Springs, List<int> DamagedSpringsNumbers)> input)
            {
                
            }

            return $"Result Part 2: {sum}";
        }
    }
}
