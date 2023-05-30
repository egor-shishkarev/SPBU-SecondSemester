using Transform;
using System.Text;

if (!BWTTest.Test())
{
    Console.WriteLine("Тесты не были пройдены!");
    return -1;
}
Console.WriteLine("Тесты успешно пройдены!");
Console.Write("Введите строку, которую хотите получить преобразованием Барроуза-Уилера => ");
var stringToConvert = Console.ReadLine();
if (string.IsNullOrEmpty(stringToConvert))
{
    Console.Error.WriteLine("\nСтрока не была введена!");
    return - 1;
}
if (stringToConvert.Contains('\0'))
{
    Console.Error.WriteLine($"\nБыл введён запрещённый символ - \\0 - char {(int)'\0'}, проверьте строку и повторите ввод!");
    return -1;
}
(StringBuilder BWTString, int lastPosition) = BWT.DirectBWT(stringToConvert);
if (BWTString.Length != stringToConvert.Length && lastPosition == 0)
{
    Console.Error.WriteLine("Произошла ошибка при преобразовании строки!");
    return -1;
}
Console.WriteLine(BWTString.ToString() + $" Позиция конца строки - {lastPosition}");
Console.WriteLine("Исходная строка - " + BWT.ReverseBWT(BWTString, lastPosition).ToString());
return 0;