namespace AOC_2025.DayWorkers
{
    internal class Day6 : Day
    {
        public override string Execute(string data)
        { 
            return PartOne(data) + "\r\n" + PartTwo(data);
        }

        protected override string PartOne(object data)
        {
            if (data == null)
                return "";

            var sum = 0L;
            var problems = data.ToString().Split(Environment.NewLine).Select(x => x.Split(" ").Where(w => !string.IsNullOrEmpty(w)).ToArray()).ToArray();
            var problemsRotated = new List<(char Operator, List<long> Values)>();
            for (var i = 0; i < problems[0].Length; i++)
            {
                var l = new List<long>();
                for (int j = 0; j < problems.Length - 1; j++)
                    l.Add(long.Parse(problems[j][i]));

                problemsRotated.Add((problems[problems.Length - 1][i][0], l));
            }

            foreach (var problem in problemsRotated) {
                var problemValue = problem.Values.First();
                for (int i = 1; i < problem.Values.Count; i++)
                    problemValue = OperationExecuter(problem.Operator, problemValue, problem.Values[i]);

                sum += problemValue;
            }

            return "Part one: " + sum;
        }

        private long OperationExecuter(char oper, long v1, long v2) => oper switch {
            '*' => v1 * v2,
            '+' => v1 + v2,
            _ => v1
        };

        protected override string PartTwo(object data)
        {
            if (data == null)
                return "";

            var dataString = data.ToString().Split(Environment.NewLine);

            //Rotate array
            var r1 = dataString.Length;
            var r2 = dataString[0].Length;
            var newLines = new char[r2, r1];
            for (int i = 0; i < dataString.Length; i++)
                for (int j = 0; j < dataString[i].Length; j++)
                    newLines[j, i] = dataString[i][j];

            //Build new lines and merge them into numbers
            var problemsRotated = new List<(char Operator, List<long> Values)>();
            (char, List<long>) problemRoated = new();
            for (int k = 0; k < newLines.GetLength(0); k++) {
                var line = string.Empty;
                for (int l = 0; l < newLines.GetLength(1); l++)
                {
                    line += newLines[k, l];
                }

                if (line.Any(l => l != ' '))
                {
                    if (line.Contains('*') || line.Contains('+'))
                        problemRoated = new (line.Last(), new List<long>());

                    problemRoated.Item2.Add(long.Parse(line.Substring(0, line.Length - 1)));
                }
                else
                    problemsRotated.Add(problemRoated);
            }
            problemsRotated.Add(problemRoated);

            //Calculate lines
            var sum = 0L;
            foreach (var problem in problemsRotated)
            {
                var problemValue = problem.Values.First();
                for (int i = 1; i < problem.Values.Count; i++)
                    problemValue = OperationExecuter(problem.Operator, problemValue, problem.Values[i]);

                sum += problemValue;
            }

            return "Part day: " + sum;
        }
    }
}
