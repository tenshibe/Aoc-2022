Console.WriteLine("Advent Of Code 2022 Day2");

var dataset = File.ReadAllLines("C:\\Dev\\Aoc-2022\\Day2\\data\\prod.txt");

List<string> winners = new List<string>() { "C X", "B Z", "A Y" };
List<string> equalizers = new List<string>() { "C Z", "B Y", "A X" };
Dictionary<char, int> scores = new Dictionary<char, int>() { { 'X', 1 }, { 'Y', 2 }, { 'Z', 3 } };

Dictionary<char, Dictionary<char, char>> draws = new Dictionary<char, Dictionary<char, char>>() {
                       { 'X', new Dictionary<char, char>() { {'A', 'Z' }, { 'B', 'X' }, { 'C', 'Y' } } },
                       { 'Y', new Dictionary<char, char>() { {'A', 'X' }, { 'B', 'Y' }, { 'C', 'Z' } } },
                       { 'Z', new Dictionary<char, char>() { {'A', 'Y' }, { 'B', 'Z' }, { 'C', 'X' } } },
                   };
Dictionary<char, int> resultscores = new Dictionary<char, int>() { { 'X', 0 }, { 'Y', 3 }, { 'Z', 6 } };

int totalscore_part1 = 0;
int totalscore_part2 = 0;

foreach (var line in dataset)
{
    if (winners.Contains(line))
    {
        totalscore_part1 += 6;
    }
    else if (equalizers.Contains(line))
    {
        totalscore_part1 += 3;
    }
    totalscore_part1 += scores[line[2]];

    totalscore_part2 += (resultscores[line[2]] + scores[draws[line[2]][line[0]]]);
}

Console.WriteLine($"The total score for problem 1 is {totalscore_part1}");
Console.WriteLine($"The total score for problem 2 is {totalscore_part2}");
