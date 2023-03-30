using LZW;

if (args.Length < 2)
{
    Console.WriteLine("No arguments were passed!");
    return;
}

if (args[1] == "-c")
{
    var filePath = args[0];
    Archiver.Compress(filePath);
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
