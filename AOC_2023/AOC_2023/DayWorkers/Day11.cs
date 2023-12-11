using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day11 : IDay
    {
        private List<Coord> _coordList = new List<Coord>();

        public string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split(Environment.NewLine)
                            .Where(s => !string.IsNullOrEmpty(s))
                            .Select(s => s.ToList())
                            .ToList();

            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        public string PartOne(object data)
        {
            long sum = 0;
            if (data is List<List<char>> inp)
            {
                var input = inp.Select(s => s.ToList()).ToList();
                //Building new map, too slow in large data expansion
                for (int i = 0; i < input.Count; i++)
                {
                    //Check X
                    if (!input[i].Contains('#'))
                    {
                        input.Insert(i + 1, input[i].ToList());
                        i++;
                    }
                }

                //Check Y
                for (int j = 0; j < input[0].Count; j++)
                {
                    bool canAdd = true;
                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i][j] == '#')
                        {
                            canAdd = false;
                            break;
                        }
                    }

                    if (canAdd)
                    {
                        for (int i = 0, loopTo = input.Count; i < loopTo; i++)
                        {
                            input[i].Insert(j + 1, '.');
                        }

                        j++;
                    }
                }

                for (int i = 0; i < input.Count; i++)
                    for (int j = 0; j < input[i].Count; j++)
                    {
                        if (input[i][j] == '#')
                            _coordList.Add(new Coord(i, j));
                    }


                int range = 1;
                foreach (var coord in _coordList)
                {
                    for (int i = range; i < _coordList.Count; i++)
                    {
                        sum += Math.Abs(coord.X - _coordList[i].X) + Math.Abs(coord.Y - _coordList[i].Y);
                    }
                    range++;
                }
            }

            return $"Result Part 1: {sum}";
        }

        public string PartTwo(object data)
        {
           _coordList.Clear();

            //Solution to store column and lines differences and apply them to saved coordinates

            long sum = 0;
            var lineDiffs = new List<long>();
            var columnDiffs = new List<long> ();
            if (data is List<List<char>> input)
            {
                long lineIterator = 0;
                for (int i = 0; i < input.Count; i++)
                {
                    //Check X
                    if (!input[i].Contains('#'))
                        lineDiffs.Add(lineIterator += 999999);
                    else
                        lineDiffs.Add(lineIterator);
                }

                //Check Y
                long columnIterator = 0;
                for (int j = 0; j < input[0].Count; j++)
                {
                    bool canAdd = true;
                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i][j] == '#')
                        {
                            canAdd = false;
                            break;
                        }
                    }

                    if (canAdd)
                        columnDiffs.Add(columnIterator += 999999);
                    else
                        columnDiffs.Add(columnIterator);
                }

                for (int i = 0; i < input.Count; i++)
                    for (int j = 0; j < input[i].Count; j++)
                    {
                        if (input[i][j] == '#')
                        {
                            var y = i + lineDiffs[i];
                            var x = j + columnDiffs[j];
                            _coordList.Add(new Coord(x, y));
                        }
                    }

                int range = 1;
                foreach (var coord in _coordList)
                {
                    for (int i = range; i < _coordList.Count; i++)
                        sum += Math.Abs(coord.X - _coordList[i].X) + Math.Abs(coord.Y - _coordList[i].Y);

                    range++;
                }
            }

            return $"Result Part 2: {sum}";
        }
    }

    public class Coord
    {
        public Coord(long x, long y) 
        {
            X = x; 
            Y = y;
        }

        public long X { get; private set; } 
        public long Y { get; private set; }
    }
}
