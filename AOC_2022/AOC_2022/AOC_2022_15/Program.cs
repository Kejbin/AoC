﻿
var input = "Sensor at x=2793338, y=1910659: closest beacon is at x=2504930, y=2301197\r\nSensor at x=2887961, y=129550: closest beacon is at x=2745008, y=-872454\r\nSensor at x=3887055, y=2785942: closest beacon is at x=4322327, y=2605441\r\nSensor at x=3957399, y=2164042: closest beacon is at x=3651713, y=1889668\r\nSensor at x=1268095, y=1265989: closest beacon is at x=1144814, y=2000000\r\nSensor at x=2093967, y=2103436: closest beacon is at x=2504930, y=2301197\r\nSensor at x=2980126, y=1348046: closest beacon is at x=3651713, y=1889668\r\nSensor at x=508134, y=3998686: closest beacon is at x=1123963, y=4608563\r\nSensor at x=2982740, y=3604350: closest beacon is at x=2756683, y=3240616\r\nSensor at x=2372671, y=3929034: closest beacon is at x=2756683, y=3240616\r\nSensor at x=437628, y=1124644: closest beacon is at x=570063, y=959065\r\nSensor at x=3271179, y=3268845: closest beacon is at x=3444757, y=3373782\r\nSensor at x=1899932, y=730465: closest beacon is at x=570063, y=959065\r\nSensor at x=1390358, y=3881569: closest beacon is at x=1123963, y=4608563\r\nSensor at x=554365, y=989190: closest beacon is at x=570063, y=959065\r\nSensor at x=2225893, y=2703661: closest beacon is at x=2504930, y=2301197\r\nSensor at x=3755905, y=1346206: closest beacon is at x=3651713, y=1889668\r\nSensor at x=3967103, y=3930797: closest beacon is at x=3444757, y=3373782\r\nSensor at x=3534099, y=2371166: closest beacon is at x=3651713, y=1889668\r\nSensor at x=3420789, y=1720583: closest beacon is at x=3651713, y=1889668\r\nSensor at x=2222479, y=3278186: closest beacon is at x=2756683, y=3240616\r\nSensor at x=100457, y=871319: closest beacon is at x=570063, y=959065\r\nSensor at x=1330699, y=2091946: closest beacon is at x=1144814, y=2000000\r\nSensor at x=598586, y=99571: closest beacon is at x=570063, y=959065\r\nSensor at x=3436099, y=3392932: closest beacon is at x=3444757, y=3373782\r\nSensor at x=3338431, y=3346334: closest beacon is at x=3444757, y=3373782\r\nSensor at x=3892283, y=688090: closest beacon is at x=3651713, y=1889668\r\nSensor at x=1485577, y=1929020: closest beacon is at x=1144814, y=2000000\r\nSensor at x=2991003, y=2951060: closest beacon is at x=2756683, y=3240616\r\nSensor at x=2855486, y=2533468: closest beacon is at x=2504930, y=2301197\r\nSensor at x=750865, y=1619637: closest beacon is at x=1144814, y=2000000\r\nSensor at x=3378101, y=3402212: closest beacon is at x=3444757, y=3373782\r\nSensor at x=3515528, y=2950404: closest beacon is at x=3444757, y=3373782\r\nSensor at x=163133, y=2640553: closest beacon is at x=-1016402, y=3057364\r\nSensor at x=1765550, y=3021994: closest beacon is at x=2756683, y=3240616\r\nSensor at x=534625, y=1056421: closest beacon is at x=570063, y=959065\r\nSensor at x=3418549, y=3380980: closest beacon is at x=3444757, y=3373782\r\nSensor at x=29, y=389033: closest beacon is at x=570063, y=959065";
var line = 2000000;
//var input = "Sensor at x=2, y=18: closest beacon is at x=-2, y=15\r\nSensor at x=9, y=16: closest beacon is at x=10, y=16\r\nSensor at x=13, y=2: closest beacon is at x=15, y=3\r\nSensor at x=12, y=14: closest beacon is at x=10, y=16\r\nSensor at x=10, y=20: closest beacon is at x=10, y=16\r\nSensor at x=14, y=17: closest beacon is at x=10, y=16\r\nSensor at x=8, y=7: closest beacon is at x=2, y=10\r\nSensor at x=2, y=0: closest beacon is at x=2, y=10\r\nSensor at x=0, y=11: closest beacon is at x=2, y=10\r\nSensor at x=20, y=14: closest beacon is at x=25, y=17\r\nSensor at x=17, y=20: closest beacon is at x=21, y=22\r\nSensor at x=16, y=7: closest beacon is at x=15, y=3\r\nSensor at x=14, y=3: closest beacon is at x=15, y=3\r\nSensor at x=20, y=1: closest beacon is at x=15, y=3";
//var line = 10;

var inputArray = input.Split(Environment.NewLine).Select(s => s.Split(new char[] { ',', ':' }));

HashSet<(int X, int Y, string Value)> Points = new();
HashSet<(int X, int Y, int R)> Sensors = new();
List<(int X, int Y, string Value)> Beacons = new();
(int X, int Y) point = new();
//Part 1
//Prep inputs
foreach (var item in inputArray)
{
    var S = (
        X: int.Parse(item[0].Substring(12)),
        Y: int.Parse(item[1].Substring(3)),
        "S");

    var B = (
        X: int.Parse(item[2].Substring(24)),
        Y: int.Parse(item[3].Substring(3)),
        "B");

    Points.Add(S);
    Points.Add(B);
    Sensors.Add((S.X, S.Y, Math.Abs(S.X - B.X) + Math.Abs(S.Y - B.Y)));
    Beacons.Add(B);
}

//Part 1
//Check diamonds for sensor range and get positions of chosen row
//Part 2
//Get point for part 2 assuming it's somewhere outside of processed sensor range
for (int k = 0, countTo = Sensors.Count; k < countTo; k++)
{
    var S = Sensors.ElementAt(k);
    var B = Beacons.ElementAt(k);

    var beaconFound = true;
    var xD = B.Y > S.Y ? -1 : 1;
    var yD = B.X < S.X ? -1 : 1;

    xD = B.Y == S.Y && B.X < S.X ? xD *= -1 : xD;
    yD = B.X == S.X && B.Y < S.Y ? yD *= -1 : yD;

    var x = B.X;
    var y = B.Y;
    var tempPoints = new HashSet<(int X, int Y)>();
    while (beaconFound) {
        if (x == S.X)
            yD *= -1;

        if (y == S.Y)
            xD *= -1;

        x += xD;
        y += yD;
        if (B.X == x && B.Y == y)
            beaconFound = false;

        //Part 1
        if(y == line)
         tempPoints.Add((x, y));

        //Part 2
        if((x + xD) >= 0 && (x + xD) <= line * 2 && y >= 0 && y <= line * 2 && Sensors.All(s => s.R < Math.Abs(s.X - (x + xD)) + Math.Abs(s.Y - y)))
            point =(x + xD, y);
    }

    var range = tempPoints.Where(p => p.Y == line).Select(x => x.X);
    if (range.Any())
    {
        for (int i = range.Min(); i <= range.Max(); i++)
        {
            if(!Points.Contains((i, line, "B")) && !Points.Contains((i, line, "S")))
                Points.Add((i, line, "#"));
        }
    }

}

//Part 1 response
var diff = Points.Where(p => p.Y == line && p.Value == "#").Count();
Console.WriteLine(diff);

//Part 2 response
Console.WriteLine((point.X * 4000000L) + point.Y);