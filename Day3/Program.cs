Console.WriteLine("Advent Of Code 2022 Day3");

var dataset = File.ReadAllLines("C:\\Dev\\Aoc-2022\\Day3\\data\\prod.txt");

Func<char,int> getPriority = x => (x < 91 ? x - 38 : x - 96 );

int totalseverity = 0;
int elfpackseverity = 0;
int i = 0;
List<List<char>> elfpack = new List<List<char>>();


foreach (var line in dataset)
{
    i++;
    elfpack.Add(line.ToList<char>());
    totalseverity += getPriority(line.Substring(0, line.Length / 2).ToList<char>().Intersect(line.Substring(line.Length / 2, line.Length / 2).ToList<char>()).FirstOrDefault());

    if (i % 3 == 0)
    {
        elfpackseverity += getPriority(elfpack[0].Intersect(elfpack[1]).Intersect(elfpack[2]).FirstOrDefault());
        elfpack.Clear();
    }
}

Console.WriteLine($"Total severity is {totalseverity}");
Console.WriteLine($"Total elf priority sum is {elfpackseverity}");
