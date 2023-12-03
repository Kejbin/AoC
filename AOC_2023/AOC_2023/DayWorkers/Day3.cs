namespace AOC_2023.DayWorkers
{
    internal class Day3 : IDay
    {
        private bool[,] _visited;

        public string Execute(string data)
        {
            var arr = data.Split("\r\n");

            return PartOne(arr) + "\r\n" + PartTwo(arr);
        }

        public string PartOne(object obj)
        {
            int sum = 0;

            if (obj is string[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < arr[i].Length; j++)
                    {
                        if (arr[i][j] == '.')
                            continue;

                        if (Char.IsDigit(arr[i][j]))
                        {
                            var endNumberIndex = j;
                            for (int k = j + 1; k < arr[i].Length && Char.IsDigit(arr[i][k]); k++)
                            {
                                endNumberIndex = k;
                            }
                            CheckSides(arr, i, j, endNumberIndex, ref sum);

                            j = endNumberIndex;
                        }
                    }
                }
            }

            return $"Result Part 1: {sum}";
        }

        private void CheckSides(string[] arr, int i, int j, int endNumberIndex, ref int sum)
        {
            //Top 
            if (i > 0 && CheckOtherLine(arr[i - 1], j - 1, endNumberIndex + 1))
            {
                var number1 = Convert.ToInt32(arr[i].Substring(j, endNumberIndex - j + 1));
                sum += number1;

                return;
            }
            //Left
            if (CheckSameLine(arr[i], j - 1))
            {
                var number1 = Convert.ToInt32(arr[i].Substring(j, endNumberIndex - j + 1));
                sum += number1;

                return;
            }
            //Right
            if (CheckSameLine(arr[i], endNumberIndex + 1))
            {
                var number1 = Convert.ToInt32(arr[i].Substring(j, endNumberIndex - j + 1));
                sum += number1;

                return;
            }
            //Bottom
            if (i < arr.Length - 1 && CheckOtherLine(arr[i + 1], j - 1, endNumberIndex + 1))
            {
                var number1 = Convert.ToInt32(arr[i].Substring(j, endNumberIndex - j + 1));
                sum += number1;

                return;
            }
        }

        private bool CheckSameLine(string line, int i)
        {
            if (line.Length == i || i < 0)
                return false;


            if (line[i] != '.')

                return true;


            return false;
        }

        private bool CheckOtherLine(string line, int from, int to)
        {
            if (string.IsNullOrEmpty(line))
                return false;

            if (line.Length == to)
                to--;
            else if (from < 0)
                from++;

            for (int i = from; i <= to; i++)
            {
                if (line[i] != '.')
                    return true;
            }

            return false;
        }

        public string PartTwo(object obj)
        {
            int sum = 0;
            if (obj is string[] arr)
            {
                _visited = new bool[arr.Length, arr[0].Length]; 
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j <  arr[i].Length; j++)
                    {
                        if (arr[i][j] == '*')
                            sum += GetSurroundingNumbers(arr, i, j);
                    }

                }
            }

            return $"Result Part 2: {sum}";
        }

        private int GetSurroundingNumbers(string[] arr, int i, int j)
        {
            List<int> numbers = new List<int>();
            //Top       
            CheckForNumberLine(arr, i - 1, j - 1, j + 1, numbers);
            //Left
            CheckForNumberLine(arr, i, j - 1, j - 1, numbers);
            //Right
            CheckForNumberLine(arr, i, j + 1, j + 1, numbers);
            //Botto
            CheckForNumberLine(arr, i + 1, j - 1, j + 1, numbers);


            if (numbers.Count > 1) return numbers[0] * numbers[1];
            else return 0;
        }

        private void CheckForNumberLine(string[] arr, int line, int from, int to, List<int> numbers)
        {
            for(int i = from; i <= to; i++)
            {
                if (!_visited[line, i] && Char.IsDigit(arr[line][i]))
                   numbers.Add(GetNumber(arr, line, i));
            }
        }

        private int GetNumber(string[] arr, int line, int foundIndex)
        {
            int left = foundIndex - 1;
            int right = foundIndex + 1;

            while (left > 0)
            {
                if (Char.IsDigit(arr[line][left]))
                    left--;
                else
                {
                    left++;
                    break;
                }
            }

            while (right <= arr[line].Length)
            {
                if (right < arr[line].Length && Char.IsDigit(arr[line][right]))
                    right++;
                else
                {
                    right--;
                    break;
                }
            }

            for (int i = left; i <= right; i++)
                _visited[line, i] = true;

            return Convert.ToInt32(arr[line].Substring(left, right - left + 1));
        }

    }
}