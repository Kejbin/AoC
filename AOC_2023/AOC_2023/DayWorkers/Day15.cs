﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day15 : Day
    {
        public override string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split(',')
                            .Where(s => !string.IsNullOrEmpty(s))
                            .ToList();

            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        protected override string PartOne(object data)
        {
            int sum = 0;
            if (data is List<string> input)
            {
                foreach (var item in input)
                    sum += HashAlgorithm(item);
            }

            return $"Result Part 1: {sum}";
        }

        protected override string PartTwo(object data)
        {
            int sum = 0;
            if (data is List<string> input)
            {
                var boxes = new List<List<string>>(256);
                for (int i = 0; i < 256; i++)
                    boxes.Add(new List<string>());

                foreach (var item in input)
                {
                    var split = item.Split('=');
                    if (split.Count() == 1)
                        split = item.Split('-');

                    var boxId = HashAlgorithm(split[0]);
                    var box = boxes[boxId];

                    if (item.Contains('-'))
                    {
                        if (box.Any())
                            box.RemoveAll(v => v.Contains(split[0]));

                        continue;
                    }

                    if (item.Contains("="))
                    {
                        //Replace lenses
                        if (box.Any(c => c.Contains(split[0])))
                        {
                            foreach (var labelExisting in box.Where(c => c.Contains(split[0])).ToList())
                            {
                                var i = box.IndexOf(labelExisting);
                                box[i] = item;
                            }

                            continue;
                        }

                        //Add lenses
                        box.Add(item);
                    }
                }

                for (int i = 0; i < 256; i++)
                {
                    for (int j = 0; j < boxes[i].Count; j++)
                    {
                        var split = boxes[i][j].Split('=');
                        sum += (i + 1) * (j + 1) * Convert.ToInt16(split[1]);
                    }
                }
            }

            return $"Result Part 2: {sum}";
        }

        private int HashAlgorithm(string item)
        {
            var current = 0;
            for (int i = 0; i < item.Length; i++)
            {
                current += (int)item[i];
                current *= 17;
                current = current % 256;
            }

            return current;
        }
    }
}
