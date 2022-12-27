//use hashset for part1

Console.WriteLine("Advent Of Code 2022 Day6");

var dataset = File.ReadAllText("C:\\Dev\\Aoc-2022\\Day6\\data\\prod.txt");

List<char> buffer = new List<char>();
List<char> buffer2 = new List<char>();
int counter = 0;
int counter2 = 0;

foreach (var currentchar in dataset)
{
    
    if (buffer.Count() == 4)
    {
        if (buffer.Distinct().Count() == 4)
        {
            break;
        }
        else
        {
            buffer.RemoveAt(0);
        }
        //break;
    }
    buffer.Add(currentchar);
    counter++;
}

foreach (var currentchar in dataset)
{

    if (buffer2.Count() == 14)
    {
        if (buffer2.Distinct().Count() == 14)
        {
            break;
        }
        else
        {
            buffer2.RemoveAt(0);
        }
        //break;
    }
    buffer2.Add(currentchar);
    counter2++;
}

Console.WriteLine($"We start a message at position {counter}");
Console.WriteLine($"We start a message at position {counter2}");
