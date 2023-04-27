namespace GameLogic;

public class Character
{
    /// <summary>
    /// 
    /// </summary>
    public int row;

    public int column;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="currentCoordinates"></param>
    public Character((int, int) currentCoordinates)
    {
        row = currentCoordinates.Item1;
        column = currentCoordinates.Item2;
    }


    public void InitializeCharacter()
    {
        Console.SetCursorPosition(row, column);
        Console.Write("@");
    }

    public void ReturnToCharacter()
    {
        Console.SetCursorPosition(column, row);
    }
    public void MoveRight()
    {
        (int left, int top) = (column, row);
        Console.Write(" \b \b");
        Console.SetCursorPosition(left + 1, top);
        Console.Write("@");
        Console.SetCursorPosition(left + 1, top);
        ++column;
    }

    public void MoveLeft()
    {
        (int left, int top) = (column, row);
        Console.Write(" \b \b");
        Console.SetCursorPosition(left - 1, top);
        Console.Write("@");
        Console.SetCursorPosition(left - 1, top);
        --column;
    }

    public void MoveUp()
    {
        (int left, int top) = (column, row);
        Console.Write(" \b \b");
        Console.SetCursorPosition(left, top + 1);
        Console.Write("@");
        Console.SetCursorPosition(left, top + 1);
        ++row;
    }

    public void MoveDown()
    {
        (int left, int top) = (column, row);
        Console.Write(" \b \b");
        Console.SetCursorPosition(left, top - 1);
        Console.Write("@");
        Console.SetCursorPosition(left, top - 1);
        --row;
    }
}
