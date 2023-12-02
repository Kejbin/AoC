namespace AOC_2023.DayWorkers
{
    public interface IDay
    {
        string Execute(string data);
        string PartOne(object data);
        string PartTwo(object data);
    }
}