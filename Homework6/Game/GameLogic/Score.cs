namespace GameLogic;

public class Score
{ 
    public int currentScore; // Публичные поля

    public Score()
    {
    }

    public void IncreaseScore(int gain) // Могут быть -
    {
        currentScore += gain;
    }

    public void InitalizeScore(int countOfColumns) // Проверять
    {
        Console.SetCursorPosition(countOfColumns + 7, 0); // Константы
        Console.WriteLine("Ваш счёт: 0");
        Console.SetCursorPosition(1, 1);
    }

    public void PrintScore(int countOfColumns)
    {
        Console.SetCursorPosition(countOfColumns + 17, 0); // Константы
        for (int i = 0; i < currentScore.ToString().Length; ++i)
        {
            Console.Write(" \b");
        }
        Console.Write($"{currentScore}");
    }
}
