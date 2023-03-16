using StackCalculatorClass;

Console.WriteLine("Данная программа позволяет продемонстрировать вычисление выражения в виде польской записи.\n");
Console.WriteLine("Введите выражение, отделяя числа и операции пробелом");
var expression = Console.ReadLine();
while (string.IsNullOrEmpty(expression))
{
    Console.WriteLine("Строка не была введена, повторите ввод => ");
    expression = Console.ReadLine();
}
var arrayStack = new ArrayStack();
var stackCalculator = new StackCalculator(arrayStack);
(float resultByArrayStack, bool notDivisionByZeroArray) = stackCalculator.CalculateExpression(expression);
if (!notDivisionByZeroArray)
{
    Console.WriteLine("Обнаружена попытка поделить на ноль!");
    return;
}
Console.WriteLine($"Результат вычисления стэком, основанным на массиве - {resultByArrayStack}");
var listStack = new ListStack();
stackCalculator = new StackCalculator(listStack);
(float resultByListStack, bool notDivisionByZeroList) = stackCalculator.CalculateExpression(expression);
if (!notDivisionByZeroArray)
{
    Console.WriteLine("Обнаружена попытка поделить на ноль!");
    return;
}
Console.WriteLine($"Результат вычисления стэком, основанным на списке - {resultByListStack}");
