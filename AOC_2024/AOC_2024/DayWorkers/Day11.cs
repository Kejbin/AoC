using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AOC_2024.DayWorkers
{
    internal class Day11 : Day
    {
        public override string Execute(string data)
        {
            return PartOne(data) + "\r\n" + PartTwo(data);
        }

        protected override string PartOne(object data)
        {
            long sum = 0;
            Stopwatch sw = new();
            if (data is string str)
            {
                sw.Start();

                sum = BlinkStones(str, 25);

                sw.Stop();
            }

            return $"Result Part 1: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }

        private long BlinkStones(string str, int blinks)
        {
            var input = str.Split(' ').Select(long.Parse).ToList();

            Queue<long> stones = new Queue<long>(input);
            var set = new HashSet<long>();
            for (int i = 0; i < blinks; i++)
            {
                var currStonesCount = stones.Count;
                for (int j = 0; j < currStonesCount; j++)
                {
                    var stone = stones.Dequeue();

                    if (set.Contains(stone))
                        continue;

                    set.Add(stone);

                    if (stone == 0) stones.Enqueue(1);
                    else if (stone == 1) stones.Enqueue(1 * 2024);

                    var strNumber = stone.ToString();
                    if (strNumber.Length % 2 == 0)
                    {
                        stones.Enqueue(int.Parse(strNumber.Substring(0, strNumber.Length / 2)));
                        stones.Enqueue(int.Parse(strNumber.Substring(strNumber.Length / 2)));
                    }
                    else
                        stones.Enqueue(stone * 2024);
                }
            }

            return stones.Count;
        }

        protected override string PartTwo(object data)
        {
            long sum = 0;
            Stopwatch sw = new();
            if (data is string str)
            {
                sw.Start();

                sum = BlinkStones(str, 75);

                sw.Stop();
            }

            return $"Result Part 2: {sum}, Execution time (ms): {sw.ElapsedMilliseconds}";
        }
    }
}
