// See https://aka.ms/new-console-template for more information
//var input = "Monkey 0:\r\n  Starting items: 64, 89, 65, 95\r\n  Operation: new = old * 7\r\n  Test: divisible by 3\r\n    If true: throw to monkey 4\r\n    If false: throw to monkey 1\r\n\r\nMonkey 1:\r\n  Starting items: 76, 66, 74, 87, 70, 56, 51, 66\r\n  Operation: new = old + 5\r\n  Test: divisible by 13\r\n    If true: throw to monkey 7\r\n    If false: throw to monkey 3\r\n\r\nMonkey 2:\r\n  Starting items: 91, 60, 63\r\n  Operation: new = old * old\r\n  Test: divisible by 2\r\n    If true: throw to monkey 6\r\n    If false: throw to monkey 5\r\n\r\nMonkey 3:\r\n  Starting items: 92, 61, 79, 97, 79\r\n  Operation: new = old + 6\r\n  Test: divisible by 11\r\n    If true: throw to monkey 2\r\n    If false: throw to monkey 6\r\n\r\nMonkey 4:\r\n  Starting items: 93, 54\r\n  Operation: new = old * 11\r\n  Test: divisible by 5\r\n    If true: throw to monkey 1\r\n    If false: throw to monkey 7\r\n\r\nMonkey 5:\r\n  Starting items: 60, 79, 92, 69, 88, 82, 70\r\n  Operation: new = old + 8\r\n  Test: divisible by 17\r\n    If true: throw to monkey 4\r\n    If false: throw to monkey 0\r\n\r\nMonkey 6:\r\n  Starting items: 64, 57, 73, 89, 55, 53\r\n  Operation: new = old + 1\r\n  Test: divisible by 19\r\n    If true: throw to monkey 0\r\n    If false: throw to monkey 5\r\n\r\nMonkey 7:\r\n  Starting items: 62\r\n  Operation: new = old + 4\r\n  Test: divisible by 7\r\n    If true: throw to monkey 3\r\n    If false: throw to monkey 2";
var input = "Monkey 0:\r\n  Starting items: 79, 98\r\n  Operation: new = old * 19\r\n  Test: divisible by 23\r\n    If true: throw to monkey 2\r\n    If false: throw to monkey 3\r\n\r\nMonkey 1:\r\n  Starting items: 54, 65, 75, 74\r\n  Operation: new = old + 6\r\n  Test: divisible by 19\r\n    If true: throw to monkey 2\r\n    If false: throw to monkey 0\r\n\r\nMonkey 2:\r\n  Starting items: 79, 60, 97\r\n  Operation: new = old * old\r\n  Test: divisible by 13\r\n    If true: throw to monkey 1\r\n    If false: throw to monkey 3\r\n\r\nMonkey 3:\r\n  Starting items: 74\r\n  Operation: new = old + 3\r\n  Test: divisible by 17\r\n    If true: throw to monkey 0\r\n    If false: throw to monkey 1";
var inputMonkeys = input.Split("Monkey ");
var monkeys = new List<Monkey>();
var monkeys2 = new List<Monkey>();
foreach (var inputMonkey in inputMonkeys) {
    if (!string.IsNullOrEmpty(inputMonkey))
    {
        var monkey = inputMonkey.Split(Environment.NewLine);
        monkeys.Add(new Monkey
        {
            Id = int.Parse(monkey[0].Split(":").First()),
            Items = new Queue<int>(monkey[1].Substring(18).Split(", ").Select(i => int.Parse(i))),
            Operation = monkey[2].Substring(19),
            DivideBy = int.Parse(monkey[3].Substring(21)),
            Monkey1 = int.Parse(monkey[4].Substring(29)),
            Monkey2 = int.Parse(monkey[5].Substring(30))
        });
        monkeys2.Add(new Monkey
        {
            Id = int.Parse(monkey[0].Split(":").First()),
            Items = new Queue<int>(monkey[1].Substring(18).Split(", ").Select(i => int.Parse(i))),
            Operation = monkey[2].Substring(19),
            DivideBy = int.Parse(monkey[3].Substring(21)),
            Monkey1 = int.Parse(monkey[4].Substring(29)),
            Monkey2 = int.Parse(monkey[5].Substring(30))
        });
    }
}

CalculateRounds(monkeys, 20, 3);
//CalculateRounds(monkeys2, 10000, 1);
CalculateRounds2();
Console.WriteLine(monkeys.Select(m => m.Insepctions).OrderByDescending(a => a).Take(2).Aggregate((a,b) => a * b));
Console.WriteLine(monkeys2.Select(m => m.Insepctions).OrderByDescending(a => a).Take(2).Aggregate((a, b) => a * b));

void CalculateRounds(List<Monkey> list, int rounds, int divide)
{
    for (int round = 0; round < rounds;)
    {
        for (int i = 0; i < list.Count; i++)
        {
            while (list[i].Items.Count > 0)
            {
                var oldWorryLevel = list[i].Items.Dequeue();
                list[i].Insepctions++;
                var operation = list[i].Operation.Split(" ");
                var l = operation[0] == "old" ? oldWorryLevel : int.Parse(operation[0]);
                var r = operation[2] == "old" ? oldWorryLevel : int.Parse(operation[2]);
                var newWorryLevel = 0;
                switch (operation[1])
                {
                    case "*":
                        newWorryLevel = l * r;
                        break;

                    case "+":
                        newWorryLevel = l + r;
                        break;
                }

                var dividedWorryLevel = newWorryLevel / divide;

                if (dividedWorryLevel % list[i].DivideBy == 0)
                    list[list[i].Monkey1].Items.Enqueue(dividedWorryLevel);
                else
                    list[list[i].Monkey2].Items.Enqueue(dividedWorryLevel);
            }
        }

        round++;
    }
}

void CalculateRounds2()
{
    for (int round = 0; round < 10001;)
    {
        for (int i = 0; i < monkeys2.Count; i++)
        {
            while (monkeys2[i].Items.Count > 0)
            {
                var oldWorryLevel = monkeys2[i].Items.Dequeue();
                monkeys2[i].Insepctions++;
                var operation = monkeys2[i].Operation.Split(" ");
                var l = operation[0] == "old" ? oldWorryLevel : int.Parse(operation[0]);
                var r = operation[2] == "old" ? oldWorryLevel : int.Parse(operation[2]);
                var newWorryLevel = 0;
                switch (operation[1])
                {
                    case "*":
                        newWorryLevel = l * r;
                        break;

                    case "+":
                        newWorryLevel = l + r;
                        break;
                }

                var dividedWorryLevel = newWorryLevel;

                if (dividedWorryLevel % monkeys2[i].DivideBy == 0)
                    monkeys2[monkeys2[i].Monkey1].Items.Enqueue(dividedWorryLevel);
                else
                    monkeys2[monkeys2[i].Monkey2].Items.Enqueue(dividedWorryLevel);
            }
        }

        round++;
    }
}

public class Monkey
{
    public int Id { get; set; }
    public Queue<int> Items { get; set; }
    public int Monkey1 { get; set; }
    public int Monkey2 { get; set; }
    public string Operation { get; set; }
    public int DivideBy { get; set; }
    public long Insepctions { get; set; }
}
