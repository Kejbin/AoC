using static System.Reflection.Metadata.BlobBuilder;

namespace AOC_2023.DayWorkers
{
    internal class Day2 : IDay
    {
        public string Execute(string data)
        {
            int gameIterator = 1;
            var games = new List<Game>();
            foreach (var item in data.Split("\r\n"))
            {
                var game = new Game() { Id = gameIterator };
                if (!string.IsNullOrEmpty(item))
                {
                    var split = item.Split(':');
                    var sets = split[1].Split(";");

                    foreach (var set in sets)
                    {
                        var gameSet = new Set();
                        foreach (var c in set.Split(','))
                        {
                            if (c.Contains("red"))
                                gameSet.Reds = Convert.ToInt32(c.Split(" ")[1]);
                            else if (c.Contains("blue"))
                                gameSet.Blues = Convert.ToInt32(c.Split(" ")[1]);
                            else if (c.Contains("green"))
                                gameSet.Greens = Convert.ToInt32(c.Split(" ")[1]);                            
                        }

                        game.Sets.Add(gameSet);
                    }

                    gameIterator++;
                    games.Add(game);
                }
            }

            return PartOne(games) + "\r\n" + PartTwo(games);
        }
        public string PartOne(object data)
        {
            if (data is List<Game> games) 
                return $"Result Part 1: {games.Where(g => g.Sets.All(s => s.Reds <= 12 && s.Greens <= 13 && s.Blues <= 14)).Select(s => s.Id).Sum()}";

            return "";
        }

        public string PartTwo(object data)
        {
            int sum = 0;
            if (data is List<Game> games)
            {
                foreach (var item in games)
                {
                    var blues = item.Sets.Select(s => s.Blues);
                    var reds = item.Sets.Select(s => s.Reds);
                    var greens = item.Sets.Select(s => s.Greens);

                    sum += blues.Max() * reds.Max() * greens.Max();
                }
            }

            return $"Result Part 2: {sum}";
        }

        public class Game
        {
            public int Id { get; set; }

            public List<Set> Sets { get; set; } = new();

        }

        public class Set
        {
            public int Blues { get; set; }
            public int Reds { get; set; }
            public int Greens { get; set; }
        }
    }
}