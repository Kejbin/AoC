using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
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

            if (data is string str)
            {
                foreach (var item in str.Split("\r\n"))
                {
                    var split = item.Split('|');

                    if (split.Length >= 2)
                    {
                        var winningNumbers = split[0].Split(':')[1]
                                                     .Split(' ')
                                                     .Where(s => !string.IsNullOrEmpty(s))
                                                     .Select(s => Convert.ToInt32(s));
                        var givenNumbers = split[1].Split(' ')
                                                   .Where(c => !string.IsNullOrEmpty(c))
                                                   .Select(s => Convert.ToInt32(s));

                        var points = 0;
                        foreach (var winNo in winningNumbers)
                        {
                            if (givenNumbers.Contains(winNo))
                                points = points == 0 ? 1 : points * 2;
                        }

                        sum += points;
                    }
                }
            }

            return $"Result Part 1: {sum}";
        }

        protected override string PartTwo(object data)
        {
            int sum = 0;

            if (data is string str)
            {
                List<string> originalScratches = str.Split("\r\n").ToList();
                Queue<string> scratches = new Queue<string>(originalScratches);
                while (scratches.Any())
                {
                    var item = scratches.Dequeue();
                    var split = item.Split('|');

                    if (split.Length >= 2)
                    {
                        sum++;
                        var cardSplit = split[0].Split(':');
                        var gameId = Convert.ToInt16(cardSplit[0].Substring(5));
                        var winningNumbers = cardSplit[1].Split(' ')
                                                         .Where(s => !string.IsNullOrEmpty(s))
                                                         .Select(s => Convert.ToInt32(s));
                        var givenNumbers = split[1].Split(' ')
                                                   .Where(c => !string.IsNullOrEmpty(c))
                                                   .Select(s => Convert.ToInt32(s));

                        var points = 0;
                        foreach (var winNo in winningNumbers)
                        {
                            if (givenNumbers.Contains(winNo))
                                points++;
                        }

                        for (int i = gameId; i < gameId + points; i++)
                            scratches.Enqueue(originalScratches[i]);
                    }
                }
            }

            return $"Result Part 2: {sum}";
        }
    }
}
