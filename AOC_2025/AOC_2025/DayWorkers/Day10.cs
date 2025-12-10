using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace AOC_2025.DayWorkers
{
    internal class Day10 : Day
    {
        public override string Execute(string data)
        {
            return PartOne(data) + "\r\n" + PartTwo(data);
        }

        protected override string PartOne(object data)
        {
            if (data == null)
                return "";

            var machine = data.ToString()
                            .Split(Environment.NewLine)
                            .Select(x => x.Split(' ')
                                          .Select(s => s.Replace("(", "")
                                                        .Replace(")", "")
                                                        .Replace("{", "")
                                                        .Replace("}", "")
                                                        .Replace("[", "")
                                                        .Replace("]", "")
                                                        .Split(','))
                                                        .ToArray())
                            .Select(y => (
                                            y[0].First().ToCharArray(), 
                                            y.Skip(1)
                                             .Take(y.Length - 2)
                                             .Select(e => e.Select(r => int.Parse(r))
                                                            .ToArray())
                                              .ToArray(), 
                                            y.Last()
                                             .Select(t => int.Parse(t))
                                             .ToArray()))
                            .ToList();

            var sum = 0;
            foreach (var lights in machine)
            {
                var matchNotFound = true;
                var itemsToUse = 2;
                while (matchNotFound)
                {
                    if (itemsToUse > lights.Item2.Length)
                    {
                        itemsToUse = 0;
                        break;
                    }

                    //Generate options to check, size depends from buttons to be used, each loop increase amount of buttons to use. All options have to be checked
                    /* 
                       Move on the last position when it reaches end of possible values, move to first position from one with lowest value, set value of position to +1 on all positions until last one, and repeat process
                       until all positions reaches last number

                        2 clics (3 options)
                        0,0 -> 0,1 -> 0,2 -> 0,3
                        1,1 -> 1,2 -> 1,3
                        2,2 -> 2,3
                        3,3

                        3 clicks (3 options)
                        0,0,0 -> 0,0,1 -> 0,0,2 -> 0,0,3
                        0,1,1 -> 0,1,2 -> 0,1,3
                        0,2,2 -> 0,2,3
                        1,1,1 -> 1,1,2 -> 1,1,3
                        1,2,2 -> 1,2,3
                        2,2,2 -> 2,2,3
                        3,3,3

                        4 clicks (3 options)
                        0,0,0,0 -> 0,0,0,1 -> 0,0,0,2 -> 0,0,0,3
                                   0,0,1,1 -> 0,0,1,2 -> 0,0,1,3
                                   0,1,1,1 -> 0,1,1,2 -> 0,1,1,3
                                   1,1,1,1 -> 1,1,1,2 -> 1,1,1,3
                                              1,1,2,2 -> 1,1,2,3
                                              1,2,2,2 -> 1,2,2,3
                                              2,2,2,2 -> 2,2,2,3
                                                         2,2,3,3
                                                         2,3,3,3
                                                         3,3,3,3


                                                         3,3,3,3
                                                         2,3,3,3
                                                         2,2,3,3
                                              2,2,2,2 -> 2,2,2,3
                                              1,2,2,2 -> 1,2,2,3
                                              1,1,2,2 -> 1,1,2,3
                                   1,1,1,1 -> 1,1,1,2 -> 1,1,1,3
                                   0,1,1,1 -> 0,1,1,2 -> 0,1,1,3
                                   0,0,1,1 -> 0,0,1,2 -> 0,0,1,3
                        0,0,0,0 -> 0,0,0,1 -> 0,0,0,2 -> 0,0,0,3

                    */

                    var indexes = new List<int[]>();
                    var arr = new int[itemsToUse];
                    for (int k = 0; k < lights.Item2.Length; k++)
                    {
                        var c = itemsToUse - 1;
                        while (c >= 0)
                        {
                            for (var j = c; j < itemsToUse; j++)
                                arr[j] = k;

                            for (int i = k; i < lights.Item2.Length; i++)
                            {
                                arr[itemsToUse - 1] = i;
                                indexes.Add(arr.ToArray());
                            }

                            c--;
                        }
                    }


                    //Check all posibilities
                    for (int i = 0; i < indexes.Count; i++)
                    {
                        var toModify = lights.Item1.ToArray();

                        for (int j = 0; j < indexes[i].Length; j++)
                        {
                            ApplyChange(toModify, lights.Item2[indexes[i][j]]);

                            if (toModify.SequenceEqual(lights.Item1))
                                matchNotFound = false;

                            if (!matchNotFound)
                                break;
                        }

                        if (!matchNotFound)
                            break;
                    }


                    itemsToUse++;

                }

                sum += itemsToUse;
            }

            return "Part one: " + sum;
        }

        private void ApplyChange(char[] toModify, int[] ints)
        {
            for (int i = 0; i < ints.Length; i++)
            {
                toModify[ints[i]] = toModify[ints[i]] == '.' ? '#' : '.';
            }
        }

        protected override string PartTwo(object data)
        {
            if (data == null)
                return "";


            return "Part two: " + 0;
        }
    }
}

