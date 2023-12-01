using AOC_2023;

var dayNumber = Console.ReadLine();
if (!string.IsNullOrEmpty(dayNumber))
{
    var day = DaySelector.GetDay(dayNumber);

    var data = Console.ReadLine();
    if (!string.IsNullOrEmpty(data) && day != null)
    {
        var resp = day.Execute(data);
        if (resp != null)
        {
            Console.WriteLine(resp.ToString());
        }
    }
}
