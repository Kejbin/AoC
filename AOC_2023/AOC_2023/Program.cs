using AOC_2023;

Console.WriteLine("Select number of the day you wish to check:");
var dayNumber = Console.ReadLine();
if (!string.IsNullOrEmpty(dayNumber))
{
    var day = DaySelector.GetDay(dayNumber);

    //var path = Path.Combine(Environment.CurrentDirectory, "DayInputs", $"Day{dayNumber}.txt");
    //var data = File.ReadAllText(path);
    var data = "32T3K 765\r\nT55J5 684\r\nKK677 28\r\nKTJJT 220\r\nQQQJA 483";

    if (!string.IsNullOrEmpty(data) && day != null)
    {
        var resp = day.Execute(data);

        if (!string.IsNullOrEmpty(resp))
        {
            Console.WriteLine(resp.ToString());
        }
    }
}
