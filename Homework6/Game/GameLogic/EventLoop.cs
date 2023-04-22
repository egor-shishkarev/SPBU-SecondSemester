namespace GameLogic;

public class EventLoop
{
    public static void Game(string mapPath, bool customMap)
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
        Console.Clear();
        foreach (var line in map)
        {
            Console.WriteLine(line);
        }
        Console.SetCursorPosition(45, 0);
        Console.WriteLine("Ваш счёт: 0");
        Console.SetCursorPosition(1, 1);
        Console.Write("@");
        Console.SetCursorPosition(1, 1);
        Console.CursorVisible = false;
        (int rowNumberCoin, int columnNumberCoin) = GetRandomPosition(map);
        Console.SetCursorPosition(columnNumberCoin, rowNumberCoin);
        Console.Write(" \b");
        Console.Write("$");
        Console.SetCursorPosition(1, 1);
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
                score += 10;
                Console.Write($"{score}");
                Console.SetCursorPosition(columnNumberCoin, rowNumberCoin);
                
                (rowNumberCoin, columnNumberCoin) = GetRandomPosition(map);
                Console.SetCursorPosition(columnNumberCoin, rowNumberCoin);
                Console.Write(" \b");
                Console.Write("$");
                if (score == 10)
                {
                    PrintFirework();
                    Console.SetCursorPosition(0, 22);
                    if ((Convert.ToInt16(mapPath[mapPath.IndexOf('l') + 1]) - 48) != 3 && !customMap)
                    {
                        Console.WriteLine("Для перехода на другой уровень нажмите Enter.");
                        Console.ReadLine();
                    }
                    if (mapPath[mapPath.IndexOf('l') + 1] != '3' && !customMap)
                    {
                        Game(mapPath[..(mapPath.IndexOf('l') + 1)] + (Convert.ToInt16(mapPath[mapPath.IndexOf('l') + 1]) - 47).ToString() + ".txt", false);
                        return;
                    }
                }
                Console.SetCursorPosition(currentColumn, currentRow);
            }
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.R)
            {
                Game(mapPath, customMap);
                return;
            }
            if (key.Key == ConsoleKey.Escape)
            {
                Console.SetCursorPosition(0, 22);
                return;
            }
            if (key.Key == ConsoleKey.LeftArrow)
            {
                (int left, int top) = Console.GetCursorPosition();
                if (walls[top, left - 1] == 1)
                {
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine("Вы проиграли, нажмите R, чтобы начать уровень заново или Esc, чтобы выйти из игры.");
                    while (true)
                    {
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.R)
                        {
                            Game(mapPath, customMap);
                            return;
                        }
                        else if (key.Key == ConsoleKey.Escape)
                        {
                            return;
                        }
                    }
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
                    Console.WriteLine("Вы проиграли, нажмите R, чтобы начать уровень заново или Esc, чтобы выйти из игры.");
                    while (true)
                    {
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.R)
                        {
                            Game(mapPath, customMap);
                            return;
                        }
                        else if (key.Key == ConsoleKey.Escape)
                        {
                            return;
                        }
                    }
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
                    Console.WriteLine("Вы проиграли, нажмите R, чтобы начать уровень заново или Esc, чтобы выйти из игры.");
                    while (true)
                    {
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.R)
                        {
                            Game(mapPath, customMap);
                            return;
                        }
                        else if (key.Key == ConsoleKey.Escape)
                        {
                            return;
                        }
                    }
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
                    Console.WriteLine("Вы проиграли, нажмите R, чтобы начать уровень заново или Esc, чтобы выйти из игры.");
                    while (true)
                    {
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.R)
                        {
                            Game(mapPath, customMap);
                            return;
                        }
                        else if (key.Key == ConsoleKey.Escape)
                        {
                            return;
                        }
                    }
                }
                Console.Write(" \b \b");
                Console.SetCursorPosition(left, top + 1);
                Console.Write("@");
                Console.SetCursorPosition(left, top + 1);
            }
        }
    }
    private static (int, int) GetRandomPosition(string[] map)
    {
        Random randomNumeber = new();
        var rowNumber = randomNumeber.Next(1, map.Length - 2);
        var columnNumber = randomNumeber.Next(1, map[0].Length - 2);
        while (map[rowNumber][columnNumber] != ' ')
        {
            rowNumber = randomNumeber.Next(1, map.Length - 2);
            columnNumber = randomNumeber.Next(1, map[0].Length - 2);
        }
        return (rowNumber, columnNumber);

    }

    private static void PrintFirework()
    {
        var firework = File.ReadAllLines("../../../FireWork.txt");
        for (int i = 0; i < 7; ++i)
        {
            Console.SetCursorPosition(45, 5 + i);
            Console.Write(firework[i]);
        }
    }
}
