using System.Numerics;

Console.WriteLine("Advent Of Code 2022 Day7");

var dataset = File.ReadAllLines("C:\\Dev\\Aoc-2022\\Day7\\data\\prod.txt");

string currentdir = "/";
bool duplicate = false;
Dictionary<string, int> dirsizes = new Dictionary<string, int>();

foreach (var line in dataset)
{
    if (line.StartsWith("$ cd"))
    {
        duplicate = false;
        var tokens = line.Split(' ', 3);
        if (tokens[2] == "/")
        {
            currentdir = "/";
        }
        else if (tokens[2] == "..")
        {
            var index = currentdir.LastIndexOf('/');
            if (index != -1)
            {
                currentdir = currentdir[..index];
            }
            else
            {
                currentdir = "/";
            }
        }
        else
        {
            currentdir = (currentdir == "/") ? String.Concat(currentdir, tokens[2]) : String.Concat(currentdir, "/", tokens[2]);
        }
    }
    else if (line.StartsWith("$ ls"))
    {
        duplicate = dirsizes.ContainsKey(currentdir);
        if (!duplicate)
        {
            dirsizes.Add(currentdir, 0);
        }
    }
    else if (char.IsDigit(line[0]) && duplicate is false)
    {
        var tokens = line.Split(' ', 2);
        addCount(currentdir, int.Parse(tokens[0]));
    }
}

int totalsize = 0;
foreach (var size in dirsizes.Values)
{
    if (size <= 100000)
    {
        totalsize += size;
    }
}

//int unused = 70000000 - dirsizes["/"];
int neededspace = (30000000 - (70000000 - dirsizes["/"]));

var dirvalues = new List<int>(dirsizes.Values);
dirvalues.Sort();
int removeDir = 0;
foreach(var dir in dirvalues)
{
    if (dir > neededspace)
    {
        removeDir = dir;
        break;
    }

}

Console.WriteLine($"The total size of small directories is {totalsize}");
Console.WriteLine($"The amount of missing space is {neededspace}");
Console.WriteLine($"The directory to remove has size {removeDir}");


void addCount(string dirkey, int size)
{
    //if (dirkey == string.Empty) dirkey = "/";
    dirsizes[dirkey] += size;
    var index = dirkey.LastIndexOf('/');
    if (index != -1)
    {
        var parentdir = dirkey[..(index)];
        if (parentdir != "")
        {
            addCount(parentdir, size);
        }
        else if (currentdir != "/")
        {
            dirsizes["/"] += size;
        }
    }
}