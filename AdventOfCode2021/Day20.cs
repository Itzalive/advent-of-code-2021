﻿using System.Text;

namespace AdventOfCode2021;

public class Day20
{
    public static void Part1(string input)
    {
        Console.WriteLine();
        Console.WriteLine("Day20 Part1");

        var puzzle = input.Split(Environment.NewLine + Environment.NewLine);
        var enhancement = puzzle[0];
        var image = puzzle[1].Split(Environment.NewLine);
        image = Pad(Pad(Pad(Pad(image))));
        Draw(image);
        image = Enhance(image, enhancement);
        Draw(image);
        image = Enhance(image, enhancement);
        Draw(image);

        Console.WriteLine(image.Sum(r => r.ToCharArray().Count(c => c == '#')));
    }

    private static void Draw(string[] image)
    {
        Console.WriteLine();
        foreach (var line in image)
        {
            Console.WriteLine(line);
        }
        Console.WriteLine();
    }
    
    private static string[] Pad(string[] image)
    {
        var newImage = image.Select(r => '.' + r + '.').ToList();
        var blankLine = '.' + image[0].Replace('#', '.') + '.';
        newImage.Insert(0, blankLine);
        newImage.Add(blankLine);
        return newImage.ToArray();
    }

    private static string[] Expand(string[] image)
    {
        var newImage = image.Select(r => r[0] + r + r[^1]).ToList();
        var blankLine = image[0];
        newImage.Insert(0, blankLine[0] + blankLine + blankLine[^1]);
        newImage.Add(blankLine[0] + blankLine + blankLine[^1]);
        return newImage.ToArray();
    }

    private static string[] Enhance(string[] image, string enhancement)
    {
        var expandedImage = Expand(image);
        var newImage = new List<string>();
        for (var y = 1; y < expandedImage.Length - 1; y++)
        {
            var newRow = new StringBuilder();
            for (var x = 1; x < expandedImage[y].Length - 1; x++)
            {
                var key = string.Join("",
                    new[]
                    {
                        expandedImage[y - 1][x - 1], expandedImage[y - 1][x], expandedImage[y - 1][x + 1],
                        expandedImage[y][x - 1], expandedImage[y][x], expandedImage[y][x + 1],
                        expandedImage[y + 1][x - 1], expandedImage[y + 1][x], expandedImage[y + 1][x + 1]
                    });
                var binaryKey = key.Replace('#', '1').Replace('.','0');
                var decimalKey = Convert.ToInt32(binaryKey, 2);
                newRow.Append(enhancement[decimalKey]);
            }

            newImage.Add(newRow.ToString());
        }
        
        return Expand(newImage.ToArray());
    }

    public static void Part2(string input)
    {
        Console.WriteLine();
        Console.WriteLine("Day20 Part2");

        var puzzle = input.Split(Environment.NewLine + Environment.NewLine);
        var enhancement = puzzle[0];
        var image = puzzle[1].Split(Environment.NewLine);
        image = Pad(Pad(Pad(Pad(image))));

        Draw(image);
        for (var i = 0; i < 50; i++)
        {
            image = Enhance(image, enhancement);
            Draw(image);
        }

        Console.WriteLine(image.Sum(r => r.ToCharArray().Count(c => c == '#')));
    }

    public static string TestInput = @"..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..###..######.###...####..#..#####..##..#.#####...##.#.#..#.##..#.#......#.###.######.###.####...#.##.##..#..#..#####.....#.#....###..#.##......#.....#..#..#..##..#...##.######.####.####.#.#...#.......#..#.#.#...####.##.#......#..#...##.#.##..#...##.#.##..###.#......#.#.......#.#.#.####.###.##...#.....####.#..#..#.##.#....##..#.####....##...##..#...#......#.#.......#.......##..####..#...#.#.#...##..#.#..###..#####........#..####......#..#

#..#.
#....
##..#
..#..
..###";

