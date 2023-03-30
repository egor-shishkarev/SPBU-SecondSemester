using Transform;

namespace LZW;

/// <summary>
/// Class of archiver based on LZW
/// </summary>
public static class Archiver
{
    /// <summary>
    /// Method, that compress file.
    /// </summary>
    /// <param name="filePath">Path to the file we want to compress.</param>
    /// <exception cref="ArgumentException">File with this path doesn't exist!</exception>
    public static void Compress(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("File with this path doesn't exist!", nameof(filePath));
        }
        var binaryFile = File.ReadAllBytes(filePath);
        if (binaryFile.Length == 0)
        {
            throw new ArgumentException("File mustn't be empty!", nameof(filePath));
        }
        var newFilePath = filePath + ".zipped";
        var newBytes = Encode.EncodeFile(binaryFile);
        File.WriteAllBytes(newFilePath, newBytes);
        var fileSize = new FileInfo(filePath).Length;
        var compressedFileSize = new FileInfo(newFilePath).Length;
        Console.WriteLine($"Коэффициент сжатия - {fileSize / (float)compressedFileSize}");
    }

    /// <summary>
    /// Method, that decompress ".zipped" files.
    /// </summary>
    /// <param name="filePath">Path to the file we want to decompress.</param>
    public static void Decompress(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("File with this path doesn't exist!", nameof(filePath));
        }
        var bytes = File.ReadAllBytes(filePath);
        if (bytes.Length == 0)
        {
            throw new ArgumentException("File mustn't be empty!", nameof(filePath));
        }
        var newFilePath = filePath[..filePath.LastIndexOf('.')];
        var newBytes = Decode.DecodeFile(bytes);
        File.Delete(filePath);
        File.WriteAllBytes(newFilePath, newBytes);
    }
}