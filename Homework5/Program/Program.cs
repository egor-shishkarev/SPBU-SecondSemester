// <copyright file = "Program.cs" author = "Egor Shishkarev">
// Copyright (c) Egor Shishkarev. All rights reserved.
// </copyright>

using static Routers.RoutersTopology;

if (args.Length < 2)
{
    Console.WriteLine("Недостаточно аргументов, введите путь до файла с топологией сети!");
    return -1;
}

var fileWithTopology = args[0];

if (!File.Exists(fileWithTopology))
{
    Console.WriteLine($"Файла по данному пути - {fileWithTopology} не существует.");
    return -1;
}

var lines = File.ReadAllLines(fileWithTopology);

if (lines == null)
{
    Console.WriteLine("Файл пустой!");
    return -1;
}

try
{
    CreateOptimalConfiguration(lines, args[1]);
}
catch (Exception e) 
{
    Console.WriteLine(e.Message);
    return -1;
}

return 0;