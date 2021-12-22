using System.Text.RegularExpressions;

namespace AdventOfCode2021;

public class Day17
{
    public static void Part1(string input)
    {
        Console.WriteLine();
        Console.WriteLine("Day17 Part1");

        var targetMinX = int.Parse(Regex.Match(input, @"(?<=x=)-?[0-9]*").Value);
        var targetMaxX = int.Parse(Regex.Match(input, @"(?<=x=[0-9]*\.\.)[0-9]*").Value);
        var targetMinY = int.Parse(Regex.Match(input, @"(?<=y=)-?[0-9]*").Value);
        var targetMaxY = int.Parse(Regex.Match(input, @"(?<=y=-?[0-9]*\.\.)-?[0-9]*").Value);

        for (long intVelY = 0; intVelY < 1000; intVelY++)
        {
            long maxHeight = 0;
            long height = 0;
            long velocity = intVelY;
            while (height > targetMinY)
            {
                height += velocity;
                velocity -= 1;
                if (height > maxHeight)
                    maxHeight = height;

                if (targetMinY <= height && height <= targetMaxY)
                {
                    Console.WriteLine(intVelY + " : " + maxHeight);
                    break;
                }
            }
        }
    }

    public static void Part2(string input)
    {
        Console.WriteLine();
        Console.WriteLine("Day17 Part2");
        
        var targetMinX = int.Parse(Regex.Match(input, @"(?<=x=)-?[0-9]*").Value);
        var targetMaxX = int.Parse(Regex.Match(input, @"(?<=x=[0-9]*\.\.)[0-9]*").Value);
        var targetMinY = int.Parse(Regex.Match(input, @"(?<=y=)-?[0-9]*").Value);
        var targetMaxY = int.Parse(Regex.Match(input, @"(?<=y=-?[0-9]*\.\.)-?[0-9]*").Value);

        var count = 0;
        for (long intVelY = -1000; intVelY < 1000; intVelY++)
        {
            for (long intVelX = 0; intVelX < 1000; intVelX++)
            {
                long posX = 0;
                long posY = 0;
                long velocityY = intVelY;
                long velocityX = intVelX;
                while (posY >= targetMinY && posX <= targetMaxX)
                {
                    posX += velocityX;
                    posY += velocityY;
                    velocityX = Math.Max(velocityX - 1, 0);
                    velocityY -= 1;

                    if (targetMinX <= posX && posX <= targetMaxX && targetMinY <= posY && posY <= targetMaxY)
                    {
                        count++;
                        Console.WriteLine(intVelX + ", " + intVelY);
                        break;
                    }
                }
            }
        }

        Console.WriteLine("Count: " + count);
    }

    public static string Input = @"target area: x=235..259, y=-118..-62";
}