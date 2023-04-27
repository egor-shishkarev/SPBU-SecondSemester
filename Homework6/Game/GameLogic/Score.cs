namespace GameLogic;

public class Score
{
    public int currentScore;

    public Score()
    {
        currentScore = 0;
    }

    public void IncreaseScore(int gain)
    {
        currentScore += gain;
    }

    public void InitalizeScore(int countOfColumns)
    {
        Console.SetCursorPosition(countOfColumns + 7, 0);
        Console.WriteLine("Ваш счёт: 0");
        Console.SetCursorPosition(1, 1);
    }

    public void PrintScore(int countOfColumns)
    {
        Console.SetCursorPosition(countOfColumns + 17, 0);
        for (int i = 0; i < currentScore.ToString().Length; ++i)
        {
            Console.Write(" \b");
        }
        Console.Write($"{currentScore}");
    }
}
