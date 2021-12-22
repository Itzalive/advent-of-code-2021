namespace AdventOfCode2021;

public class Day21
{
    public static void Part1(int player1Position, int player2Position)
    {
        Console.WriteLine();
        Console.WriteLine("Day21 Part1");

        var player1 = new Player {Position = player1Position};
        var player2 = new Player {Position = player2Position};
        var dice = new DeterministicDie();

        while (true)
        {
            player1.Play(dice);
            if (player1.Score >= 1000) break;
            player2.Play(dice);
            if (player2.Score >= 1000) break;
        }

        if (player1.Score >= 1000)
        {
            Console.WriteLine("Player 1 wins");
            Console.WriteLine(player2.Score * dice.TimesRolled);
        }
        else if (player2.Score >= 1000)
        {
            Console.WriteLine("Player 2 wins");
            Console.WriteLine(player1.Score * dice.TimesRolled);
        }
    }

    
    public static void Part2(int player1Position, int player2Position)
    {
        Console.WriteLine();
        Console.WriteLine("Day21 Part2");

        var player1 = new Player {Position = player1Position};
        var player2 = new Player {Position = player2Position};
        while (true)
        {
            
        }

        
    }

    public class Player
    {
        public int Position { get; set; }

        public int Score { get; set; }

        public void Play(IDie die)
        {
            Position = (Position - 1 + die.Roll() + die.Roll() + die.Roll()) % 10 + 1;
            Score += Position;
        }
    }

    public class DeterministicDie : IDie
    {
        private int _next;

        public int TimesRolled { get; set; }

        public int Roll()
        {
            _next = (_next % 100) + 1;
            TimesRolled++;
            return _next;
        }
    }

    public static string Input = @"";
}

public interface IDie
{
    int Roll();
}