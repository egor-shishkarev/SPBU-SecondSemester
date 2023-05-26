namespace GameLogic;

public class Map
{
    private string[] map;

    public Map(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("There is no such file!");
        }
        if (File.ReadAllLines(filePath).Length == 0)
        {
            throw new ArgumentException("Empty map!");
        }
        Console.CursorVisible = false;
        map = File.ReadAllLines(filePath);
        if (!CheckMap())
        {
            throw new ArgumentException("Wrong map!");
        }
    }

    public void PrintMap()
    {
        Console.Clear();
        foreach (var line in map)
        {
            Console.WriteLine(line);
        }
    }

    public string[] GetMap() => map;

    private bool CheckMap()
    {
        int countOfFreeSpaces = 0;
        for (int i = 0; i < map.Length; ++i)
        {
            for (int j = 0; j < map[0].Length; ++j)
            {
                if (map[i][j] == ' ')
                {
                    ++countOfFreeSpaces;
                }
                if (i == 0)
                {
                    if (map[i][j] == ' ')
                    {
                        return false;
                    }
                }
                if (i == map.Length - 1)
                {
                    if (map[i][j] == ' ')
                    {
                        return false;
                    }
                }
                if (j == 0)
                {
                    if (map[i][j] == ' ')
                    {
                        return false;
                    }
                }
                if (j == map[0].Length)
                {
                    if (map[i][j] == ' ')
                    {
                        return false;
                    }
                }
            }
        }
        return countOfFreeSpaces != 0;
    }
}
