using AOC_2023;

Console.WriteLine("Select number of the day you wish to check:");
var dayNumber = Console.ReadLine();
if (!string.IsNullOrEmpty(dayNumber))
{
    var day = DaySelector.GetDay(dayNumber);

    var path = Path.Combine(Environment.CurrentDirectory, "DayInputs", $"Day{dayNumber}.txt");
    var data = File.ReadAllText(path);
    //Test input
    //data = "???.### 1,1,3\r\n.??..??...?##. 1,1,3\r\n?#?#?#?#?#?#?#? 1,3,1,6\r\n????.#...#... 4,1,1\r\n????.######..#####. 1,6,5\r\n?###???????? 3,2,1";
    //data = "2413432311323\r\n3215453535623\r\n3255245654254\r\n3446585845452\r\n4546657867536\r\n1438598798454\r\n4457876987766\r\n3637877979653\r\n4654967986887\r\n4564679986453\r\n1224686865563\r\n2546548887735\r\n4322674655533";
    //data = "px{a<2006:qkq,m>2090:A,rfg}\r\npv{a>1716:R,A}\r\nlnx{m>1548:A,A}\r\nrfg{s<537:gd,x>2440:R,A}\r\nqs{s>3448:A,lnx}\r\nqkq{x<1416:A,crn}\r\ncrn{x>2662:A,R}\r\nin{s<1351:px,qqz}\r\nqqz{s>2770:qs,m<1801:hdj,R}\r\ngd{a>3333:R,R}\r\nhdj{m>838:A,pv}\r\n\r\n{x=787,m=2655,a=1222,s=2876}\r\n{x=1679,m=44,a=2067,s=496}\r\n{x=2036,m=264,a=79,s=2244}\r\n{x=2461,m=1339,a=466,s=291}\r\n{x=2127,m=1623,a=2188,s=1013}";
    //data = "...........\r\n.....###.#.\r\n.###.##..#.\r\n..#.#...#..\r\n....#.#....\r\n.##..S####.\r\n.##..#...#.\r\n.......##..\r\n.##.#.####.\r\n.##..##.##.\r\n...........";
    //data = "1,0,1~1,2,1\r\n0,0,2~2,0,2\r\n0,2,3~2,2,3\r\n0,0,4~0,2,4\r\n2,0,5~2,2,5\r\n0,1,6~2,1,6\r\n1,1,8~1,1,9";

    if (!string.IsNullOrEmpty(data) && day != null)
    {
        var resp = day.Execute(data);

        if (!string.IsNullOrEmpty(resp))
        {
            Console.WriteLine(resp.ToString());
        }
    }
}
