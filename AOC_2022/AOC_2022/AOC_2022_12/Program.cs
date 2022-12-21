
var input = "abaaacccccccccaaaaaaccccccccccccccccaacccccccccccaacaaaaaaaaaaaaaaaaaccaaaaacccaaaaccccccccccccccccccccccccccccccccccccccccccccccccccccccccaaaaa\r\nabaaacccccccccaaaaaacccccccccccccccaaaaccccccccccaaaaaaaacaaaaaaaaaaaccaaaaaaccaaaacccccccccccccccccccccccccccccccccccccccccccccccccccccccaaaaaa\r\nabaaaccccccccccaaaaacccccccccccccccaaaacccccccccccaaaaacccaaaaaaaaaacccaaaaaacccaaccccccccccccccaaaaacccccccccccccccccccccccccccccccccccccaaaaaa\r\nabccccaaccccccaaaaacccccccccaaaaaccaaaaccccccccccccaaaaacaaaaaaaaacccccaaaaaccccccccccccccccccccaaaaacccccccccccccccccaaaccccaaaccccccccccaaacaa\r\nabcccaaaacccccaaaaacccccccccaaaaacccccccccccccccccaaacaaaaaaaaaacccccccaaaaacccccccccccccccccccaaaaaacccccccccccccccccaaaaccaaaaccccccccccccccaa\r\nabcccaaaaacacccccccccccccccaaaaaaccccccccccccccccccaaccaaaaacaaaaccccccccccccccccccccccccccccccaaaaaaccccccccccccccccccaaaaaaaacccccccccccccccaa\r\nabaaaaaaaaaacccccccccccccccaaaaaaccccccccccccccccccccccaaaacccaaaccccccccccccccccccccccccccccccaaaaaacccccccccccccccciiiiijaaaaccccccccccccccccc\r\nabaaaaaaaaaacccccccccccccccaaaaaacccccccccccccccccccccccccccccaaacccccccccccccccccccccccccccccccaaaccccccccccccccccciiiiiijjjaccccccccaaaccccccc\r\nabccaaaaaaccccccccccccccccccaaaccccccccccccccccccccccccccccccccacccccccccccaacccccccccccccccccccccccccccccccccccccciiiiioijjjjaaccccccaaaaaacccc\r\nabccaaaaaacccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccaaaaaacccccccccccccccccccccccccccccccccccciiinnooojjjjjaaccaaaaaaaacccc\r\nabccaaaaaacccccccccccccccccccccccccccccccccccccaacccccaacccccccccccccccccaaaaaacccccccccccccccccccccccccccaaaccccciiinnnoooojjjjjjkkkaaaaaaacccc\r\nabcaaaaaaaaccccccccccccccccccccccccccccccccccccaaaccaaaaaaccccaaacccccccccaaaacccccccccccccccccccccccccccccaaaaccciiinnnouooojjjjkkkkkaaaaaccccc\r\nabccaccccccccccccccccccaaccccccaccccccccccccaaaaaaaaaaaaaacccaaaacccccccccaaaacccccccccccccccccccccccccccaaaaaacchhinnnttuuooooookkkkkkkaaaccccc\r\nabccccccccccccccccccaacaaaccccaaaaaaaaccccccaaaaaaaacaaaaacccaaaacccccccccaccacccccccccccccccccccccccccccaaaaacchhhhnntttuuuooooppppkkkkcaaacccc\r\nabccccccccaaacccccccaaaaaccccccaaaaaaccccccccaaaaaacaaaaaccccaaaaccccccccccccccccccccccccccccaccccccccccccaaaaahhhhnnntttxuuuooppppppkkkcccccccc\r\nabccccccccaaaacccccccaaaaaaccccaaaaaaccaaacccaaaaaacaaaaaccccccccccccccaaccccccccccccccaaaaaaaacccccccccccaachhhhhnnnntttxxuuuuuuuupppkkkccccccc\r\nabccccccccaaaacccccaaaaaaaacccaaaaaaaacaaacacaaaaaaccccccccccccccccccccaacccccccccccccccaaaaaacccccccccccccchhhhmnnnntttxxxxuuuuuuupppkkcccccccc\r\nabacccccccaaaacccccaaaaacaaccaaaaaaaaaaaaaaaaaaccaacccccccccccccccccaaaaaaaaccccccccccccaaaaaaccccccccccccchhhhmmmntttttxxxxuyyyuvvpppklcccccccc\r\nabacccccccccccccccccacaaaccaaaaaaaaaaaaaaaaaaaccccccccccccccccccccccaaaaaaaacccccccccccaaaaaaaaccccccccccccgghmmmtttttxxxxxxyyyyvvvpplllcccccccc\r\nabaccccccccaacccccccccaaaccaaaaaaaacaaaaaaaaaaccccccccccccccccccccccccaaaaccccccccccccaaaaaaaaaaccccccaccccgggmmmtttxxxxxxxyyyyyvvppplllcccccccc\r\nSbaaaccccccaaacaaaccccccccaaaaaaaaacaaaaaaaaacccccccccccccccccccccccccaaaaacccccccccccaaaaaaaaaaaaacaaaccaagggmmmtttxxxEzzzzyyyvvppplllccccccccc\r\nabaacccccccaaaaaaacccccccaaaaaaacaaccaaaaaaaccccccccccccccaaaccccccccaaaaaacccccccccccacacaaacccaaaaaaacaaagggmmmsssxxxxxyyyyyvvvqqqlllccccccccc\r\nabaccccccccaaaaaaccacccaaaaaaaaacccccccaaaaaaccccccccccccaaaaccccccccaaccaacccccccccccccccaaaccccaaaaaaccaagggmmmssssxxwwyyyyyyvvqqqlllccccccccc\r\nabaccccccaaaaaaaaccaacaaaccaaaaaacccccaaaaaaaccccccccccccaaaaccccccccccaacccccccccccccccccaacccccaaaaaaaaaaggggmmmssssswwyywyyyyvvqqlllccccccccc\r\nabaccccccaaaaaaaaacaaaaacccaaaaaacccccaaacaaaccccccccccccaaaaccccccccaaaaaaccccccccccccaacccccccaaaaaaaaaaaaggggmmmossswwyywwyyvvvqqqllccccccccc\r\nabcccccccaaaaaaaaaacaaaaaacaaccccccccaaacccccccccccccccccccccccccccccaaaaaaccccccccccccaaaaacccaaaaaaaaaaaaaaggggoooosswwywwwwvvvvqqqmlccccccccc\r\nabccccccccccaaacaaaaaaaaaacccccccccccaaacaccccccccccccccccccccccccccccaaaaccccccccccccaaaaaccccaaacaaacccaaacagggfooosswwwwwrvvvvqqqqmmccccccccc\r\nabccccccccccaaacccaaaaaaaacccccccccaacaaaaacccccccccccccccccccccccccccaaaaccccccccccccaaaaaacccccccaaacccaaccccfffooosswwwwrrrrrqqqqqmmccccccccc\r\nabccccccccccaacccccccaaccccccccccccaaaaaaaacccccccccccccaaccccccccccccaccaccccccccccccccaaaacccccccaacccccccccccfffoossrwrrrrrrrqqqqmmmccccccccc\r\nabccaaaccccccccccccccaacccccccccccccaaaaaccccccccccccaacaacccccccaaaaacccccccccccccccccaacccccccccccccccccccccccfffoossrrrrrnnnmqqmmmmmccccccccc\r\nabcaaaaccccccccccccccccccccccccccccccaaaaacccccccccccaaaaacccccccaaaaacccaaaccccccccccccccccccccccccccccccccccccfffooorrrrrnnnnmmmmmmmccccaacccc\r\nabcaaaacccccccccccccccccccccccccccccaaacaaccccacccccccaaaaaaccccaaaaaaccccaaaccacccccccccccccccccccccccccccccccccffoooonnnnnnnnmmmmmmccccaaacccc\r\nabccaaacccccccccccccccccccccaaaaaccccaaccccaaaacccccaaaaaaaaccccaaaaaaccccaaaaaaaccccccccccccccccaccaccccccccccccfffooonnnnnnddddddddcccaaaccccc\r\nabccccccccccccccccccccccccccaaaaaccccccccccaaaaaacccaaaaacaacccaaaaaaaccaaaaaaaacccccccccccccccccaaaaccccccccccccfffeonnnnneddddddddddcaaacccccc\r\nabccccccccccaaaccccccccccccaaaaaacccccccccccaaaacccccacaaacccccaacaacccaaaaaaaaacccccccccccccccccaaaacccccccccccccffeeeeeeeeddddddddcccaaacccccc\r\nabcccccccccaaaaccccacccccccaaaaaaccccccccccaaaaacccccccaaaacccaaacaccccaaaaaaaaaccccccccccccccccaaaaaaccccccccccccceeeeeeeeedacccccccccccccccccc\r\nabaccccccccaaaaccccaaacaaacaaaaaaccccccccccaacaaccccccccaaaacaaaacaaacaaaaaaaaaacccccccccccccaacaaaaaacccccccccccccceeeeeeeaaacccccccccccccccaaa\r\nabaaacccccccaaaccccaaaaaaaccaaaccccccccaaacccccccccccccccaaaaaaaacaaaaaaaaaaaaaaacacaaccaaacaaacccaacccccccccccccccccaacccaaaacccccccccccccccaaa\r\nabaaaccccccccccccccaaaaaaccccccccccccccaaacccccccccccccccaaaaaaaccaaaaaaccaacccaccaaaaccaaaaaaaccccccccaaccccccccccccccccccaaacccccccccccccccaaa\r\nabaaccccccccccccccaaaaaaacccccccccccaaaaaaaaccccccccccccccaaaaaaaaaaaaaacaaaccccccaaaaaccaaaaaaccccccaaaaccccccccccccccccccaaaccccccccccccaaaaaa\r\nabaaaccccccccccccaaaaaaaaaacccccccccaaaaaaaacccccccccccaaaaaaaaaaaaaaaaaaacccccccaaaaaacaaaaaaaaaccccaaaaaacccccccccccccccccccccccccccccccaaaaaa";
//var input = "Sabqponm\r\nabcryxxl\r\naccszExk\r\nacctuvwj\r\nabdefghi";
var map = input.Split(Environment.NewLine)
               .Select(s => s.ToCharArray().ToList())
               .ToArray();
