using System.Text;

namespace AdventOfCode2021;

public class Day14
{
    public static Dictionary<string, Dictionary<char, long>> Cache = new();

    public static int CompletedDepth = 0;

    public static void Part1(string input)
    {
        Console.WriteLine();
        Console.WriteLine("Day14 Part1");

        var puzzle = input.Split(Environment.NewLine + Environment.NewLine);
        var insertions = puzzle[1].Split(Environment.NewLine).Select(r => r.Split(" -> "))
            .ToDictionary(r => r[0], r => r[1]);

        var value = puzzle[0];
        for (var i = 0; i < 10; i++)
        {
            var newValue = "";
            for (var j = 0; j < value.Length - 1; j++)
            {
                newValue += value[j];
                if (insertions.ContainsKey(value[j..(j + 2)]))
                {
                    newValue += insertions[value[j..(j + 2)]];
                }
            }

            newValue += value[^1];
            value = newValue;
            Console.WriteLine(value);
        }

        var counts = value.ToCharArray().GroupBy(c => c).Select(g => g.Count()).ToArray();
        Console.WriteLine(counts.Max() - counts.Min());
    }

    public static void Part2(string input)
    {
        Console.WriteLine();
        Console.WriteLine("Day14 Part2");

        var puzzle = input.Split(Environment.NewLine + Environment.NewLine);
        var insertions = puzzle[1].Split(Environment.NewLine).Select(r => r.Split(" -> "))
            .ToDictionary(r => r[0], r => r[1]);
        
        var stats = GetStats(puzzle[0], insertions, 40);
        Console.WriteLine(stats.Values.Max() - stats.Values.Min());
    }

public static Dictionary<char, long> GetStats(string value, Dictionary<string, string> insertions, int depth)
{
    var cacheKey = $"{depth}-{value}";
    if (Cache.ContainsKey(cacheKey))
        return Cache[cacheKey];
    var untestedValue = "";
    if (depth < 15)
    {
        for (var i = 0; i < depth; i++)
        {
            var newValue = new StringBuilder();
            for (var j = 0; j < value.Length - 1; j++)
            {
                newValue.Append(value[j]);
                if (insertions.ContainsKey(value[j..(j + 2)]))
                {
                    newValue.Append(insertions[value[j..(j + 2)]]);
                }
            }

            newValue.Append(value[^1]);
            value = newValue.ToString();
        }

        var statsVar = value.ToCharArray().GroupBy(c => c).ToDictionary(g => g.Key, g => g.LongCount());
        Cache.Add(cacheKey, statsVar);
        return statsVar;
    }

    var stats = new Dictionary<char, long>();
    for (var j = 0; j < value.Length - 1; j++)
    {
        untestedValue += value[j];
        var pair = value[j..(j + 2)];
        if (insertions.ContainsKey(pair))
        {
            untestedValue += insertions[pair];
        }

        untestedValue += value[j + 1];
        
        var newStats = GetStats(untestedValue, insertions, depth - 1);
        foreach (var (key, l) in newStats)
        {
            if (stats.ContainsKey(key))
            {
                stats[key] += l;
            }
            else
            {
                stats.Add(key, l);
            }
        }                                                                                              
        if(j < value.Length - 2)
            stats[value[j + 1]]--;
        untestedValue = "";
    }

    if (depth > CompletedDepth)
    {
        CompletedDepth = depth;
        Console.WriteLine("Depth " + depth);
    }

    return stats;
}

public static string TestInput = @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";

    public static string Input = @"KHSNHFKVVSVPSCVHBHNP

FV -> H
SB -> P
NV -> S
BS -> K
KB -> V
HB -> H
NB -> N
VB -> P
CN -> C
CF -> N
OF -> P
FO -> K
OC -> F
BN -> V
PO -> O
OS -> B
KH -> N
BB -> C
PV -> K
ON -> K
NF -> H
BV -> K
SN -> N
PB -> S
PK -> F
PF -> S
BP -> K
SP -> K
NN -> K
FP -> N
NK -> N
SF -> P
HS -> C
OH -> C
FS -> H
VH -> N
CO -> P
VP -> H
FF -> N
KP -> B
BH -> B
PP -> F
SS -> P
CV -> S
HO -> P
PN -> K
SO -> O
NO -> O
NH -> V
HH -> F
KK -> C
VO -> B
KS -> B
SV -> O
OP -> S
VK -> H
KF -> O
CP -> H
SH -> H
NC -> S
KC -> O
CK -> H
CH -> B
KO -> O
OV -> P
VF -> V
HN -> P
FH -> P
BC -> V
HV -> N
BO -> V
PH -> P
NP -> F
FN -> F
FK -> P
SC -> C
KN -> S
NS -> S
OK -> S
HK -> O
PC -> O
BK -> O
OO -> P
BF -> N
SK -> V
VS -> B
HP -> H
VC -> V
KV -> P
FC -> H
HC -> O
HF -> S
CB -> H
CC -> B
PS -> C
OB -> B
CS -> S
VV -> S
VN -> H
FB -> N";
}