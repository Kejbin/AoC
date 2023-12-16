using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day16 : IDay
    {

        public string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split(Environment.NewLine)
                            .Where(s => !string.IsNullOrEmpty(s))
                            .Select(s => s.ToArray())
                            .ToArray();

            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        public string PartOne(object data)
        {
            int sum = 0;
            if (data is char[][] input)
            {
                var visited = new List<(int, int)>();
                GetNextDirectionRecursion(input,0, 0, 0, -1, visited);

                sum = visited.Count;
            }

            return $"Result Part 1: {sum}";
        }

        private void GetNextDirectionRecursion(char[][] input, int y, int x, int oldY, int oldX, List<(int, int)> visited)
        {
            //For Part2 will throw Stack overflow
            if (x < 0 || x >= input.Length || y < 0 || y >= input[0].Length)
                return;

            var c = input[y][x];
            if (!visited.Contains((y, x)))
                visited.Add((y,x));

            switch (c)
            {
                case '.':
                    var newX = x + (x - oldX);
                    var newY = y + (y - oldY);

                    if (CheckForLoop(visited, newY, newX, y, x, oldY, oldX))
                        return;

                    GetNextDirectionRecursion(input, newY, newX, y, x, visited);

                    break;
                case '-':
                    newX = x - oldX;
                    newY = y - oldY;

                    //Split
                    if (newX == 0)
                    {
                        var x1 = x - 1;
                        var x2 = x + 1;

                        if (CheckForLoop(visited, y, x1, y, x, oldY, oldX))
                            return;

                        if (CheckForLoop(visited, y, x2, y, x, oldY, oldX))
                            return;

                        GetNextDirectionRecursion(input, y, x1, y, x, visited);
                        GetNextDirectionRecursion(input, y, x2, y, x, visited);
                    }
                    else
                    {
                        newX += x;
                        newY += y;

                        if (CheckForLoop(visited, newY, newX, y, x, oldY, oldX))
                            return;

                        GetNextDirectionRecursion(input, newY, newX, y, x, visited);
                    }

                    break;
                case '|':
                    newX = x - oldX;
                    newY = y - oldY;

                    //Split
                    if (newY == 0)
                    {
                        var y1 = y - 1;
                        var y2 = y + 1;

                        if (CheckForLoop(visited, y1, x, y, x, oldY, oldX))
                            return;

                        if (CheckForLoop(visited, y2, x, y, x, oldY, oldX))
                            return;

                        GetNextDirectionRecursion(input, y1, x, y, x, visited);
                        GetNextDirectionRecursion(input, y2, x, y, x, visited);
                    }
                    else
                    {
                        newX += x;
                        newY += y;

                        if (CheckForLoop(visited, newY, newX, y, x, oldY, oldX))
                            return;

                        GetNextDirectionRecursion(input, newY, newX, y, x, visited);
                    }

                    break;
                case '/':
                    newX = x;
                    newY = y;

                    //Next 90 degrees
                    if (x - oldX > 0)
                        newY -= 1;
                    else if (x - oldX < 0)
                        newY += 1;
                    else if (y - oldY > 0)
                        newX -= 1;
                    else if (y - oldY < 0)
                        newX += 1;

                    if (CheckForLoop(visited, newY, newX, y, x, oldY, oldX))
                        return;

                    GetNextDirectionRecursion(input, newY, newX, y, x, visited);

                    break;
                case '\\':
                    newX = x;
                    newY = y;

                    //Next 90 degrees
                    if (x - oldX > 0)
                        newY += 1;
                    else if (x - oldX < 0)
                        newY -= 1;
                    else if (y - oldY > 0)
                        newX += 1;
                    else if (y - oldY < 0)
                        newX -= 1;

                    if (CheckForLoop(visited, newY, newX, y, x, oldY, oldX))
                        return;

                    GetNextDirectionRecursion(input, newY, newX, y, x, visited);

                    break;
            }
        }

        private bool CheckForLoop(List<(int, int)> visited, int newY, int newX, int y, int x, int oldY, int oldX)
        {
            if (visited.Contains((newY, newX)) && visited.Contains((y, x)) && visited.Contains((oldY, oldX)))
            {
                var newIndex = visited.IndexOf((newY, newX));
                var oldIndex = visited.IndexOf((oldY, oldX));
                var index = visited.IndexOf((y, x));

                if ((oldIndex - index == 1 || oldIndex - index == -1) && (newIndex - index == 1 || newIndex - index == -1))
                    return true;
            }

            return false;
        }

        public string PartTwo(object data)
        {
            int sum = 0;
            if (data is char[][] input)
            {
                var visited = new List<(int, int)>();
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = 0; j < input[0].Length; j++)
                    {
                        if (i > 0 && i < input.Length - 1 && j > 0 && j < input[0].Length - 1)
                            continue;

                        var x = -1;
                        var y = -1;
                        if(i == 0)
                            x = j;
                        else if(j == 0)
                            y = i;
                        else if (i == input.Length - 1)
                        {
                            x = j;
                            y = input.Length;
                        }
                        else if (j == input[0].Length - 1)
                        {
                            x = input[0].Length;
                            y = i;
                        }

                        //Not fastest but better than Part1 ~ 28s
                        GetNextDirectionWhile(input, i, j, y, x, visited);

                        if (visited.Count > sum)
                            sum = visited.Count;

                        visited.Clear();
                    }
                }
            }

            return $"Result Part 2: {sum}";
        }

        private void GetNextDirectionWhile(char[][] input, int inputNewY, int inputNewX, int inputOldY, int inputOldX, List<(int, int)> visited)
        {
            var newStep = (inputNewY, inputNewX, inputOldY, inputOldX);

            var steps = new Stack<(int y, int x, int oldY, int oldX)>();
            steps.Push(newStep);

            while (steps.Count > 0) 
            {
                var step = steps.Pop();
                var x = step.x;
                var y = step.y;
                var oldY = step.oldY;
                var oldX = step.oldX;

                if (x < 0 || x >= input.Length || y < 0 || y >= input[0].Length)
                    continue;

                var c = input[y][x];
                if (!visited.Contains((y, x)))
                    visited.Add((y, x));

                switch (c)
                {
                    case '.':
                        var newX = x + (x - oldX);
                        var newY = y + (y - oldY);

                        if (CheckForLoop(visited, newY, newX, y, x, oldY, oldX))
                            continue;

                        steps.Push((newY, newX, y, x));
                        
                        break;
                    case '-':
                        newX = x - oldX;
                        newY = y - oldY;

                        //Split
                        if (newX == 0)
                        {
                            var x1 = x - 1;
                            var x2 = x + 1;

                            if (CheckForLoop(visited, y, x1, y, x, oldY, oldX))
                                continue;

                            if (CheckForLoop(visited, y, x2, y, x, oldY, oldX))
                                continue;

                            steps.Push((y, x1, y, x));
                            steps.Push((y, x2, y, x));
                        }
                        else
                        {
                            newX += x;
                            newY += y;

                            if (CheckForLoop(visited, newY, newX, y, x, oldY, oldX))
                                continue;

                            steps.Push((newY, newX, y, x));
                        }

                        break;
                    case '|':
                        newX = x - oldX;
                        newY = y - oldY;

                        //Split
                        if (newY == 0)
                        {
                            var y1 = y - 1;
                            var y2 = y + 1;

                            if (CheckForLoop(visited, y1, x, y, x, oldY, oldX))
                                continue;

                            if (CheckForLoop(visited, y2, x, y, x, oldY, oldX))
                                continue;

                            steps.Push((y1, x, y, x));
                            steps.Push((y2, x, y, x));
                        }
                        else
                        {
                            newX += x;
                            newY += y;

                            if (CheckForLoop(visited, newY, newX, y, x, oldY, oldX))
                                continue;

                            steps.Push((newY, newX, y, x));
                        }

                        break;
                    case '/':
                        newX = x;
                        newY = y;

                        //Next 90 degrees
                        if (x - oldX > 0)
                            newY -= 1;
                        else if (x - oldX < 0)
                            newY += 1;
                        else if (y - oldY > 0)
                            newX -= 1;
                        else if (y - oldY < 0)
                            newX += 1;

                        if (CheckForLoop(visited, newY, newX, y, x, oldY, oldX))
                            continue;

                        steps.Push((newY, newX, y, x));

                        break;
                    case '\\':
                        newX = x;
                        newY = y;

                        //Next 90 degrees
                        if (x - oldX > 0)
                            newY += 1;
                        else if (x - oldX < 0)
                            newY -= 1;
                        else if (y - oldY > 0)
                            newX += 1;
                        else if (y - oldY < 0)
                            newX -= 1;

                        if (CheckForLoop(visited, newY, newX, y, x, oldY, oldX))
                            continue;

                        steps.Push((newY, newX, y, x));

                        break;
                }
            }
        }
    }
}
