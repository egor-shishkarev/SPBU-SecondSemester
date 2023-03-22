using LZW;

Console.WriteLine("Введите путь к файлу, который хотите сжать => ");
var filePath = Console.ReadLine();
while (string.IsNullOrEmpty(filePath))
{
    Console.WriteLine("Путь не был введен! Потворите ввод => ");
}

Encode.EncodeFile(filePath);