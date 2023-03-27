using Transform;

namespace LZW;

public static class Archiver
{
    public static void Compress(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("File with this path doesn't exist!", nameof(filePath));
        }
        var binaryFile = File.ReadAllBytes(filePath) ?? throw new ArgumentException("File mustn't be empty!", nameof(filePath));
        var newFilePath = filePath + ".zipped";
        var newBytes = Encode.EncodeFile(binaryFile);
        File.WriteAllBytes(newFilePath, newBytes);
        var fileSize = new FileInfo(filePath).Length;
        var compressedFileSize = new FileInfo(newFilePath).Length;
        Console.WriteLine($"Коэффициент сжатия - {fileSize / (float)compressedFileSize}");
    }

    public static void Decompress(string filePath)
    {
        var bytes = File.ReadAllBytes(filePath);
        var newFilePath = filePath[..filePath.LastIndexOf('.')];
        var newBytes = Decode.DecodeFile(bytes);
        //foreach (var item in newBytes)
        //{
        //    Console.WriteLine(item);
        //}

        File.WriteAllBytes(newFilePath, newBytes);
    }
}