using LZW;

Console.WriteLine("This program represents archiver with LZW algorithm");
var filePath = "C:\\Users\\Егор\\source\\repos\\SPBU-SecondSemester\\Homework3\\LZW\\LZWTests\\TestFiles\\tihiy-don-_knigi-1-i-2_.txt"; //Program.exe example.txt
var originalBytes = File.ReadAllBytes(filePath);
Archiver.Compress(filePath);
Archiver.Decompress(filePath + ".zipped");
var newBytes = File.ReadAllBytes(filePath);
Console.WriteLine($"{originalBytes.Length} {newBytes.Length}");
for (int i = 0; i < Math.Min(originalBytes.Length, newBytes.Length); ++i)
{
    if (originalBytes[i] != newBytes[i])
    {
        Console.WriteLine($"Wrong bytes at {i}");
    }
}

/*oloolooloolooloolo - this doesn't work
and this - wabbawabbawabbawabbawabba - doesn't work*/
