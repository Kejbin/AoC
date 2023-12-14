using AOC_2023;

Console.WriteLine("Select number of the day you wish to check:");
var dayNumber = Console.ReadLine();
if (!string.IsNullOrEmpty(dayNumber))
{
    var day = DaySelector.GetDay(dayNumber);

    var path = Path.Combine(Environment.CurrentDirectory, "DayInputs", $"Day{dayNumber}.txt");
    var data = File.ReadAllText(path);
    //Test input
    //data = "..F7.\r\n.FJ|.\r\nSJ.L7\r\n|F--J\r\nLJ...";
    //data = "???.### 1,1,3\r\n.??..??...?##. 1,1,3\r\n?#?#?#?#?#?#?#? 1,3,1,6\r\n????.#...#... 4,1,1\r\n????.######..#####. 1,6,5\r\n?###???????? 3,2,1";
    //data = "#.##..##.\r\n..#.##.#.\r\n##......#\r\n##......#\r\n..#.##.#.\r\n..##..##.\r\n#.#.##.#.\r\n\r\n#...##..#\r\n#....#..#\r\n..##..###\r\n#####.##.\r\n#####.##.\r\n..##..###\r\n#....#..#";
    data = "O....#....\r\nO.OO#....#\r\n.....##...\r\nOO.#O....O\r\n.O.....O#.\r\nO.#..O.#.#\r\n..O..#O..O\r\n.......O..\r\n#....###..\r\n#OO..#....";

    if (!string.IsNullOrEmpty(data) && day != null)
    {
        var resp = day.Execute(data);

        if (!string.IsNullOrEmpty(resp))
        {
            Console.WriteLine(resp.ToString());
        }
    }
}
