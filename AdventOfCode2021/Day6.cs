namespace AdventOfCode2021;

public class Day6
{
    public static void Part1(string input)
    {
        Console.WriteLine();
        Console.WriteLine("Day6 Part1");

        var fish = input.Split(',').Select(a => new LanternFish(int.Parse(a))).ToList();
        for (var day = 0; day < 80 ; day++)
        {
            var newFish = fish.Count(f => f.Spawn());
            fish.ForEach(f => f.GetOlder());
            fish.AddRange(Enumerable.Range(0, newFish).Select(c => new LanternFish()));
        }

        Console.WriteLine(fish.Count);
    }

    public static void Part2(string input)
    {
        Console.WriteLine();
        Console.WriteLine("Day6 Part2");

        var fishCount = new long[9];

        var fish = input.Split(',').Select(int.Parse).ToList();
        var grouped = fish.GroupBy(f => f).ToArray();
        foreach (var group in grouped)
        {
            fishCount[group.Key] = group.Count();
        }

        for (var day = 0; day < 256 ; day++)
        {
            var newFish = fishCount[0];
            var newFishCount = new long[fishCount.Length];
            Array.Copy(fishCount, 1, newFishCount, 0, fishCount.Length - 1);
            fishCount = newFishCount;
            fishCount[6] += newFish;
            fishCount[8] = newFish;
        }

        Console.WriteLine(fishCount.Sum());
    }

    public static string TestInput = "3,4,3,1,2";

    public static string Input = @"3,5,3,1,4,4,5,5,2,1,4,3,5,1,3,5,3,2,4,3,5,3,1,1,2,1,4,5,3,1,4,5,4,3,3,4,3,1,1,2,2,4,1,1,4,3,4,4,2,4,3,1,5,1,2,3,2,4,4,1,1,1,3,3,5,1,4,5,5,2,5,3,3,1,1,2,3,3,3,1,4,1,5,1,5,3,3,1,5,3,4,3,1,4,1,1,1,2,1,2,3,2,2,4,3,5,5,4,5,3,1,4,4,2,4,4,5,1,5,3,3,5,5,4,4,1,3,2,3,1,2,4,5,3,3,5,4,1,1,5,2,5,1,5,5,4,1,1,1,1,5,3,3,4,4,2,2,1,5,1,1,1,4,4,2,2,2,2,2,5,5,2,4,4,4,1,2,5,4,5,2,5,4,3,1,1,5,4,5,3,2,3,4,1,4,1,1,3,5,1,2,5,1,1,1,5,1,1,4,2,3,4,1,3,3,2,3,1,1,4,4,3,2,1,2,1,4,2,5,4,2,5,3,2,3,3,4,1,3,5,5,1,3,4,5,1,1,3,1,2,1,1,1,1,5,1,1,2,1,4,5,2,1,5,4,2,2,5,5,1,5,1,2,1,5,2,4,3,2,3,1,1,1,2,3,1,4,3,1,2,3,2,1,3,3,2,1,2,5,2";

    public class LanternFish
    {
        public int Age { get; set; }

        public LanternFish(int initialAge = 8)
        {
            Age = initialAge;
        }

        public bool Spawn()
        {
            if (Age != 0) return false;

            Age = 7;
            return true;
        }

        public void GetOlder()
        {
            Age--;
        }
    }
}