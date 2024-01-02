using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2023.DayWorkers
{
    internal class Day23 : Day
    {
        public override string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split(Environment.NewLine)
                            .Where(s => !string.IsNullOrEmpty(s))
                            .Select(s => s.ToList())
                            .ToList();

            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        protected override string PartOne(object data)
        {
            int sum = 0;
            if (data is List<List<char>> input)
            {
                //https://www.geeksforgeeks.org/longest-possible-route-in-a-matrix-with-hurdles/
                var start = (input[0].IndexOf('.'), 0);
                var end = (input[input.Count - 1].IndexOf('.'), input.Count - 1);
                sum = FindLongestPath(input.Select(c => c.ToArray()).ToArray(), start, end, new bool[input.Count, input[0].Count], false);
            }

            return $"Result Part 1: {sum}";
        }

        private Tuple<bool, int> FindLongestPathUtil(char[][] mat, (int X, int Y) currCell, (int X, int Y) end, bool[,] visited, (int X, int Y) lastCell)
        {

            // if (currCell.X, currCell.Y) itself is destination, return true
            if (currCell.X == end.X && currCell.Y == end.Y)
                return new Tuple<bool, int>(true, 0);

            // if not a valid cell, return false  
            if (currCell.X < 0
                || currCell.X >= mat[0].Length
                || currCell.Y < 0
                || currCell.Y >= mat.Length
                || mat[currCell.Y][currCell.X] == '#'
                || visited[currCell.Y, currCell.X]
                || CheckSlopes(mat[currCell.Y][currCell.X], currCell, lastCell))
                return new Tuple<bool, int>(false, Int32.MaxValue);

            // include (currCell.X, currCell.Y) in current path currCell.X.e.
            // set visited(currCell.X, currCell.Y) to true
            visited[currCell.Y, currCell.X] = true;

            // res stores longest path from current cell (currCell.X, currCell.Y) to
            // destination cell (x, y)
            int res = Int32.MinValue;

            // go left from current cell
            Tuple<bool, int> sol = FindLongestPathUtil(mat, (currCell.X, currCell.Y - 1), end, visited, currCell);

            // if destination can be reached on going left from current
            // cell, update res
            if (sol.Item1)
                res = Math.Max(sol.Item2, res);

            // go right from current cell
            sol = FindLongestPathUtil(mat, (currCell.X, currCell.Y + 1), end, visited, currCell);

            // if destination can be reached on going right from current
            // cell, update res
            if (sol.Item1)
                res = Math.Max(sol.Item2, res);

            // go up from current cell
            sol = FindLongestPathUtil(mat, (currCell.X - 1, currCell.Y), end, visited, currCell);

            // if destination can be reached on going up from current
            // cell, update res
            if (sol.Item1)
                res = Math.Max(sol.Item2, res);

            // go down from current cell
            sol = FindLongestPathUtil(mat, (currCell.X + 1, currCell.Y), end, visited, currCell);

            // if destination can be reached on going down from current
            // cell, update res
            if (sol.Item1)
                res = Math.Max(sol.Item2, res);

            // Backtrack
            visited[currCell.Y, currCell.X] = false;

            // if destination can be reached from current cell,
            // return true
            if (res != Int32.MinValue)
                return new Tuple<bool, int>(true, res + 1);

            // if destination can't be reached from current cell,
            // return false
            else
                return new Tuple<bool, int>(false, Int32.MaxValue);

        }

        private bool CheckSlopes(char symb, (int X, int Y) currCell, (int X, int Y) lastCell)
        {
            switch (symb)
            {
                case '>':
                    if (lastCell.X > currCell.X)
                        return true;

                    return false;
                case 'v':
                    if (lastCell.Y > currCell.Y)
                        return true;

                    return false;
                case '^':
                    if (lastCell.Y < currCell.Y)
                        return true;

                    return false;
                case '<':
                    if (lastCell.X < currCell.X)
                        return true;

                    return false;

                default: return false;
            }
        }

        private int FindLongestPath(char[][] mat, (int X, int Y) start, (int X, int Y) end, bool[,] visited, bool part2)
        {
            // find longest route from (i, j) to (x, y) and
            // print its maximum cost
            Tuple<bool, int> p;
            if (!part2)
                return FindLongestPathUtil(mat, start, end, visited, start).Item2;
            else
                return FindLongestPathQueue(mat, start, end);
        }

        private int FindLongestPathQueue(char[][] mat, (int X, int Y) start, (int X, int Y) end)
        {
            //Build graph or something that is some kind of it's representation, I dunno I'm tired
            Graph<(int, int)> g = new();
            g.Vertices.Add(new Vertice<(int, int)>(start));
            g.Vertices.Add(new Vertice<(int, int)>(end));
            Queue<HashSet<(int X, int Y)>> q = new();
            q.Enqueue(new HashSet<(int X, int Y)> { start });
            while (q.Count > 0)
            {
                var path = q.Dequeue();
                var paths = GetPaths(path, mat, end, out bool finished);

                if (paths == null || paths.Count > 1)
                {
                    var v2 = g.Vertices.Find(a => a.Key == path.Last());
                    if (v2 == null)
                    {
                        v2 = new Vertice<(int, int)>(path.Last());
                        g.Vertices.Add(v2);
                    }

                    var v1 = g.Vertices.Find(a => a.Key == path.First());
                    if (v1 != null && v2 != null)
                    {
                        if (g.Edges.Any(e => e.Vertices.Contains(v1) && e.Vertices.Contains(v2)))
                            continue;

                        g.Edges.Add(new Edge<(int, int)>(v1, v2, path.Count - 1));
                    }
                }

                if (paths == null)
                    continue;

                foreach (var item in paths)
                    q.Enqueue(item);
            }

            //Get longest path, slow AF, could be optimized but nah
            g.FindAllPaths(start, end);
            
            return (int)g.LongestPath;
        }

        private List<HashSet<(int, int)>> GetPaths(HashSet<(int X, int Y)> path, char[][] mat, (int X, int Y) end, out bool finished)
        {
            finished = false;
            var currCell = path.Last();
            // if (currCell.X, currCell.Y) itself is destination, return true
            if (currCell.X == end.X && currCell.Y == end.Y)
            {
                finished = true;
                return null;
            }

            //Count between junctions

            var newPaths = new List<HashSet<(int, int)>>();
            var directions = new List<(int X, int Y)> { (currCell.X, currCell.Y - 1), (currCell.X, currCell.Y + 1), (currCell.X - 1, currCell.Y), (currCell.X + 1, currCell.Y) };
            var listPoints = new List<(int, int)>();
            foreach (var item in directions)
            {
                // if not a valid cell, return false  
                if (item.X < 0
                    || item.X >= mat[0].Length
                    || item.Y < 0
                    || item.Y >= mat.Length
                    || mat[item.Y][item.X] == '#'
                    || path.Contains((item.X, item.Y)))
                    continue;

                listPoints.Add(item);
            }

            if (listPoints.Count == 1)
            {
                var newPath = new HashSet<(int, int)>(path);
                newPath.Add(listPoints.First());
                newPaths.Add(newPath);
            }
            else
            {
                foreach (var item in listPoints)
                {
                    var newPath = new HashSet<(int, int)>();
                    newPath.Add(currCell);
                    newPath.Add(item);
                    newPaths.Add(newPath);
                }
            }

            return newPaths;
        }

        protected override string PartTwo(object data)
        {
            int sum = 0;
            if (data is List<List<char>> input)
            {
                var start = (input[0].IndexOf('.'), 0);
                var end = (input[input.Count - 1].IndexOf('.'), input.Count - 1);
                sum = FindLongestPath(input.Select(c => c.ToArray()).ToArray(), start, end, new bool[input.Count, input[0].Count], true);
            }

            return $"Result Part 2: {sum}";
        }

    }

    public class Graph<T>
    {
        public List<Vertice<T>> Vertices = new List<Vertice<T>>();
        public List<Edge<T>> Edges = new List<Edge<T>>();
        public double LongestPath { get; set; }

        public void FindAllPaths(T s, T d)
        {
            Dictionary<T, bool> isVisited = Vertices.ToDictionary(td => td.Key, td => false);
            List<double> pathList = new List<double>();

            // add source to path[]
            pathList.Add(0);

            // Call recursive utility
            FindAllPathsUtil(s, d, isVisited, pathList);
        }

        // A recursive function to print
        // all paths from 'u' to 'd'.
        // isVisited[] keeps track of
        // vertices in current path.
        // localPathList<> stores actual
        // vertices in the current path
        private void FindAllPathsUtil(T u, T d,
                                       Dictionary<T, bool> isVisited,
                                       List<double> localPathList)
        {
            if (u.Equals(d))
            {
                var l = localPathList.Sum();
                if (l > LongestPath)
                    LongestPath = l;

                return;
            }

            // Mark the current node
            isVisited[u] = true;

            // Recur for all the vertices
            // adjacent to current vertex
            foreach (Edge<T> i in Edges.Where(w => w.Vertices.Any(v => v.Key.Equals(u))))
            {
                var end = i.Vertices.Find(f => !f.Key.Equals(u)).Key;
                if (!isVisited[end])
                {
                    // store current node
                    // in path[]
                    localPathList.Add(i.Length.Value);
                    FindAllPathsUtil(end, d, isVisited,
                                      localPathList);

                    // remove current node
                    // in path[]
                    localPathList.Remove(i.Length.Value);
                }
            }

            // Mark the current node
            isVisited[u] = false;
        }
    }

    public class Edge<T>
    {
        private List<Vertice<T>> _vertices = new List<Vertice<T>>();

        public List<Vertice<T>> Vertices => _vertices;

        public double? Length { get; }

        public Edge(Vertice<T> v1, Vertice<T> v2, double? l = null)
        {
            _vertices.Add(v1);
            _vertices.Add(v2);

            if (l.HasValue)
                Length = l.Value;
        }
    }

    public class Vertice<T>
    {
        public T Key { get; }

        public Vertice(T key)
        {
            Key = key;
        }
    }
}
