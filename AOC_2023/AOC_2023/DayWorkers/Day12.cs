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
                    HashSet<string> possibilities = GetPatterns(item.Springs, item.DamagedSpringsNumbers.ToList());

                    sum += possibilities.Count;
                }
            }

            return $"Result Part 1: {sum}";
        }

        private HashSet<string> GetPatterns(string spring, List<int> list)
        {
            //'.' next must be ?/#
            //? get length and check for next symbol 
            //if length <= ? and next == # -> end go to next symbol
            //if # == lenght of spring analyze further
            //if # < length of spring analyze next symbols at length of spring
            //if # is last and lenght of spring reached next must be ?/.
            //if all were accepted item can be added to possibilities
            //

            var strings = new HashSet<string>();
            var listItemIndex = 0;
            var newString = string.Empty;
            for (int i = 0; i < spring.Length; i++)
            {
                for (int j = 0; j < spring.Length; j++)
                {
                    if (spring[j] == '.') 
                    {
                        newString += spring[j];
                        continue;
                    }

                    if(spring[j] == '#')
                    {
                        var s = spring.Substring(j, list[listItemIndex] + 1);
                        if (s.Take(list[listItemIndex]).All(s => s == '#' || s == '?') )
                        {

                            listItemIndex++;
                        }

                        j += list[listItemIndex];
                    }

                    if (spring[j] == '?')
                    {
                        var s = spring.Substring(j, list[listItemIndex]);
                        if (s.All(s => s == '#' || s == '?'))
                        {

                            listItemIndex++;
                        }


                        j += list[listItemIndex] + 1;
                    }

                    if (newString.Length == spring.Length) 
                    {
                        if (!strings.Contains(newString))
                            strings.Add(newString);

                        break;
                    }
                } 
            }

            return strings;
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
