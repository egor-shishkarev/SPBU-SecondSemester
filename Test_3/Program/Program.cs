using MTF;

Console.Write("Введите строку => ");
var inputString = Console.ReadLine();

if (string.IsNullOrEmpty(inputString))
{
    Console.WriteLine("Строка не должна быть пустой!");
    return;
}

var MTFSequence = MTFEncoding.Encode(inputString);
Console.Write("\n[");
for (int i = 0; i < MTFSequence.Length; ++i)
{
    Console.Write($"{MTFSequence[i]}");
    if (i != MTFSequence.Length - 1)
    {
        Console.Write(", ");
    }
}
Console.Write("]");