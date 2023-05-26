namespace GameLogic;

public class Game
{
    private static Map map; // Нулевые переменные

    private static Character character;

    private static Coin currentCoin;

    private static Score score;

    private static string mapPath;

    private bool customMap;

    private static EventLoop eventLoop;
    public Game(string path, bool isCustom)
    {
        map = new Map(path); // В отдельном классе // Корректность карты, корректный путь, нулл, 
        score = new Score(); 
        character = new Character((1, 1));
        currentCoin = new Coin(map.GetMap(), (1, 1));
        mapPath = path;
        customMap = isCustom;
        map.PrintMap();
        score.InitalizeScore(map.GetMap()[0].Length);
        character.InitializeCharacter();
        currentCoin.PrintCoin();
        character.ReturnToCharacter();
        while (true)  
        {
            CheckPosition();
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.R)
            {
                new Game(mapPath, customMap);
                return;
            }
            if (key.Key == ConsoleKey.Escape)
            {
                Console.SetCursorPosition(0, 22);
                return;
            }
            if (key.Key == ConsoleKey.LeftArrow)
            {
                MoveLeft();
            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                MoveRight();
            }
            if (key.Key == ConsoleKey.UpArrow)
            {
                MoveUp();
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                MoveDown();
            }
        }
    }

    //private static void PrintFirework(bool isEnd, Map map)
    //{
    //    var firework = File.ReadAllLines("../../../FireWork.txt"); // Без файла - сразу выводить 
    //    for (int i = 0; i < 6; ++i)
    //    {
    //        Console.SetCursorPosition(map.GetMap()[0].Length + 5, 5 + i);
    //        Console.Write(firework[i]);
    //    }
    //    if (!isEnd)
    //    {
    //        Console.SetCursorPosition(map.GetMap()[0].Length + 5, 11); // Магические константы 
    //        Console.WriteLine(firework[6]);
    //    } 
    //    else
    //    {
    //        Console.SetCursorPosition(map.GetMap()[0].Length + 5, 11);
    //        Console.Write("Вы прошли игру!");
    //        Console.SetCursorPosition(map.GetMap()[0].Length + 5, 12);
    //        Console.WriteLine("Можете продолжать играть!");
    //    }
    //}

    public static void Run()
    {
        eventLoop = new EventLoop();
        eventLoop.RightHandler += Logic.OnRight;
        eventLoop.LeftHandler += Logic.OnLeft;
        eventLoop.UpHandler += Logic.OnUp;
        eventLoop.DownHandler += Logic.OnDown;
        eventLoop.RestartHandler += Logic.OnRKey;

        eventLoop.Run();
    }

    public static void Stop(object? sender, EventArgs args)
    {
        eventLoop.RightHandler -= Logic.OnRight;
        eventLoop.LeftHandler -= Logic.OnLeft;
        eventLoop.UpHandler -= Logic.OnUp;
        eventLoop.DownHandler -= Logic.OnDown;
        eventLoop.RestartHandler -= Logic.OnRKey;
        Console.Clear();
    }

    private void CheckPosition()
    {
        if (currentCoin.CheckPosition(character))
        {
            score.IncreaseScore(10);
            score.PrintScore(map.GetMap()[0].Length);
            if (score.currentScore == 10)
            {
                //PrintFirework(mapPath[mapPath.IndexOf('l') + 1] == '3', map);
                Console.SetCursorPosition(0, 22);
                if (mapPath[mapPath.IndexOf('l') + 1] != '3' && !customMap) // l - в переменную 
                {
                    Console.WriteLine("Для перехода на следующий уровень нажмите любую кнопку.");
                    Console.ReadKey(true);
                    new Game(mapPath[..(mapPath.IndexOf('l') + 1)] + (Convert.ToInt16(mapPath[mapPath.IndexOf('l') + 1]) - 47).ToString() + ".txt", false);
                    return;
                }
            }
            currentCoin = new Coin(map.GetMap(), (character.row, character.column));
            currentCoin.PrintCoin();
            character.ReturnToCharacter();
        }
    }

    private void MoveLeft()
    {
        if (map.GetMap()[character.row][character.column - 1] != ' ')
        {
            Console.SetCursorPosition(0, 22);
            Console.WriteLine("Вы проиграли, нажмите R, чтобы начать уровень заново или Esc, чтобы выйти из игры.");
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.R)
                {
                    new Game(mapPath, customMap);
                    return;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    return;
                }
            }
        }
        character.MoveLeft();
    }

    private void MoveRight()
    {
        if (map.GetMap()[character.row][character.column + 1] != ' ')
        {
            Console.SetCursorPosition(0, 22);
            Console.WriteLine("Вы проиграли, нажмите R, чтобы начать уровень заново или Esc, чтобы выйти из игры.");
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.R)
                {
                    new Game(mapPath, customMap);
                    return;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    return;
                }
            }
        }
        character.MoveRight();
    }

    private void MoveUp() 
    {
        if (map.GetMap()[character.row - 1][character.column] != ' ')
        {
            Console.SetCursorPosition(0, 22);
            Console.WriteLine("Вы проиграли, нажмите R, чтобы начать уровень заново или Esc, чтобы выйти из игры.");
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.R)
                {
                    new Game(mapPath, customMap);
                    return;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    return;
                }
            }
        }
        character.MoveDown();
    }

    private void MoveDown()
    {
        if (map.GetMap()[character.row + 1][character.column] != ' ')
        {
            Console.SetCursorPosition(0, 22);
            Console.WriteLine("Вы проиграли, нажмите R, чтобы начать уровень заново или Esc, чтобы выйти из игры.");
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.R)
                {
                    new Game(mapPath, customMap);
                    return;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    return;
                }
            }
        }
        character.MoveUp();
    }
}
