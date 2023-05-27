using Transform;
using System.Text;

if (!BWTTest.Test())
{
    Console.WriteLine("Тесты не были пройдены!");
    return;
}
Console.WriteLine("Тесты успешно пройдены!");
Console.Write("Введите строку, которую хотите получить преобразованием Барроуза-Уилера => ");
var stringToConvert = Console.ReadLine();
if (string.IsNullOrEmpty(stringToConvert))
{
    Console.WriteLine("\nСтрока не была введена!");
    return;
}
if (stringToConvert.Contains('\0'))
{
    Console.WriteLine($"\nБыл введён запрещённый символ - \\0 - char {(int)'\0'}, проверьте строку и повторите ввод!");
    return;
}
(StringBuilder BWTString, int lastPosition) = BWT.DirectBWT(stringToConvert);
if (BWTString.Length != stringToConvert.Length && lastPosition == 0)
{
    Console.WriteLine("Произошла ошибка при преобразовании строки!");
    return;
}
Console.WriteLine(BWTString.ToString() + $" Позиция конца строки - {lastPosition}");
Console.WriteLine("Исходная строка - " + BWT.ReverseBWT(BWTString, lastPosition).ToString());
