using System.Text.RegularExpressions;
using System.Xml.XPath;

namespace AdventOfCode2021;

public class Day18
{
    public static void Part1(string input)
    {
        Console.WriteLine();
        Console.WriteLine("Day18 Part1");

        var numbers = input.Split(Environment.NewLine);
        var output = numbers.Aggregate(Add);
        Console.WriteLine(output);
        Console.WriteLine(Pair.FromString(output).Magnitude());
    }

    public static void Part2(string input)
    {
        Console.WriteLine();
        Console.WriteLine("Day18 Part2");
        var numbers = input.Split(Environment.NewLine);

        var largestMagnitude = 0;
        for (var i = 0; i < numbers.Length; i++)
        {
            for (var j = 0; j < numbers[i].Length; j++)
            {
                if(i == j) continue;
                var magnitude = Pair.FromString(Add(numbers[i], numbers[j])).Magnitude();
                if (magnitude > largestMagnitude) largestMagnitude = magnitude;
            }
        }

        Console.WriteLine(largestMagnitude);
    }

    public static string Input = @"[[[[2,2],7],[[9,2],[5,2]]],[4,[[8,9],9]]]
[[8,8],[5,[[2,9],1]]]
[0,[3,[[9,2],[3,1]]]]
[9,[[4,5],[5,[3,2]]]]
[[0,[4,3]],[2,[[1,4],[3,0]]]]
[[[9,[0,2]],[[2,6],9]],2]
[1,[[[6,0],[2,6]],[[7,5],[5,6]]]]
[[[1,[6,6]],[6,[5,2]]],[[[5,6],4],9]]
[6,[[7,[1,4]],4]]
[[[[7,6],[0,5]],[[5,4],0]],[[3,[2,3]],[[0,2],[6,4]]]]
[[[3,4],7],[[[8,1],7],[3,[1,8]]]]
[[[[6,5],0],[[5,2],6]],[[1,3],[0,[5,2]]]]
[[[1,2],3],[[0,[3,7]],[4,[5,2]]]]
[[[[4,4],3],2],[2,[6,3]]]
[[[4,5],[[6,4],[8,5]]],[[[5,1],3],[8,3]]]
[[6,[[9,0],6]],[3,[[3,3],3]]]
[[8,[5,[1,7]]],[[4,5],[1,2]]]
[[[[9,1],0],[[1,6],9]],[[8,[7,4]],9]]
[[[3,1],[3,[5,5]]],[[[8,4],[2,9]],[6,[0,1]]]]
[[7,4],[[6,3],[[8,3],[2,3]]]]
[[[2,[5,6]],[[7,9],[8,7]]],[[3,5],[[1,7],[9,8]]]]
[[[[2,8],1],[[1,9],[7,6]]],6]
[[[[1,9],[5,5]],[7,8]],[[3,9],[2,[5,1]]]]
[[4,[[6,7],6]],[1,[6,[6,5]]]]
[[[[0,3],[2,7]],[7,1]],[[4,3],[[1,0],6]]]
[[[[0,8],7],[[5,4],[8,6]]],[[1,[6,5]],5]]
[[6,[[0,3],5]],[[9,[9,8]],0]]
[[0,1],9]
[[[[3,0],4],4],4]
[[[0,8],[[1,7],1]],[[9,1],[4,[2,4]]]]
[[5,[[6,1],2]],[[4,[5,9]],[[8,6],6]]]
[[4,9],[[5,0],[[4,4],3]]]
[[[[7,7],3],[3,[0,0]]],[1,[[0,8],[9,9]]]]
[[[1,6],[9,1]],4]
[[4,4],[[[0,0],9],[[2,0],[8,7]]]]
[[7,[[6,8],9]],[[2,[7,6]],[6,[8,1]]]]
[[[[7,9],[6,9]],[7,[2,5]]],[[[4,8],[3,7]],8]]
[[[8,7],[[9,8],[3,6]]],[[[2,1],[4,7]],[[3,9],5]]]
[[0,[[9,8],[5,3]]],[[9,6],[1,6]]]
[9,[[[7,4],[9,9]],5]]
[[9,[[6,7],[2,6]]],[[[2,8],[1,9]],[[4,1],[6,2]]]]
[[1,[9,5]],[0,[[1,8],0]]]
[[3,[7,6]],[8,[[3,2],[3,0]]]]
[[4,6],[6,3]]
[[[1,5],[[7,8],[6,4]]],[[3,[5,4]],[[9,8],1]]]
[[[[8,5],5],[[7,9],8]],[[5,2],[8,6]]]
[[[[3,4],9],[2,8]],[1,[9,8]]]
[[[6,9],8],[[7,9],[6,[8,5]]]]
[[[[7,4],9],1],7]
[[[[0,5],[3,4]],[9,[9,7]]],[[1,6],5]]
[6,[[[9,9],6],[[5,6],7]]]
[[[1,4],[[4,6],[9,4]]],[[[0,3],2],[[1,9],6]]]
[[8,[1,8]],[1,[5,[2,0]]]]
[[[4,5],[[6,6],1]],[[4,0],[[9,9],[3,6]]]]
[[9,[[0,0],[5,3]]],[[5,1],7]]
[[[9,4],[[5,1],[2,7]]],[6,[6,1]]]
[[8,5],[[[0,2],[2,6]],[3,[5,0]]]]
[[[[4,8],[3,6]],[3,[3,1]]],[0,[6,3]]]
[[[5,[9,6]],[3,[1,7]]],[[1,[9,2]],[6,5]]]
[[[[5,2],[9,4]],[[6,5],7]],[[4,8],[[7,1],2]]]
[[[5,[1,5]],5],[[[5,1],[0,9]],6]]
[[4,[3,[9,9]]],[[[7,1],[6,5]],2]]
[8,[[7,6],[8,7]]]
[[[[4,2],5],[3,2]],[[2,7],[[7,2],[9,2]]]]
[[[8,1],1],[5,[[0,9],[5,9]]]]
[[[[2,2],[4,0]],2],[[9,[5,4]],[[2,9],[8,6]]]]
[[[[6,8],0],[4,[1,5]]],[6,[[8,0],[6,6]]]]
[[[3,0],2],5]
[[[2,6],[5,[9,9]]],2]
[[[[4,8],7],[0,0]],[[8,6],[[9,6],9]]]
[[[1,4],0],[[[8,8],[9,3]],5]]
[[[7,[8,8]],[[0,9],3]],7]
[[[[3,1],[9,9]],[[7,9],7]],[[6,5],[[4,7],5]]]
[[[1,3],2],[8,0]]
[[8,[[5,0],[4,4]]],2]
[[3,4],[[[4,8],4],[[3,4],8]]]
[[4,[5,1]],[[8,[8,2]],[[3,5],[6,4]]]]
[[[[7,6],5],[9,[7,3]]],[[4,[6,4]],[[6,1],9]]]
[[0,[3,1]],[[4,[5,7]],6]]
[[2,[[7,2],[4,5]]],1]
[[[0,2],[3,[2,8]]],[[0,[0,6]],[1,[7,7]]]]
[[1,[0,[7,0]]],[[[1,2],[1,9]],[4,[1,4]]]]
[[[5,[7,4]],[[5,9],[7,0]]],[[[7,9],3],[[5,5],1]]]
[[[[7,9],[3,0]],3],[8,8]]
[[[[6,7],4],[[0,3],3]],[[2,[5,3]],8]]
[[0,5],[3,[[6,6],[5,2]]]]
[9,[[2,[8,7]],[6,[2,6]]]]
[7,[[[1,9],[2,9]],[[1,0],5]]]
[[5,0],[8,[2,2]]]
[[3,[2,[8,0]]],3]
[[[0,2],[6,[4,5]]],[3,[9,[0,4]]]]
[[[6,7],7],[[8,[4,5]],[4,[1,7]]]]
[[[[2,7],[9,6]],[5,0]],3]
[[[[3,2],5],[8,3]],[[4,1],[[8,8],[6,4]]]]
[[[2,[5,3]],[1,4]],[[[3,9],9],[[7,8],[5,7]]]]
[5,[[[8,2],[0,4]],[[5,3],0]]]
[[[3,4],3],[3,[[3,8],[2,1]]]]
[5,[[[3,8],[5,2]],2]]
[[[[3,8],6],[8,9]],[[3,[7,5]],[[4,4],2]]]
[[[2,[3,9]],[[4,5],[7,9]]],5]";

