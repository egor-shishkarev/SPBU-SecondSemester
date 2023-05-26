using GameLogic;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.Clear();
Console.WriteLine("Добро пожаловать в игру - охотник за монетами.\nПеред вами появится лабиринт, проходя через который, " +
    "не касаясь стен, вы должны собрать появляющиеся монетки.\nСчет отображается в правом верхнем углу экрана. На каждом уровне вы должны собрать 10 монет.\nУдачи!");
Console.WriteLine("Управление - стрелки на клавиатуре, Esc - для выхода из игры, R - для перезапуска уровня.");

if (args.Length == 0)
{
    Console.WriteLine("\nДля старта игры нажмите любую кнопку.");
    Console.ReadKey(true);
    var game = new Game("../../../Level1.txt", false);
    Game.Run();
}

if (args.Length == 1)
{

    Console.WriteLine("Внимание! Вы играете на персонализированной карте! Играйте на свой страх и риск, " +
        "так как карта не была проверена программой!");
    Console.WriteLine("\nДля старта игры нажмите любую кнопку.");
    Console.ReadKey(true);
    var game = new Game(args[0], true);
    Game.Run();
}

return 0;