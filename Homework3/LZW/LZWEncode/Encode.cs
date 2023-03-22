namespace LZW;

public class Encode
{
    public static void EncodeFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("This file doesn't exists!");
        }
        var binaryFile = File.ReadAllBytes(filePath);
        foreach ( var entry in binaryFile )
        {
            Console.WriteLine(entry);
        }
    }
}