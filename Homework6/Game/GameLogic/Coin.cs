namespace GameLogic;

public class Coin
{
    /// <summary>
    /// Coordinates of coin on map.
    /// </summary>
    public int row; // Паблик 

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

    public bool CheckPosition(Character character) // Нулл 
    {
        return character.row == row && character.column == column;
    }

    /// <summary>
    /// Method, that find random position for coin on map.
    /// </summary>
    /// <param name="map">Current map.</param>
    /// <param name="currentPosition">Current position of character.</param>
    /// <returns>Row coordinate and column coordinate of found position coordinates.</returns>
    private static (int, int) GetRandomPosition(string[] map, (int, int) currentPosition)
    {
        Random randomNumber = new();
        var rowNumber = randomNumber.Next(1, map.Length - 1);
        var columnNumber = randomNumber.Next(1, map[0].Length - 1);
        while (map[rowNumber][columnNumber] != ' ' || (rowNumber, columnNumber) == currentPosition) // К карте и её проверке - бесконечный цикл
        {
            rowNumber = randomNumber.Next(1, map.Length - 1);
            columnNumber = randomNumber.Next(1, map[0].Length - 1);
        }
        return (rowNumber, columnNumber);
    }
}
