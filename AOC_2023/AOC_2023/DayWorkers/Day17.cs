using System.Diagnostics;
using System.Numerics;

namespace AOC_2023.DayWorkers
{
    internal class Day17 : Day
    {
        public override string Execute(string data)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            var input = data.Split(Environment.NewLine)
                            .Where(s => !string.IsNullOrEmpty(s))
                            .Select(s => s.ToArray()
                                          .Select(s => Convert.ToInt16(s.ToString()))
                                          .ToArray())
                            .ToArray();

            return PartOne(input) + "\r\n" + PartTwo(input) + "\r\n" + $"Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        protected override string PartOne(object data)
        {
            int sum = 0;
            if (data is short[][] input)
            {
                var nodes = new List<List<double>>();

                for (int i = 0; i < input.Length; i++)
                {
                    var nodesList = new List<double>();
                    for (int j = 0; j < input[i].Length; j++)
                        nodesList.Add(input[i][j]);

                    nodes.Add(nodesList);
                }

                var astar = new AStar(nodes);
                var path = astar.FindShortestPath((0, 0), (input.Length - 1, input[0].Length - 1));
                if (path != null)
                    sum = (int)path.Last().G;
                // ? < 1028
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = 0; j < input[i].Length; j++)
                    {
                        if (path.Any(p => p.Position == (j, i)))
                            Console.Write('#');
                        else
                            Console.Write('.');
                    }

                    Console.WriteLine();
                }
            }
            return $"Result Part 1: {sum}";
        }

        protected override string PartTwo(object data)
        {
            int sum = 0;
            if (data is object input)
            {


            }

            return $"Result Part 2: {sum}";
        }
    }

    [DebuggerDisplay("F = {F} H = {H}")]
    public class GraphNode
    {
        public (int X, int Y) Position { get; set; }
        public double Weight { get; set; } //Cost of movement to that node
        public double H { get; set; } //Estimated movement cost from given node to final destination
        public double G { get; set; } //Movement cost from start node to given node 
        public double F => G + H;

        public GraphNode? Parent;

        public GraphNode((int X, int Y) pos, double w)
        {
            Position = pos;
            Weight = w;
            Parent = null;
            H = 0;
            G = 0;
        }
    }

    public class GraphNodeComparer : IComparer<GraphNode>
    {
        public int Compare(GraphNode? x, GraphNode? y)
        {
            if (x == null || y == null)
                return 0;

            var result = x.F.CompareTo(y.F);

            if(result == 0)
                result = x.H.CompareTo(y.H);

            return result;
        }
    }

    public class AStar
    {
        private List<List<double>> _weights = new List<List<double>>();
        private HashSet<(int, int)> _closedList = new();
        private PriorityQueue<GraphNode, GraphNode> _openList = new(new GraphNodeComparer());
        private List<GraphNode> _openList2 = new();
        private List<GraphNode> _closedList2 = new();

        public AStar(List<List<double>> weights)
        {
            _weights = weights;
        }

        private double CaluclateH((int X, int Y) current, (int X, int Y) target)
        {
            return Math.Abs(target.X - current.X) + Math.Abs(target.Y - current.Y);
        }

        public List<GraphNode>? FindShortestPath((int X, int Y) start, (int X, int Y) target)
        {
            var startNode = new GraphNode((start.X, start.Y), _weights[start.Y][start.X]);

            if (startNode == null)
                return null;

            startNode.H = CaluclateH(start, target);
            _openList.Enqueue(startNode, startNode);

            while (_openList.Count > 0)
            {
                var q = _openList.Dequeue();
                _closedList.Add(q.Position);

                var neighbours = GetAdjacents(q);
                foreach (var n in neighbours)
                {
                    n.G = q.G + n.Weight;
                    n.H = CaluclateH(n.Position, target);
                    n.Parent = q;

                    if (n.Position == target)
                        return GetPath(n);

                    if (_closedList.Contains(n.Position))
                        continue;

                    if (_openList.UnorderedItems.Any(x => x.Element.Position == n.Position))
                    {
                        var list = _openList.UnorderedItems.First(x => x.Element.Position == n.Position);
                        if (list.Element.F <= n.F)
                            continue;

                        list.Element.G = n.G;
                        //_openList.Enqueue(n, n);
                    }

                    if (!_openList.UnorderedItems.Any(x => x.Element.Position == n.Position))
                        _openList.Enqueue(n, n);
                    //if (!_openList.UnorderedItems.Any(x => x.Element.Position == n.Position && x.Element.F >= n.F)) //Correct number but invalid path
                    //    _openList.Enqueue(n, n);                                                                    //(x.Element.F >= n.F && x.Element.H > n.H))) Correct but too long because of duplicates
                }
            }

            //_openList2.Add(startNode);
            //while (_openList2.Count > 0)
            //{
            //    var q = _openList2.OrderByDescending(o => o.F).Last();

            //    if (q.Position == target)
            //        return GetPath(q);

            //    _openList2.Remove(q);
            //    _closedList2.Add(q);

            //    var neighbours = GetAdjacents(q);
            //    foreach (var n in neighbours)
            //    {
            //        var cost = q.G + n.Weight;
            //        if (_closedList2.Any(a => a.Position == n.Position))
            //            continue;

            //        if (_openList2.Any(a => a.Position == n.Position))
            //        {
            //            var item = _openList2.Find(a => a.Position == n.Position);
            //            if (item.G <= cost)
            //                continue;

            //            item.Parent = q;
            //            item.G = cost;
            //        }
            //        else
            //            n.H = CaluclateH(n.Position, target);

            //        n.G = cost;
            //        n.Parent = q;
            //        _openList2.Add(n);
            //    }
            //    }

            return null;
        }

        private List<GraphNode> GetPath(GraphNode n)
        {
            var path = new List<GraphNode>();
            var node = n;
            while (node.Parent != null)
            {
                path.Add(node);
                node = node.Parent;
            }

            path.Reverse();

            return path;
        }

        private List<GraphNode> GetAdjacents(GraphNode q)
        {
            var adjacents = new List<GraphNode>();
            if (q.Position.Y + 1 < _weights.Count && IsFurtherPathValid(q, q.Position.X, q.Position.Y + 1))
                adjacents.Add(new GraphNode((q.Position.X, q.Position.Y + 1), _weights[q.Position.Y + 1][q.Position.X]));
            if (q.Position.Y - 1 >= 0 && IsFurtherPathValid(q, q.Position.X, q.Position.Y - 1))
                adjacents.Add(new GraphNode((q.Position.X, q.Position.Y - 1), _weights[q.Position.Y - 1][q.Position.X]));
            if (q.Position.X + 1 < _weights[0].Count && IsFurtherPathValid(q, q.Position.X + 1, q.Position.Y))
                adjacents.Add(new GraphNode((q.Position.X + 1, q.Position.Y), _weights[q.Position.Y][q.Position.X + 1]));
            if (q.Position.X - 1 >= 0 && IsFurtherPathValid(q, q.Position.X - 1, q.Position.Y))
                adjacents.Add(new GraphNode((q.Position.X - 1, q.Position.Y), _weights[q.Position.Y][q.Position.X - 1]));

            return adjacents;
        }

        private bool IsFurtherPathValid(GraphNode q, int x, int y)
        {
            if (q.Parent != null)
            {
                if (q.Parent.Position == (x, y))
                    return false;

                if (q.Parent.Parent != null && q.Parent.Parent.Parent != null)
                {
                    var listX = new int[] { q.Parent.Parent.Parent.Position.X, q.Parent.Parent.Position.X, q.Parent.Position.X, q.Position.X };
                    var listY = new int[] { q.Parent.Parent.Parent.Position.Y, q.Parent.Parent.Position.Y, q.Parent.Position.Y, q.Position.Y };

                    if (listX.All(a => a == x) || listY.All(a => a == y))
                        return false;
                }
            }

            return true;
        }
    }
}