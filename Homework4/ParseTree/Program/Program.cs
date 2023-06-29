using Trees;

Console.WriteLine("Данная программа позовляет вычислять выражение по дереву разбора.");
Console.WriteLine("Введите путь до файла в котором содержится дерево разбора => ");
var filePath = Console.ReadLine();
while (string.IsNullOrEmpty(filePath))
{
    Console.WriteLine("Путь не был введен или была введена пустая строка, повторите ввод => ");
    filePath = Console.ReadLine();
}

if (!File.Exists(filePath))
{
    Console.Error.WriteLine("Такого файла не существует, проверьте правильность ввода пути и существование файла!");
    return -1;
}

var expression = File.ReadAllText(filePath);

if (string.IsNullOrEmpty(expression))
{
    Console.Error.WriteLine("Файл был пуст, пожалуйста, проверьте содержание файла.");
    return -1;
}

ParseTree parseTree;
try
{
    parseTree = new ParseTree(expression);
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
    return -1;
}

double result;
try
{
    result = parseTree.Calculate();
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
    return -1;
}
Console.WriteLine($"Результат вычисления выражения по дереву - {result}");
Console.WriteLine("Дерево разбора: ");
parseTree.Print();
return 0;