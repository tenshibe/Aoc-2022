Console.WriteLine("Advent Of Code 2022 Day3");

var dataset = File.ReadAllLines("C:\\Dev\\Aoc-2022\\Day3\\data\\prod.txt");

Func<char,int> getScore = x => (x < 91 ? x - 38 : x - 96 );

int totalseverity = 0;

foreach (var line in dataset)
{
    List<char> firsthalf = line.Substring(0,line.Length / 2).ToList<char>();
    List<char> secondhalf = line.Substring(line.Length / 2, line.Length / 2).ToList<char>();
    var commonitems = firsthalf.Intersect(secondhalf);

    foreach (var item in commonitems)
    {
        totalseverity += getScore(item); ;
    }
}

Console.WriteLine($"Total severity is {totalseverity}");
