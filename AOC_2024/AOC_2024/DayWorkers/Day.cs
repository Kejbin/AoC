namespace AOC_2024.DayWorkers
{
    public abstract class Day
    {
        public abstract string Execute(string data);
        protected abstract string PartOne(object data);
        protected abstract string PartTwo(object data);
    }
}