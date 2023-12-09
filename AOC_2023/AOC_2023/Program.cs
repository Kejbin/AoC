using AOC_2023;

Console.WriteLine("Select number of the day you wish to check:");
var dayNumber = Console.ReadLine();
if (!string.IsNullOrEmpty(dayNumber))
{
    var day = DaySelector.GetDay(dayNumber);

    var path = Path.Combine(Environment.CurrentDirectory, "DayInputs", $"Day{dayNumber}.txt");
    var data = File.ReadAllText(path);
    //var data = "0 3 6 9 12 15\r\n1 3 6 10 15 21\r\n10 13 16 21 30 45";

    if (!string.IsNullOrEmpty(data) && day != null)
    {
        var resp = day.Execute(data);

        if (!string.IsNullOrEmpty(resp))
        {
            Console.WriteLine(resp.ToString());
        }
    }
}
