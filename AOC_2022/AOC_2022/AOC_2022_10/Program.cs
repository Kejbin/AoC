var input = "addx 2\r\naddx 15\r\naddx -11\r\naddx 6\r\nnoop\r\nnoop\r\nnoop\r\naddx -1\r\naddx 5\r\naddx -1\r\naddx 5\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\naddx 7\r\naddx -1\r\naddx 3\r\naddx 1\r\naddx 5\r\naddx 1\r\nnoop\r\naddx -38\r\nnoop\r\naddx 1\r\naddx 6\r\naddx 3\r\nnoop\r\naddx -8\r\nnoop\r\naddx 13\r\naddx 2\r\naddx 3\r\naddx -2\r\naddx 2\r\nnoop\r\naddx 3\r\naddx 9\r\naddx -2\r\naddx 2\r\naddx -10\r\naddx 11\r\naddx 2\r\naddx -14\r\naddx -21\r\naddx 2\r\nnoop\r\naddx 5\r\naddx 29\r\naddx -2\r\nnoop\r\naddx -19\r\nnoop\r\naddx 2\r\naddx 11\r\naddx -10\r\naddx 2\r\naddx 5\r\naddx -9\r\nnoop\r\naddx 14\r\naddx 2\r\naddx 3\r\naddx -2\r\naddx 3\r\naddx 1\r\nnoop\r\naddx -37\r\nnoop\r\naddx 13\r\naddx -8\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\naddx 13\r\naddx -5\r\naddx 3\r\naddx 3\r\naddx 3\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\naddx 6\r\naddx 3\r\naddx 1\r\naddx 5\r\naddx -15\r\naddx 5\r\naddx -27\r\naddx 30\r\naddx -23\r\naddx 33\r\naddx -32\r\naddx 2\r\naddx 5\r\naddx 2\r\naddx -16\r\naddx 17\r\naddx 2\r\naddx -10\r\naddx 17\r\naddx 10\r\naddx -9\r\naddx 2\r\naddx 2\r\naddx 5\r\naddx -29\r\naddx -8\r\nnoop\r\nnoop\r\nnoop\r\naddx 19\r\naddx -11\r\naddx -1\r\naddx 6\r\nnoop\r\nnoop\r\naddx -1\r\naddx 3\r\nnoop\r\naddx 3\r\naddx 2\r\naddx -3\r\naddx 11\r\naddx -1\r\naddx 5\r\naddx -2\r\naddx 5\r\naddx 2\r\nnoop\r\nnoop\r\naddx 1\r\nnoop\r\nnoop";
//var input = "addx 15\r\naddx -11\r\naddx 6\r\naddx -3\r\naddx 5\r\naddx -1\r\naddx -8\r\naddx 13\r\naddx 4\r\nnoop\r\naddx -1\r\naddx 5\r\naddx -1\r\naddx 5\r\naddx -1\r\naddx 5\r\naddx -1\r\naddx 5\r\naddx -1\r\naddx -35\r\naddx 1\r\naddx 24\r\naddx -19\r\naddx 1\r\naddx 16\r\naddx -11\r\nnoop\r\nnoop\r\naddx 21\r\naddx -15\r\nnoop\r\nnoop\r\naddx -3\r\naddx 9\r\naddx 1\r\naddx -3\r\naddx 8\r\naddx 1\r\naddx 5\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\naddx -36\r\nnoop\r\naddx 1\r\naddx 7\r\nnoop\r\nnoop\r\nnoop\r\naddx 2\r\naddx 6\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\naddx 1\r\nnoop\r\nnoop\r\naddx 7\r\naddx 1\r\nnoop\r\naddx -13\r\naddx 13\r\naddx 7\r\nnoop\r\naddx 1\r\naddx -33\r\nnoop\r\nnoop\r\nnoop\r\naddx 2\r\nnoop\r\nnoop\r\nnoop\r\naddx 8\r\nnoop\r\naddx -1\r\naddx 2\r\naddx 1\r\nnoop\r\naddx 17\r\naddx -9\r\naddx 1\r\naddx 1\r\naddx -3\r\naddx 11\r\nnoop\r\nnoop\r\naddx 1\r\nnoop\r\naddx 1\r\nnoop\r\nnoop\r\naddx -13\r\naddx -19\r\naddx 1\r\naddx 3\r\naddx 26\r\naddx -30\r\naddx 12\r\naddx -1\r\naddx 3\r\naddx 1\r\nnoop\r\nnoop\r\nnoop\r\naddx -9\r\naddx 18\r\naddx 1\r\naddx 2\r\nnoop\r\nnoop\r\naddx 9\r\nnoop\r\nnoop\r\nnoop\r\naddx -1\r\naddx 2\r\naddx -37\r\naddx 1\r\naddx 3\r\nnoop\r\naddx 15\r\naddx -21\r\naddx 22\r\naddx -6\r\naddx 1\r\nnoop\r\naddx 2\r\naddx 1\r\nnoop\r\naddx -10\r\nnoop\r\nnoop\r\naddx 20\r\naddx 1\r\naddx 2\r\naddx 2\r\naddx -6\r\naddx -11\r\nnoop\r\nnoop\r\nnoop";
var x = 1;
var check = 20;
var pixelCheck = 40;
var inputArray = input.Split(Environment.NewLine);
var signals = new List<int>();
var sprite = new int[] { 1,2,3 };
var cycles = 0;

foreach (var item in inputArray)
{
    var operation = item.Split(" ");
    CheckForSignal();
    DrawPixes();

    if (operation[0] == "addx")
    {
        CheckForSignal();
        DrawPixes();
        x += int.Parse(operation[1]);
    }
}

void DrawPixes()
{
    sprite[0] = x + pixelCheck - 40;
    sprite[1] = x + pixelCheck - 39;
    sprite[2] = x + pixelCheck - 38;

    if (sprite.Contains(cycles)) Console.Write("#");
    else Console.Write(".");

    if (cycles == pixelCheck)
    {
        pixelCheck += 40;
        Console.WriteLine("");

        //if (sprite.Contains(cycles)) Console.WriteLine("#");
        //else Console.WriteLine(".");
    }
}

void CheckForSignal()
{
    cycles++;
    if (cycles == check)
    {
        signals.Add(check * x);
        check += 40;
    }
}

Console.WriteLine(signals.Sum());
