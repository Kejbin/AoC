using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2025.DayWorkers
{
    internal class Day4 : Day
    {
        public override string Execute(string data)
        {
            var ranges = data.ToString()
                            .Split(Environment.NewLine)
                            .Select(s => s.ToCharArray())
                            .ToArray();
 

            return PartOne(ranges) + "\r\n" + PartTwo(ranges);
        }

        protected override string PartOne(object data)
        {
            var response = 0;

            if(data is char[][] paperRollsMap)
                for (var i = 0; i < paperRollsMap.Length; i++)
                {
                    for (var j = 0; j < paperRollsMap[i].Length; j++)
                        if(paperRollsMap[i][j] == '@' && CheckAdjacentPositions(paperRollsMap, i, j))
                            response++;
                }

            return "Part one: " + response;
        }

        private bool CheckAdjacentPositions(char[][] paperRollsMap, int i, int j)
        {
            var neighbours = 0;

            if(i - 1 >= 0 && paperRollsMap[i - 1][j] == '@')
                neighbours++;

            if (j - 1 >= 0 && paperRollsMap[i][j - 1] == '@')
                neighbours++;

            if (i + 1 < paperRollsMap.Length && paperRollsMap[i + 1][j] == '@')
                neighbours++;

            if (j + 1 < paperRollsMap[0].Length && paperRollsMap[i][j + 1] == '@')
                neighbours++;

            if (i - 1 >= 0 && j - 1 >= 0 && paperRollsMap[i - 1][j - 1] == '@')
                neighbours++;

            if (i + 1 < paperRollsMap.Length && j - 1 >= 0 && paperRollsMap[i + 1][j - 1] == '@')
                neighbours++;

            if (i - 1 >= 0 && j + 1 < paperRollsMap[0].Length && paperRollsMap[i - 1][j + 1] == '@')
                neighbours++;

            if (i + 1 < paperRollsMap.Length && j + 1 < paperRollsMap[0].Length && paperRollsMap[i + 1][j + 1] == '@')
                neighbours++;

            return neighbours < 4;
        }

        protected override string PartTwo(object data)
        {
            var sum = 0;

            if (data is char[][] paperRollsMap)
            {
                int response;
                do
                {
                    response = 0;
                    var toChange = new List<(int, int)>();
                    for (var i = 0; i < paperRollsMap.Length; i++)
                    {
                        for (var j = 0; j < paperRollsMap[i].Length; j++)
                            if (paperRollsMap[i][j] == '@' && CheckAdjacentPositions(paperRollsMap, i, j))
                            {
                                response++;
                                toChange.Add((i, j));
                            }
                    }

                    foreach (var i in toChange)
                        paperRollsMap[i.Item1][i.Item2] = '.';

                    sum += response;
                }
                while (response > 0);
            }


            return "Part day: " + sum;
        }
    }
}
