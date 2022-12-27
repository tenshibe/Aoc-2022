using Day5;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

Console.WriteLine("Advent Of Code 2022 Day5");

var dataset = File.ReadAllLines("C:\\Dev\\Aoc-2022\\Day5\\data\\prod.txt");

Dictionary<int, List<char>> problem1piles = new Dictionary<int, List<char>>();
Dictionary<int, List<char>> problem2piles = new Dictionary<int, List<char>>();
List<MoveCommand> commands = new List<MoveCommand>();

bool firstline = true;
int amountofstacks = 0;

foreach (var line in dataset)
{
    if (firstline)
    {
        amountofstacks = (line.Length + 1) / 4;
        for (int i = 1; i <= amountofstacks; i++)
        {
            problem1piles[i] = new List<char>();
            problem2piles[i] = new List<char>();
        }
        firstline = false;
    }
    // Separator
    if (line == "")
    {

    }
    // Stacks
    else if ((char.IsWhiteSpace(line[0]) && !char.IsNumber(line[1])) || line.StartsWith('['))
    {
        int j = 0;
        for (int i = 1; i <= amountofstacks; i++)
        {
            char value = line.Substring(j + 1, 1).ToCharArray().First();
            if (!char.IsWhiteSpace(value)) problem1piles[i].Insert(0, value);
            if (!char.IsWhiteSpace(value)) problem2piles[i].Insert(0, value);
            j += 4;
        }
    }
    // Commands
    else if (line.StartsWith("move"))
    {
        var commandargs = line.Split(' ');
        int movecount = int.Parse(commandargs[1]);
        int origin = int.Parse(commandargs[3]);
        int destination = int.Parse(commandargs[5]);
        commands.Add(new MoveCommand() { destination = destination, movecount = movecount, origin = origin });
    }
}


foreach (MoveCommand command in commands)
{
    for (int i = 0; i < command.movecount; i++)
    {
        problem1piles[command.destination].Add(problem1piles[command.origin].Last());
        problem1piles[command.origin].RemoveAt(problem1piles[command.origin].Count - 1);


    }

    problem2piles[command.destination].AddRange(problem2piles[command.origin].TakeLast(command.movecount));
    problem2piles[command.origin].RemoveRange(problem2piles[command.origin].Count - command.movecount, command.movecount );

}


string problem1result = string.Empty;
string problem2result = string.Empty;

for (int i = 1; i <= amountofstacks; i++)
{
    problem1result = problem1result + problem1piles[i].Last();
    problem2result = problem2result + problem2piles[i].Last();
}

Console.WriteLine($"The final top crate configuration for problem 1 is {problem1result}");
Console.WriteLine($"The final top crate configuration for problem 2 is {problem2result}");
