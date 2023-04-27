namespace GameLogic;

public class Map
{
    public string filePath;

    public string[] map;

    public Map(string filePath)
    {
        Console.CursorVisible = false;
        this.filePath = filePath;
        map = File.ReadAllLines(filePath);
    }

    public void PrintMap()
    {
        Console.Clear();
        foreach (var line in map)
        {
            Console.WriteLine(line);
        }
    }
}
