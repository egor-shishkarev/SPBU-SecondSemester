using static System.Formats.Asn1.AsnWriter;

namespace GameLogic;

public class Coin
{
    /// <summary>
    /// Coordinates of coin on map.
    /// </summary>
    public int row;

    public int column;

    /// <summary>
    /// Is coin collected.
    /// </summary>
    public bool isCollected;

    /// <summary>
    /// Constructor for Coin class instance.
    /// </summary>
    /// <param name="map">Current map.</param>
    /// <param name="currentPosition">Current position of character.</param>
    public Coin(string[] map, (int, int) currentPosition)
    {
        isCollected = false;
        (row, column) = GetRandomPosition(map, currentPosition);
    }

    public void PrintCoin()
    {
        Console.SetCursorPosition(column, row);
        Console.Write(" \b");
        Console.Write("$");
    }

    public bool CheckPosition(Character character)
    {
        if (character.row == row && character.column == column)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Method, that find random position for coin on map.
    /// </summary>
    /// <param name="map">Current map.</param>
    /// <param name="currentPosition">Current position of character.</param>
    /// <returns>Row coordinate and column coordinate of found position coordinates.</returns>
    public static (int, int) GetRandomPosition(string[] map, (int, int) currentPosition)
    {
        Random randomNumeber = new();
        var rowNumber = randomNumeber.Next(1, map.Length - 2);
        var columnNumber = randomNumeber.Next(1, map[0].Length - 2);
        while (map[rowNumber][columnNumber] != ' ' || (rowNumber, columnNumber) == currentPosition)
        {
            rowNumber = randomNumeber.Next(1, map.Length - 2);
            columnNumber = randomNumeber.Next(1, map[0].Length - 2);
        }
        return (rowNumber, columnNumber);
    }
}
