using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day1 : Day
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
                    var digits = Regex.Split(item, @"\D+").Where(i => !string.IsNullOrEmpty(i));

                    if (digits.Count() == 1)
                    {
                        sum += Convert.ToInt16(digits.First().First().ToString() + digits.First().Last().ToString());
                    }
                    else if (digits.Count() >= 2)
                        sum += Convert.ToInt16(digits.First().First().ToString() + digits.Last().Last().ToString());
                }
            }

            return $"Result Part 1: {sum}";

        }

        protected override string PartTwo(object data)
        {
            string[] numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "zero", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            int sum = 0;
            if (data is string str)
            {
                foreach (var item in str.Split("\r\n"))
                {
                    var digits = new List<string>();
                    for (int i = 0; i < item.Length; i++)
                    {
                        foreach (var numb in numbers)
                        {
                            if (i + numb.Length > item.Length)
                                continue;

                            if (item.Substring(i, numb.Length) == numb)
                                digits.Add(ConvertToNumberString(numb));
                        }

                    }

                    if (digits.Count() == 1)
                        sum += Convert.ToInt16(digits.First() + digits.First());
                    else if (digits.Count() >= 2)
                        sum += Convert.ToInt16(digits.First() + digits.Last());
                }
            }

            return $"Result Part 2: {sum}";
        }

        private string ConvertToNumberString(string str) => str switch
        {
            "one" => "1",
            "two" => "2",
            "three" => "3",
            "four" => "4",
            "five" => "5",
            "six" => "6",
            "seven" => "7",
            "eight" => "8",
            "nine" => "9",
            "zero" => "0",
            _ => str
        };
    }
}
