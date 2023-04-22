using static GameLogic.EventLoop;

if (args.Length < 1)
{
    Console.WriteLine("Не указана текущая карта игры!");
    return -1;
}

Console.Clear();
Console.WriteLine("Добро пожаловать в игру - сборщик монет.\nПеред вами появится лабиринт, проходя через который, " +
    "не касаясь стен вы должны собрать появляющиеся монетки.\nСчет отображается в правом верхнем углу экрана.\nУдачи!");
if (args.Length == 1)
{
    Console.WriteLine("\nДля старта игры нажмите на Enter.");
    Console.ReadLine();
    Game(args[0], false);
}

if (args.Length == 2 && args[1] == "-c")
{
    Console.WriteLine("Внимание! Вы играете на персонализированной карте! Играйте на свой страх и риск, " +
        "так как карта не была проверена программой!");
    Console.WriteLine("\nДля старта игры нажмите на Enter.");
    Console.ReadLine();
    Game(args[0], true);
} 


return 0;