    public static string Add(string a, string b)
    {
        return Reduce("[" + a + "," + b + "]");
    }

    public static string Reduce(string input)
    {
        bool actionTaken;
        do
        {
            actionTaken = false;

            // find four deep
            var depth = 0;
            for (var i = 0; i < input.Length;i++)
            {
                if (input[i] == '[') depth++;
                if (input[i] == ']') depth--;
                if (depth > 4)
                {
                    actionTaken = true;
                    var pairEndIndex = input[i..].IndexOf(']') + i + 1;
                    var nestedPair = input[i..pairEndIndex].Trim('[', ']').Split(',').Select(int.Parse).ToArray();
                    var left = input[0..i];
                    var right = input[pairEndIndex..];
                    var leftNumbers = Regex.Matches(left, @"[0-9]+");
                    if (leftNumbers.Any())
                    {
                        var match = leftNumbers.Last();
                        left = left[..match.Index] + (int.Parse(match.Value) + nestedPair[0]) +
                                left[(match.Index + match.Length)..];
                    }
                    var rightNumbers = Regex.Matches(right, @"[0-9]+");
                    if (rightNumbers.Any())
                    {
                        var match = rightNumbers.First();
                        right = right[..match.Index] + (int.Parse(match.Value) + nestedPair[1]) +
                                right[(match.Index + match.Length)..];
                    }
                    input = left + "0" + right;
                    break;
                }
            }

            if (!actionTaken)
            {
                // split numbers greater than 10
                var numbers = Regex.Matches(input, @"[0-9]+");
                foreach (Match number in numbers)
                {
                    var num = int.Parse(number.Value);
                    if (num < 10) continue;
                    actionTaken = true;
                    input = input[..number.Index] + "[" + (int) Math.Floor(num / 2.0) + "," +
                            (int) Math.Ceiling(num / 2.0) + "]" +
                            input[(number.Index + number.Length)..];
                    break;
                }
            }
        } while (actionTaken);
        
        return input;
    }

    public class Pair
    {
        private static readonly Regex Reader =
            new(@"\[(\[((?>[^][]+|(?<o>)\[|(?<-o>]))*)]|[0-9]*),(\[((?>[^][]+|(?<o>)\[|(?<-o>]))*)]|[0-9]*)\]");

        public int? Left { get; set; }

        public int? Right { get; set; }

        public Pair LeftPair { get; set; }

        public Pair RightPair { get; set; }

        public int Magnitude()
        {
            return (Left ?? LeftPair.Magnitude()) * 3 + (Right ?? RightPair.Magnitude()) * 2; 
        }

        public static Pair FromString(string input)
        {
            var match = Reader.Match(input);
            var pair = new Pair();
            if (match.Groups[1].Value.StartsWith('['))
            {
                pair.LeftPair = Pair.FromString(match.Groups[1].Value);
            }
            else
            {
                pair.Left = int.Parse(match.Groups[1].Value);
            }

            if (match.Groups[3].Value.StartsWith('['))
            {
                pair.RightPair = Pair.FromString(match.Groups[3].Value);
            }
            else
            {
                pair.Right = int.Parse(match.Groups[3].Value);
            }

            return pair;
        }
    }
}