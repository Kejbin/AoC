using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Security.Cryptography;

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
                List<List<Node>> list = new List<List<Node>>(input.Length);

                for (int i = 0; i < input.Length; i++)
                {
                    var nodes = new List<Node>(input[i].Length);
                    for (int j = 0; j < input[i].Length; j++)
                        nodes.Add(new Node(new Vector2(j,i), true, input[i][j]));

                    list.Add(nodes);
                }

                var aStar = new Astar(list);
                var resp = aStar.FindPath(new Vector2(0,0), new Vector2(input.Length - 1, input[0].Length - 1));
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

    public class Node
    {
        // Change this depending on what the desired size is for each element in the grid
        public static int NODE_SIZE = 1;
        public Node Parent;
        public Vector2 Position;
        public float DistanceToTarget;
        public float Cost;
        public float Weight;
        public float F
        {
            get
            {
                if (DistanceToTarget != -1 && Cost != -1)
                    return DistanceToTarget + Cost;
                else
                    return -1;
            }
        }

        public bool Walkable = true;


        public Node(Vector2 pos, bool walkable, float weight = 1)
        {
            Parent = null;
            Position = pos;
            DistanceToTarget = -1;
            Cost = 1;
            Weight = weight;
            //Walkable = walkable;
        }
    }

    public class Astar
    {
        List<List<Node>> Grid;
        int GridRows
        {
            get
            {
                return Grid[0].Count;
            }
        }
        int GridCols
        {
            get
            {
                return Grid.Count;
            }
        }

        public Astar(List<List<Node>> grid)
        {
            Grid = grid;
        }

        public Stack<Node> FindPath(Vector2 Start, Vector2 End)
        {
            Node start = new Node(new Vector2((int)(Start.X / Node.NODE_SIZE), (int)(Start.Y / Node.NODE_SIZE)), true);
            Node end = new Node(new Vector2((int)(End.X / Node.NODE_SIZE), (int)(End.Y / Node.NODE_SIZE)), true);

            Stack<Node> Path = new Stack<Node>();
            PriorityQueue<Node, float> OpenList = new PriorityQueue<Node, float>();
            List<Node> ClosedList = new List<Node>();
            List<Node> adjacencies;
            Node current = start;

            // add start node to Open List
            OpenList.Enqueue(start, start.F);

            while (OpenList.Count != 0 && !ClosedList.Exists(x => x.Position == end.Position))
            {
                current = OpenList.Dequeue();
                ClosedList.Add(current);
                adjacencies = GetAdjacentNodes(current);

                foreach (Node n in adjacencies)
                {
                    if (!ClosedList.Contains(n) && n.Walkable)
                    {
                        bool isFound = false;
                        foreach (var oLNode in OpenList.UnorderedItems)
                        {
                            if (oLNode.Element == n)
                            {
                                isFound = true;
                            }
                        }
                        if (!isFound)
                        {
                            n.Parent = current;
                            n.DistanceToTarget = Math.Abs(n.Position.X - end.Position.X) + Math.Abs(n.Position.Y - end.Position.Y);
                            n.Cost = n.Weight + n.Parent.Cost;
                            OpenList.Enqueue(n, n.F);
                        }
                    }
                }
            }

            // construct path, if end was not closed return null
            if (!ClosedList.Exists(x => x.Position == end.Position))
            {
                return null;
            }

            // if all good, return path
            Node temp = ClosedList[ClosedList.IndexOf(current)];
            if (temp == null) return null;
            do
            {
                Path.Push(temp);
                temp = temp.Parent;
            } while (temp != start && temp != null);
            return Path;
        }

        private List<Node> GetAdjacentNodes(Node n)
        {
            bool IsThirdStep(int x, int y)
            {
                if (n.Parent == null || n.Parent.Parent == null)
                    return true;

                //X
                if (n.Position.X == x 
                    && n.Parent.Position.X == x 
                    && n.Parent.Parent.Position.X == x)
                    return false;

                //Y
                if (n.Position.Y == y
                    && n.Parent.Position.Y == y
                    && n.Parent.Parent.Position.Y == y)
                    return false;

                return true;
            }

            List<Node> temp = new List<Node>();

            int row = (int)n.Position.Y;
            int col = (int)n.Position.X;

            if (row + 1 < GridRows && IsThirdStep(row + 1, col))
            {
                temp.Add(Grid[col][row + 1]);
            }
            if (row - 1 >= 0 && IsThirdStep(row - 1, col))
            {
                temp.Add(Grid[col][row - 1]);
            }
            if (col - 1 >= 0 && IsThirdStep(row, col - 1))
            {
                temp.Add(Grid[col - 1][row]);
            }
            if (col + 1 < GridCols && IsThirdStep(row, col + 1))
            {
                temp.Add(Grid[col + 1][row]);
            }

            return temp;
        }
    }
}