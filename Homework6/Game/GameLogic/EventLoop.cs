namespace GameLogic;

public class EventLoop
{
    public static void Game(string mapPath)
    {
        var map = File.ReadAllLines(mapPath);
        var walls = new int[map.Length, map[0].Length];
        for (int i = 0; i < map.Length; ++i)
        {
            for (int j = 0; j < map[0].Length; ++j)
            {
                if (map[i][j] != ' ')
                {
                    walls[i, j] = 1;
                } 
                else
                {
                    walls[i, j] = 0;
                }
            }
        }
        foreach (var line in map)
        {
            Console.WriteLine(line);
        }
        Console.SetCursorPosition(45, 0);
        Console.WriteLine("Ваш счёт: 0");
        Console.SetCursorPosition(20, 9);
        Console.Write("@");
        Console.SetCursorPosition(20, 9);
        Console.CursorVisible = false;
        (int rowNumberCoin, int columnNumberCoin) = GetRandomPosition(walls);
        Console.SetCursorPosition(columnNumberCoin, rowNumberCoin);
        Console.Write(" \b");
        Console.Write("$");
        Console.SetCursorPosition(20, 9);
        int score = 0;
        while (true)
        {
            if (Console.GetCursorPosition() == (columnNumberCoin, rowNumberCoin))
            {
                var currentRow = rowNumberCoin;
                var currentColumn = columnNumberCoin;
                Console.SetCursorPosition(55, 0);
                Console.SetCursorPosition(55, 0);
                for (int i = 0; i < score.ToString().Length; ++i)
                {
                    Console.Write(" \b");
                }
                score += 500;
                Console.Write($"{score}");
                Console.SetCursorPosition(columnNumberCoin, rowNumberCoin);
                
                (rowNumberCoin, columnNumberCoin) = GetRandomPosition(walls);
                Console.SetCursorPosition(columnNumberCoin, rowNumberCoin);
                Console.Write(" \b");
                Console.Write("$");
                Console.SetCursorPosition(currentColumn, currentRow);
            }
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.LeftArrow)
            {
                (int left, int top) = Console.GetCursorPosition();
                if (walls[top, left - 1] == 1)
                {
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine("Вы проиграли");
                    break;
                }
                Console.Write(" \b \b");
                Console.SetCursorPosition(left - 1, top);
                Console.Write("@");
                Console.SetCursorPosition(left - 1, top);
            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                (int left, int top) = Console.GetCursorPosition();
                if (walls[top, left + 1] == 1)
                {
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine("Вы проиграли");
                    break;
                }
                Console.Write(" \b \b");
                Console.SetCursorPosition(left + 1, top);
                Console.Write("@");
                Console.SetCursorPosition(left + 1, top);
            }
            if (key.Key == ConsoleKey.UpArrow)
            {
                (int left, int top) = Console.GetCursorPosition();
                if (walls[top - 1, left] == 1)
                {
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine("Вы проиграли");
                    break;
                }
                Console.Write(" \b \b");
                Console.SetCursorPosition(left, top - 1);
                Console.Write("@");
                Console.SetCursorPosition(left, top - 1);
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                (int left, int top) = Console.GetCursorPosition();
                if (walls[top + 1, left] == 1)
                {
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine("Вы проиграли");
                    break;
                }
                Console.Write(" \b \b");
                Console.SetCursorPosition(left, top + 1);
                Console.Write("@");
                Console.SetCursorPosition(left, top + 1);
            }
        }
    }
    private static (int, int) GetRandomPosition(int[,] walls)
    {
        Random randomNumeber = new();
        var rowNumber = randomNumeber.Next(1, 18);
        var columnNumber = randomNumeber.Next(1, 40);
        while (walls[rowNumber, columnNumber] != 0)
        {
            rowNumber = randomNumeber.Next(1, 18);
            columnNumber = randomNumeber.Next(1, 40);
        }
        return (rowNumber, columnNumber);

    }
}
