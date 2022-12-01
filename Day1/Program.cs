using System.Data;

Console.WriteLine("Advent Of Code 2022 Day1");

var dataset = File.ReadAllLines("C:\\Dev\\Aoc-2022\\Day1\\data\\prod.txt");

List<int> counts = new List<int>();
int tempcount = 0;

var last = dataset.Last();
foreach (var line in dataset)
{
    if (line != "")
    {
        tempcount = tempcount + int.Parse(line);
        if (line.Equals(last))
        {
            counts.Add(tempcount);
        }
    }
    else
    {
        counts.Add(tempcount);
        tempcount = 0;
    }
}

counts.Sort((a, b) => b.CompareTo(a));

Console.WriteLine($"The highest number of calories is {counts[0]}");
Console.WriteLine($"The sum of the highest 3 is {counts[0] + counts[1] + counts[2]}");