    public static string Input = @"###.#.##.##....##...##.#..##...#..##.#.#.#.##.##...#.##.#...#.#.#.#.#...##.#...#####..#...#.#.#...##.#.####.##.##.###......###.#.###...#..##.#..#..##.##.#..###.###.#.#...#.##.######..####..##..#.#.#####.##.###..###.#.#.#....##.#.####.....#..#..#.##.#.##...##.#...###......###.#....#..#......#.##.#..##.#.###.###.####.##..###.#...#.##.####.#.##..#.#..#.#.......#.####..#..##..###.####..##.#.##.###....#.###..####..##......###.##.#.#...#..####.##.#...#..###..##..####.###...#.#..##.#.###.#.....##..#...###..####...

##..###.#.###..##.##..####.#..#.#.###..#.#.#....#.#.###...#.....#.##.##..#.####.##.#.####.#.#.....##
...#.#.###...###..##...#####..##..#..#.#..#.#...#.#..###...#..##.##....#.....#...########.######.##.
#...#.#.####....#....###..#.#.###.#.....####....###.#.###.#..###.###....##.##..#.##...##....##.##...
###..###.#..#######.....#..##.###..#####...##.###..#....##.##....####...#..###..###.#...##...###.###
#######.#........#####.##..##..#...#######..#.##...#.###...###...######...#####..#.#.#..#..#.#.#.#..
..##.#.##.##.#...#.#.#........##.##.###..###.##.#.#.#.#..##.#.###..######..#.....#..#.###..#....#.#.
.#.....##.#...#.###...#.##..#.##.##.#.#.#####...###.#.##.###..#.#.#..#..##########.#.#####.##.#..##.
.#.#.##..#.#.####..#...#.#..##.########.#.###.#.#......##..########.####.##...###....###......#.#.##
##.#.#.#######..#....###...##.#.#.#..#.#.###.###..#....#..###....#.....##.####.##..##..##..#.###....
.##..#######.######....#.#..#.......#.#.####.#.####.....#.####..##.#..##..##..#......#...###...#..#.
###.#..###..##..#.##...###.####...##........#..##.#.#.#.##...####...##..#..#.####......##..#..##.##.
#.#.##...#.##......#.......###.......##...#...#####.#.#..##..#..#####.###.######..###.###......##.##
#.#####.#.#..#...#.#..###.###.....###.##...#.##.##.###..#...##..##...#####...#.....##.#..####.#.###.
..######..###.#.#...#.#.##......###......#.#######..#.#....#.##....#..#.#.##....###.##.#.#...#...##.
##.##..#.##.##.#.#####.#####.##.#.##.#...##..##....##....###....##.###..##.###.#.#...##....##.#.##.#
.#.##.#.#.#.##...#.#.###.#...#.#....####.##.#..#####.#.#..######.##..#.#.#####....###..##..#.#......
..###.....#.###.......#...#...##.#...##.##..##.##..##...###.#..#...##..#.#.#.##...#.#..#####.##..#.#
.##..#...#.##.##.#.###....##...#..####...##......###..##...#####.##..#..#.#..#####......#....#.##..#
.#.#.###.#...#.##.##.####...###.#.#..#...###.....##..#.#..###.##.#.#...#.##...###....##.#.##..#..###
.#..###.##.####.##..#..#.#.######..#.#..#...#####...##..#..##.#.#.##.##.#...###..##..##...#.##..#...
###.####...###.....#.#####.....#...###.##..#....#.####......#.#..##.#.#.####..#..#...#.#####.#.###.#
#....####...#..#..###...##...##.##....#.#.#....####.#..#.##.#.##.###.#..###.##..###..#.....####....#
.##..#....#..#..#....#...#...##.##..#..###.###...#######.##.##..##.#..#.#..#.#.#.#..####..#####...#.
#.###......#####.###..##.##.#...##.#.###..##..##.....#...########.#..#####......#..###..#.##...#....
#....##...#.###..##...#..###.####..#.###...##.#.##..####..##.#.#####..#...######....#.##.#..#.....##
.##.#.#.###.#####...#....#......####.##..####..#.#.#.#.#..#.......###.#.....##..##...##..##...###.#.
.#...#.##..#.####.###.###....####..#.##.#....####..#..#...#.####.##.####.#.##.#.####..###......####.
..#.#...#.#.###.##...#...#.......#....#....###.#.......#.#..####.#.###.#.#....#.#.#..#.#..#...#..###
#...###.###.#...#........###...#.##..###.##.#.##..##.....##.#.##...####..#..#.#.##.####.....#.######
.#.##..#.#.###.#.#.......##.#.##########.#.#.....#..#####.#.....#.#####..###.##......#.#.....####...
.#.#########....###..#.#######.#.....#.#..##...##...#.#####.##....#.#.#..##.....#.#.#.##.#.#..##..##
###.##.#.####.#...###.#.##..####.###...#######..###.#...#.#...##.####..#....####.####..####.#.###...
..##..#...#.#.##...#.###.#########.#..####..###.##..##.##..##...###.#..###...#..#.#..#.#####.###..##
.#.##...#..##.###.....####.#.....#.#.####.#....##..#....##.##.##..#.###.###.####..##..##..##...#####
.##.#.#..####.#.#...#..###.#.##..#.#.###.#..#...###.....#....###..#.#.#.##.###.###..##.#.#.###.##.#.
#..#####.####.....#.#.#...##.#..#.#....#.#####.#.#####...#.#.#.####..#.#####..##.#..#.###..####.####
#.###...#...#####.###.#.##..##.#.#..##..#..#.##.##.#.....##....#####..##.#.##..#.#......#####.#..#.#
###......#........####.#####..###....#.#.##..#.#.##.##.##.###......###.####...##...##.##.##.#.#.####
##.#.#.......###..#.##.##....#.####...#..#....#...#.#..#..#..###..#.####.###.##.#..#######..#.#...##
..#....##...#..#...#..#.##.##.###.#.##.####....#..#.#.#.#####.#..#.#.....###.#...###.##.#...#..#.###
#..#..#.....#..###..##.#.##..##.#.#.###.##..##..#######.#..#.#..#.#..##.#...#.#.#.###.##..#.#..####.
..#...##..#.#.##..#.#..#..##..#.###..#########....##...#####.###..#...#.#..##.##......#.##.#..#.....
..##.##....#..#.#..#..####..####..#...##...#..##.##..##..##.#.##.###.............###...###..#####.##
...#####...#..#.#.#..#.##...####.####..###.######..#..###..#...##.###...##.##.#.#######.....#..###.#
####......#.#.#...#####.#.##.#...##.....##..#..#......##.###.###..###.####.##.##..#...###.####..###.
#####....##..##.......#..#...###....#..##.#..#.#.#...#..#..#.#.##.#####...###.....###..#..##....##.#
#.####.##...#.###.#.#.#..###.#..#..###..#.##...#...##..##.#....###......#...#..######.#.#....#..###.
####....##...#.#..###.##.#.....#..#...####.....#...##....####..##.##..#####..##.#.#....###....#.#..#
##..##.##....#####....#..#..####.#####.#.##.###.#...###..#....#..##.#.....#.#..#.###..##.#.#..##.#..
.##...#.##..#.#.####.##...#...##.#.######..#####.#...#..##.....####...#..########..#.##.....#.#....#
#.#..##..#.#...#...#.#.##..#.#.#.#..#.###..##.#..#.###.....#####.##.#######.###..#..##..#...#.####.#
.#..####.###....##.#..#.#.#.###.##..###..#....##.##.#.######.##...#...#.#.###..#######.###.###.#..#.
.#....##.##..##.#......####.##...####.####.###.###.##.###....#..#.#...##.####.###.###...#..#...##.##
#.##..##.##...#.#####..###....##.####.###.#.#.###..#....##.#.#.#..#.##.###.########.##.#..##..##.##.
.#...#.##.###......#.#####...##..#.#...##.##.....#.##.##.#.#...#..###....####....##....#.#####.#..#.
###..###.####.##..##...#...#.#..###..##..#..#.#####...####..###.#..##..#.###..##....#..#..#.#.#.#...
##.#####..#..#....#.#.##.#.####...####.#..#.....#..##.####......#.#######.##..##..###..#.#.##....###
#.####..#...#..#.##..#.#.....#..#.##.#.#..#...#....##.......#.#.#.#########.######.####....#....#..#
...##...#.#.##...#..##.#.#.#.#..#.#.....#....##.##.###.####.####....#.#.###.##...#.##.....###...##.#
....#.#.#..##....##.#..#.##..#..#.#.###.#..#.#####.#.##.##.##..#..####..###.#.##..#....#.##..###.###
.##.....#.#.......#.###.####.....#.###..##..###..####.##.######........####.##.#.##...##.###..#.###.
.###..#..#.#.#.########..#..#....#.#.#.#...#..#.#...#.###..##.###.####...#....#.#.#####.#...####.###
.##......##.###.###....#.##.#####.#....##..#####.##.##.#.....###...##.....##.##.#..###.....###.#.#..
....#.##.#.....###.#..#.####...#####...######.##.##..#.#..#.#.#...#.#.##...##....####...##.#.#.#.##.
.#....##.#.#...##.#.........##..#.#......#.#..#.......###.#.###....##.#...#..#.#.#.#.###...##..#####
#..#.#.....#..###.###.#...##..##.#...####..###.#.#..###.###..#..#.#.#.########.#....#.####....####.#
.#..#####.######.#..#..#.##.######.#.###.###.###..###.....#...#.###.###....#.#.##.#..#..#.#...#.##.#
#.#..#..#.#.#.#....#......###...#..##.##...##.####.#.#....#...#.#.##....##.##..#.#.#....####..#.#.#.
..#...##.###......###.#..#.#...##.#.###.###.#.####......#..#...#..######.#.##.########..#..#.#......
....##.#.##.##..#..###.....###...#.#.##...#.######....###...##.##..##..##.##....#.#.##..###...##.#.#
####.#.###.###.###.#.####..#.......######..##....####.#.####......#...#.#####..#.###..######.#.#.#.#
#.........##...#.#.#####...#.##..#.#..#.##.##..#.###..##.#..###.##..###.#..######..#.####...#.####.#
..#.#.####....#.#####.###....###..#...#...#.#..###.##.##..#.....##......##.#...#.###...##.#########.
##..####.....##.#......#..#....##.##.#..##.#..##.##...#.#...#.#..##.....######.#.##..#...#....##.#.#
.#.##..#.##.#...##...##..##.#.#..####......#...######.###.###.##..#.#.........###..#.#.#......#....#
##.###.###..#....#....#...#.##.#.####..#...#.#.##.#.##.#.#...#.#.#...##..#....######....####...#.#.#
.####.#.....#####..#....#.#.##..##..#...#.####.##.#..###..###.#...###.####...##.##..#....#.#.#..##..
####.#....##..####...#.#.#..###..#####.#.#.#..##.####.##.#......###.#...#.##.#......#..##.#...#.##.#
#....##.....#.##.#####..#.#.###....#.#...#.####.#.#...###..##...#.###.###......#.#...#..##..##.#####
##.#..#.##..###.#.######...#.#.#...#......###......#..#..##....###.####..##.###...##.#...#..#.##....
.##...#.#.####.#.##..#.#.....##....#.##.###.#.#...##.####...#.#..#.###...##.######.##.###.....#...#.
##...##.#...#.#......##.#..#...##.######.####.#.##.##.###.##..#........##.#.#...#.#.##.#..##.#.#.#.#
#..##.#..##.#.##..##.#...###...#####.##...######...#.##.##..#.##.#.#..#########.#......###.#.##...##
..#.#.#..###......##.##.###.##.##.##.##.......##....#####..####.##..##.##..#....##....#......#..#..#
...###..##....##..#.#######..######..#............#.....#..#.#.#....####.#.##.#.#.....###...#.#...#.
###.#....#...##....#.#..##....###..##..###..#.#..##.##......#....#...#...####.....#..##....##..#..##
#.##.#...###.##..#..#.######....###.#...#....#.###......#.###.#...#.#..##..##..#....#.....#...##.###
...##...##....##.....#....#.#####.##..##.###.###.#.....#..#...#.####.#.#..#..#.###.##....##..#..#..#
##.##.###..#.#.....#.....##...#....#..#........#..#.##.###..#.........#...#.##.##.###..#...#####..##
..###.#.#.####.....####...#.#..#....##.###..###.##...#.#...#.####..####.#.#..#.#####.#......#.###...
.####....###.#...###...#.##.####.....#.#....#..#.##..#.#.#....##.#..#.###..##..#..#.#.####.#....####
###.#....#..##..##.####.##.#.#....##.......#..#......##..#.##.#####..###..#....###.#.........#..#.#.
..#....##...#...###.##.#..#..#....##.#####..##..#.####...#.#..##..##....##...##..###.#.###.##.#..###
......##.#######...#...#..##...##.#..#.......#..##...#.#.###.###..##.#...###..##.##.#.##.#..######..
##..#...#.###..####.####..###.#.##..#.#.##.#..#.##.....##..###...#.##..#....###..##...###.....#.#...
.##.#.#...#.#..#.#######.##.#.#..#..###..#.##.#..#####.#.###.###..####....#.####.....###...###..##.#
#...#...##.###.#..##..#..##...#.###.....#..####..#..#.#.#.##.#.#.##..#.##.#...##..###.#..#.#..#.#...
#.#..##....#.#.##.##..##..#.##.#####.##..####.#.#.#......#.######.......##...#...#.##.#..####..#.###
...#..#.....##.#.#.###.....######..#.##.....##....##..###.####..##.##.###.#.....###.###.#.#..##..#..
##.#...##.#..###.#.#.##..#...###..##.###.###...#...#.#.##.#.##.#...####.####..###..#.##.#.##..##.##.";
}