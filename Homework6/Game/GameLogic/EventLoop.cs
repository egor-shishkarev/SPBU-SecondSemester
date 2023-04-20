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
        Console.SetCursorPosition(1, 1);
        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.LeftArrow)
            {
                (int left, int top) = Console.GetCursorPosition();
                if (walls[top, left - 1] == 1)
                {
                    continue;
                }
                Console.SetCursorPosition(left - 1, top);
            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                (int left, int top) = Console.GetCursorPosition();
                if (walls[top, left + 1] == 1)
                {
                    continue;
                }
                Console.SetCursorPosition(left + 1, top);
            }
            if (key.Key == ConsoleKey.UpArrow)
            {
                (int left, int top) = Console.GetCursorPosition();
                if (walls[top - 1, left] == 1)
                {
                    continue;
                }
                Console.SetCursorPosition(left, top - 1);
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                (int left, int top) = Console.GetCursorPosition();
                if (walls[top + 1, left] == 1)
                {
                    continue;
                }
                Console.SetCursorPosition(left, top + 1);
            }
        }
    }
}
