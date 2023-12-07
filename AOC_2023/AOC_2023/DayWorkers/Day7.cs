using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day7 : IDay
    {
        enum Sets
        {
            HighCard,
            OnePair,
            TwoPair,
            TheeOfAKind,
            FullHouse,
            FourOfAKind,
            FiveOfAKind
        }

        private List<char> _oderedCards = new List<char>
        {
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
            'T',
            'J',
            'Q',
            'K',
            'A'
        };

        public string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split(Environment.NewLine).Where(s => !string.IsNullOrEmpty(s)).Select(s => s.Split(' ')).ToList();

            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        private int Compare(string v1, string v2)
        {
            var r1 = GetSet(v1);
            var r2 = GetSet(v2);

            if (r1 == r2)
            {
                for (int i = 0; i < v1.Length; i++)
                {
                    if (v1[i] == v2[i])
                        continue;

                    var p1 = Power(v1[i]);
                    var p2 = Power(v2[i]);

                    if (p1 > p2)
                        return 1;
                    else
                        return -1;
                }

                return 0;
            }

            if (r1 > r2)
                return 1;

            return -1;
        }

        private int Power(char v) => _oderedCards.IndexOf(v);

        private Sets GetSet(string v)
        {
            Dictionary<char, int> chars = new ();
            foreach (var item in v)
            {
                if (chars.TryGetValue(item, out int count))
                {
                    chars[item] = count+=1;
                    continue;
                }
                else
                {
                    chars.Add(item, 1);
                }
            }

            Sets cardSet;
            if (chars.Count == 5)
                cardSet = Sets.HighCard;
            else if (chars.Count == 4)
                cardSet = Sets.OnePair;
            else if (chars.Count == 3)
            {
                if (chars.Any(c => c.Value > 2))
                    cardSet = Sets.TheeOfAKind;

                cardSet = Sets.TwoPair;
            }
            else if (chars.Count == 2)
            {
                if (chars.Any(c => c.Value > 3))
                    cardSet = Sets.FourOfAKind;

                cardSet = Sets.FullHouse;
            }
            else
                cardSet = Sets.FiveOfAKind;

            return cardSet;
        }

        public string PartOne(object data)
        {
            int sum = 0;
            if (data is List<string[]> input)
            {
                input.Sort((a, b) => Compare(a[0], b[0]));

                for (int i = 1; i <= input.Count; i++)
                    sum += i * Convert.ToInt32(input[i - 1][1]);
            }

            return $"Result Part 1: {sum}";
        }

        public string PartTwo(object data)
        {
            int sum = 0;
            if (data is List<string[]> input)
            {
                input.Sort((a, b) => Compare(a[0], b[0]));

                for (int i = 1; i <= input.Count; i++)
                    sum += i * Convert.ToInt32(input[i - 1][1]);
            }

            return $"Result Part 2: {sum}";
        }
    }
}
