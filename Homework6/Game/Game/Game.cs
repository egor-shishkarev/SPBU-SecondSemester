using static GameLogic.EventLoop;

if (args.Length < 1)
{
    Console.WriteLine("Не указана текущая карта игры!");
    return -1;
}

Game(args[0]);
return 0;