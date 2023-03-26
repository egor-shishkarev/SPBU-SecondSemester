using LZW;
using Transform;

//Console.WriteLine("Введите путь к файлу, который хотите сжать => ");
//var filePath = Console.ReadLine();
//while (string.IsNullOrEmpty(filePath))
//{
//    Console.WriteLine("Путь не был введен, повторите ввод => ");
//    filePath = Console.ReadLine();
//}
Console.WriteLine("This program represents archiver with LZW algorithm");
var filePath = "C:\\Users\\Егор\\source\\repos\\SPBU-SecondSemester\\Homework3\\LZW\\LZWTests\\TestFiles\\example.txt";
var originalBytes = File.ReadAllBytes(filePath);
Archiver.Compress(filePath);
Archiver.Decompress(filePath + ".zipped");
var newBytes = File.ReadAllBytes(filePath);
for (int i = 0; i < Math.Min(originalBytes.Length, newBytes.Length); ++i)
{
    if (originalBytes[i] != newBytes[i])
    {
        Console.WriteLine($"Wrong bytes at {i}");
    }
}


