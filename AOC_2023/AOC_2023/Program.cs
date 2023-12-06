using AOC_2023;

Console.WriteLine("Select number of the day you wish to check:");
var dayNumber = Console.ReadLine();
if (!string.IsNullOrEmpty(dayNumber))
{
    var day = DaySelector.GetDay(dayNumber);

    var path = Path.Combine(Environment.CurrentDirectory, "DayInputs", $"Day{dayNumber}.txt");
    var data = File.ReadAllText(path);
    //var data = "Time:      7  15   30\r\nDistance:  9  40  200";

    if (!string.IsNullOrEmpty(data) && day != null)
    {
        var resp = day.Execute(data);

        if (!string.IsNullOrEmpty(resp))
        {
            Console.WriteLine(resp.ToString());
        }
    }
}