var visitedMap = new bool[map.Length, map[0].Count];
(int X, int Y) ? S = null;
(int X, int Y)? E = null;
for (int i = 0; i < map.Length; i++)
{
    if (map[i].Contains('S'))
        S = (map[i].IndexOf('S'), i);
    if (map[i].Contains('E'))
        E = (map[i].IndexOf('E'), i);

    if (S != null && E != null)
        break;
}

GetPath(S.Value, E.Value, true);
GetPath(S.Value, E.Value, false);

Console.WriteLine();

void GetPath((int X, int Y) s, (int X, int Y) e, bool p1)
{
    map[s.Y][s.X] = 'a';
    map[e.Y][e.X] = 'z';

    //Reset visited map
    for (int i = 0; i < map.Length; i++)
        for (int j = 0; j < map[0].Count; j++)
           visitedMap[i, j] = false;

    var a = 0;
    var q = new Queue<((int X, int Y) p, int l)>();

    //Part 1
    if (p1)
    {
        q.Enqueue((S.Value, 0));
        visitedMap[s.Y, s.X] = true;
    }
    //Part 2
    else
        for (int i = 0; i < map.Length; i++)
            for (int j = 0; j < map[0].Count; j++)
            {
                if (map[i][j] == 'a')
                {
                    q.Enqueue(((j, i), 0));
                    visitedMap[i, j] = true;
                }
            }

    //BTS
    while (q.Any())
        {
            var item = q.Dequeue();

            if ((e.X == item.p.X && e.Y == item.p.Y))
            {
                a = item.l;
                break;
            }

            if (item.p.Y - 1 >= 0
                && visitedMap[item.p.Y - 1, item.p.X] == false
                && map[item.p.Y][item.p.X] - map[item.p.Y - 1][item.p.X] >= -1)
            {
                q.Enqueue(((item.p.X, item.p.Y - 1), item.l + 1));
                visitedMap[item.p.Y - 1, item.p.X] = true;
            }

            if (item.p.Y + 1 < map.Length
                && visitedMap[item.p.Y + 1, item.p.X] == false
                && map[item.p.Y][item.p.X] - map[item.p.Y + 1][item.p.X] >= -1)
            {
                q.Enqueue(((item.p.X, item.p.Y + 1), item.l + 1));
                visitedMap[item.p.Y + 1, item.p.X] = true;
            }

            if (item.p.X - 1 >= 0
                && visitedMap[item.p.Y, item.p.X - 1] == false
                && map[item.p.Y][item.p.X] - map[item.p.Y][item.p.X - 1] >= -1)
            {
                q.Enqueue(((item.p.X - 1, item.p.Y), item.l + 1));
                visitedMap[item.p.Y, item.p.X - 1] = true;
            }

            if (item.p.X + 1 < map[0].Count
                && visitedMap[item.p.Y, item.p.X + 1] == false
                && map[item.p.Y][item.p.X] - map[item.p.Y][item.p.X + 1] >= -1)
            {
                q.Enqueue(((item.p.X + 1, item.p.Y), item.l + 1));
                visitedMap[item.p.Y, item.p.X + 1] = true;
            }
        }

    //Output visited places on map
    for (int i = 0; i < map.Length; i++)
    {
        for (int j = 0; j < map[i].Count; j++)
        {
            if (visitedMap[i, j])
                Console.Write("*");
            else Console.Write(".");
        }

        Console.WriteLine();
    }

    Console.WriteLine(a);
}


//void CheckNextPoint(int x,int  y, int xn, int yn, Path path)
//{

//    if (xn < 0
//        || yn < 0
//        || xn > map[0].Count - 1
//        || yn > map.Length - 1
//        || map[y][x] - map[yn][xn] < -1
//        || path.Steps.Contains((xn, yn))
//        || visitedMap[yn, xn])
//    {
//        return;
//    }
//    else if ((E.Value.X == xn && E.Value.Y == yn))
//    {
//        path.Steps.Add((xn, yn));
//        paths.Add(new Path { Steps = path.Steps.Select(s => (s.X, s.Y)).ToHashSet() });
//        path.Steps.Remove((xn, yn));
//        return;
//    }
//    else
//    {
//        visitedMap[yn, xn] = true;
//        path.Steps.Add((xn, yn));
//        CheckNextPoint(xn, yn, xn + 1, yn, path);
//        CheckNextPoint(xn, yn, xn, yn + 1, path);
//        CheckNextPoint(xn, yn, xn - 1, yn, path);
//        CheckNextPoint(xn, yn, xn, yn - 1, path);
//        path.Steps.Remove((xn, yn));
//    }
//}
