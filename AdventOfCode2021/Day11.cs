namespace AdventOfCode2021;

public class Day11
{
    public static void Part1(string input)
    {
        Console.WriteLine();
        Console.WriteLine("Day11 Part1");

        var octopuses = input.Split(Environment.NewLine).Select(l => l.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray())
            .ToArray();
        

        var flashes = 0;
        for (var i = 0; i < 10000; i++)
        {
            // gain energy
            for (var x = 0; x < octopuses.Length; x++)
            {
                for (var y = 0; y < octopuses[x].Length; y++)
                {
                    octopuses[x][y]++;
                }
            }
            while(octopuses.Any(l => l.Any(e => e > 9)))
                for (var x = 0; x < octopuses.Length; x++)
                {
                    for (var y = 0; y < octopuses[x].Length; y++)
                    {
                        if (octopuses[x][y] > 9)
                        {
                            flashes++;
                            octopuses[x][y] = 0;
                            if (x > 0 && y > 0 && octopuses[x - 1][y - 1] != 0)
                                octopuses[x - 1][y - 1]++;
                            if (x > 0 && octopuses[x - 1][y] != 0)
                                octopuses[x - 1][y]++;
                            if (y > 0 && octopuses[x][y - 1] != 0)
                                octopuses[x][y - 1]++;
                            if (x > 0 && y < octopuses[x].Length - 1 && octopuses[x - 1][y + 1] != 0)
                                octopuses[x - 1][y + 1]++; 
                            if (y > 0 && x < octopuses.Length - 1 && octopuses[x + 1][y - 1] != 0)
                                octopuses[x + 1][y - 1]++;
                            if (y < octopuses[x].Length - 1 && x < octopuses.Length - 1 && octopuses[x + 1][y + 1] != 0)
                                octopuses[x + 1][y + 1]++;
                            if (x < octopuses.Length - 1 && octopuses[x + 1][y] != 0)
                                octopuses[x + 1][y]++;
                            if (y < octopuses[x].Length - 1 && octopuses[x][y + 1] != 0)
                                octopuses[x][y + 1]++;
                        }
                    }
                }
            Console.WriteLine(flashes);

            if (octopuses.All(l => l.All(e => e == 0)))
            {
                Console.WriteLine("Boom at :" + i);
                break;
            }
        }
    }

    public static void Part2(string input)
    {
        Console.WriteLine();
        Console.WriteLine("Day11 Part2");
    }

    public static string TestInput = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";

    public static string Input = @"7777838353
2217272478
3355318645
2242618113
7182468666
5441641111
4773862364
5717125521
7542127721
4576678341";
}