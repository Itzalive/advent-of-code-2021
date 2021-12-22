namespace AdventOfCode2021;

public class Day12
{
    public static void Part1(string input)
    {
        Console.WriteLine();
        Console.WriteLine("Day12 Part1");

        var connections = input.Split(Environment.NewLine).Select(c => c.Split('-')).ToArray();
        var nodes = connections.SelectMany(c => c).Distinct().Select(c => new Node(c)).ToDictionary(n => n.Name);

        foreach (var connection in connections)
        {
            nodes[connection[0]].Nodes.Add(nodes[connection[1]]);
            nodes[connection[1]].Nodes.Add(nodes[connection[0]]);
        }

        var paths = TravelToEnd(new List<string> {"start"}, nodes["start"], 1);

        foreach (var path in paths)
        {
            Console.WriteLine(string.Join(", ", path));
        }
        Console.WriteLine(paths.Count);
    }

    private static List<List<string>> TravelToEnd(List<string> path, Node curentNode, int smallCaveCount) {
        var list = new List<List<string>>();

        if (curentNode.Name == "end")
        {
            list.Add(path);
            return list;
        }

        foreach (var node in curentNode.Nodes) {
            if (node.IsBig && (path.Count < 3 || path[^1] != node.Name) || !node.IsBig && path.Count(p => p == node.Name) < smallCaveCount && path.Where(p => p.ToLower() == p).GroupBy(p => p).Count(g => g.Count() > 1) <=1 && node.Name != "start")
            {
                var newPath = path.Select(p => p).ToList();
                newPath.Add(node.Name);
                list.AddRange(TravelToEnd(newPath, node, smallCaveCount));
            }
        }

        return list;
    }

    public static void Part2(string input)
    {
        Console.WriteLine();
        Console.WriteLine("Day12 Part2");
        var connections = input.Split(Environment.NewLine).Select(c => c.Split('-')).ToArray();
        var nodes = connections.SelectMany(c => c).Distinct().Select(c => new Node(c)).ToDictionary(n => n.Name);

        foreach (var connection in connections)
        {
            nodes[connection[0]].Nodes.Add(nodes[connection[1]]);
            nodes[connection[1]].Nodes.Add(nodes[connection[0]]);
        }

        var paths = TravelToEnd(new List<string> {"start"}, nodes["start"], 2);

        foreach (var path in paths)
        {
            Console.WriteLine(string.Join(", ", path));
        }
        Console.WriteLine(paths.Count);
    }

    public static string TestInput1 = @"start-A
start-b
A-c
A-b
b-d
A-end
b-end";

    public static string TestInput2 = @"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc";

    public static string TestInput3 = @"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW";

    public static string Input = @"TR-start
xx-JT
xx-TR
hc-dd
ab-JT
hc-end
dd-JT
ab-dd
TR-ab
vh-xx
hc-JT
TR-vh
xx-start
hc-ME
vh-dd
JT-bm
end-ab
dd-xx
end-TR
hc-TR
start-vh";

    public class Node
    {
        public string Name { get; set; }
        
        public bool IsBig { get; set; }

        public List<Node> Nodes { get; set; } = new List<Node>();

        public Node(string name)
        {
            Name = name;
            IsBig = name.ToLower() != name;
        }
    }
}