using System.Runtime.CompilerServices;

Console.WriteLine("Advent Of Code 2022 Day5");

var dataset = File.ReadAllLines("C:\\Dev\\Aoc-2022\\Day5\\data\\test.txt");

Dictionary <int, Queue<char>> startpiles = new Dictionary<int, Queue<char>>();


bool firstline = true;
int amountofstacks = 0;

foreach (var line in dataset)
{
    if (firstline)
    {
        amountofstacks = (line.Length +1 ) / 4 ;
        for (int i = 1; i <=amountofstacks; i++)
        {
            startpiles[i] = new Queue<char>();
        }
        firstline = false;
    }

    // Separator
    if (line == "")
    {

    }
    // Stack definition
    else if ((char.IsWhiteSpace(line[0]) && !char.IsNumber(line[1])) || line.StartsWith('['))
    {
        int j = 0;
        for (int i = 1; i <=amountofstacks; i++)
        {
            char value = line.Substring(j + 1, 1).ToCharArray().First();
            if (!char.IsWhiteSpace(value)) startpiles[i].Enqueue(value);
            j += 4;
        }
    }

    // Command
    else if (line.StartsWith("move"))
    {
        //var commandargs = line.Split(' ');
        //int movecount = int.Parse(commandargs[1]);
        //int origin = int.Parse(commandargs[3]);
        //int destination = int.Parse(commandargs[5]);
        //for (int i = 0 ; i < movecount; i++)
        //{
        //    startpiles[destination].    piles[origin].Dequeue();
        //}
        //var zz = "aa";
    }
    // Command

    //var x = "blah";


}
