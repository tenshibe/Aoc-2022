Console.WriteLine("Advent Of Code 2022 Day4");

var dataset = File.ReadAllLines("C:\\Dev\\Aoc-2022\\Day4\\data\\prod.txt");

var overlaps = 0;
var pairoverlaps = 0;

foreach (var line in dataset)
{
    var elfs = line.Split(',');
    var elf1bounds = elfs[0].Split("-");
    var elf2bounds = elfs[1].Split("-");
    if ( ((int.Parse(elf1bounds[0]) <= int.Parse(elf2bounds[0])) && (int.Parse(elf1bounds[1]) >= int.Parse(elf2bounds[1]))) 
         || ((int.Parse(elf2bounds[0]) <= int.Parse(elf1bounds[0])) && (int.Parse(elf2bounds[1]) >= int.Parse(elf1bounds[1])))
        )
    {
        overlaps++;
    }
    if ( int.Parse(elf1bounds[1]) >= int.Parse(elf2bounds[0]) &&  int.Parse(elf1bounds[0]) <= int.Parse(elf2bounds[1]) )
        
    {
        pairoverlaps++;
    }

}

Console.WriteLine($"We have {overlaps} overlaps");
Console.WriteLine($"We have {pairoverlaps} pair overlaps");
