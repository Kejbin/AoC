using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC_2024.DayWorkers
{
    internal class Day4 : Day
    {
        public override string Execute(string data)
        {
            return PartOne(data) + "\r\n" + PartTwo(data);
        }

        protected override string PartOne(object data)
        {
            int sum = 0;
            Stopwatch sw = new();
            if (data is string str)
            {
                sw.Start();
                sum = GetXmas(str);
                sw.Stop();
            }            
           
            return $"Result Part 1: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }

        private int GetXmas(string str)
        {
            var arr2d = str.Split(Environment.NewLine)
                           .Select(s => s.ToCharArray())
                           .ToArray();
            var count = 0;

            var dirs = new List<(int X,int Y)> { (0,-1), (1,-1), (1,0), (1,1), (0,1), (-1,1), (-1,0), (-1,-1) };

            for (int i = 0; i < arr2d.Length; i++)
            {
                for (int j = 0; j < arr2d[i].Length; j++)
                {
                    if (arr2d[i][j] == 'X') 
                    {
                        for (var k = 0; k < dirs.Count; k++)
                        {
                            var dir = dirs[k];
                            if (!CheckForLetter(arr2d, j, i, dir, 'M'))
                                continue;

                            dir.X += dirs[k].X;
                            dir.Y += dirs[k].Y;
                            if (!CheckForLetter(arr2d, j, i, dir, 'A'))
                                continue;

                            dir.X += dirs[k].X;
                            dir.Y += dirs[k].Y;
                            if (CheckForLetter(arr2d, j, i, dir, 'S'))
                                count++;
                        }
                    }
                }
            }

            return count;
        }

        private bool CheckForLetter(char[][] arr2d, int x, int y, (int X, int Y) dir, char letter)
        {
            if(0 > x + dir.X 
                || arr2d[0].Length - 1 < x + dir.X 
                || 0 > y + dir.Y
                || arr2d.Length - 1 < y + dir.Y)
                return false;

            return arr2d[y + dir.Y][x + dir.X] == letter;
        }   

        protected override string PartTwo(object data)
        {
            int sum = 0;
            Stopwatch sw = new();
            if (data is string str)
            {
                sw.Start();

                sum = GetX_Mas(str);

                sw.Stop();
            }

            return $"Result Part 2: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }

        private int GetX_Mas(string str)
        {
            var arr2d = str.Split(Environment.NewLine)
                           .Select(s => s.ToCharArray())
                           .ToArray();
            var count = 0;

            for (int i = 0; i < arr2d.Length; i++)
            {
                for (int j = 0; j < arr2d[i].Length; j++)
                {
                    if (arr2d[i][j] == 'A')
                    {
                        if (((CheckForLetter(arr2d, j, i, (-1,-1), 'M') && CheckForLetter(arr2d, j, i, (1,1), 'S')) || (CheckForLetter(arr2d, j, i, (-1, -1), 'S') && CheckForLetter(arr2d, j, i, (1, 1), 'M')))
                            && ((CheckForLetter(arr2d, j, i, (-1, 1), 'M') && CheckForLetter(arr2d, j, i, (1, -1), 'S')) || (CheckForLetter(arr2d, j, i, (-1, 1), 'S') && CheckForLetter(arr2d, j, i, (1, -1), 'M'))))
                                count++;
                    }
                }
            }

            return count;
        }
    }
}
