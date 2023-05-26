using LZW;

if (args.Length < 2)
{
    Console.Error.WriteLine("No arguments were passed!");
    return;
}

if (args.Length > 2)
{
    Console.Error.WriteLine("Too much arguments!");
    return;
}

if (args[1] == "-c")
{
    var filePath = args[0];
    var compressSize = Archiver.Compress(filePath);
    Console.WriteLine($"Коэффициент сжатия - {compressSize}");
}
else if (args[1] == "-u")
{
    var filePath = args[0];
    if (!filePath.Contains(".zipped"))
    {
        Console.WriteLine("Can't decompress not '.zipped' file");
        return;
    }
    Archiver.Decompress(filePath);
    Console.WriteLine("Decompress of file is done.");
}
else
{
    Console.WriteLine("Wrong argument!");
}
