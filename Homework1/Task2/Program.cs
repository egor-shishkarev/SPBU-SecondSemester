namespace Task2;

using System.Text;

internal class MainProgram
{
    static void Main(string[] args)
    {
        if (args is null)
        {
            throw new ArgumentNullException(nameof(args));
        }
        if (!BWTTest.Test())
        {
            Console.WriteLine("Тесты не были пройдены!");
            return;
        }
        Console.WriteLine("Тесты успешно пройдены!");
        Console.Write("Введите строку, которую хотите получить преобразованием Барроуза-Уилера => ");
        string stringToConvert = Console.ReadLine();
        if (string.IsNullOrEmpty(stringToConvert))
        {
            Console.WriteLine("Строка не была введена");
            return;
        }
        (StringBuilder BWTString, int lastPosition) = BWT.DirectBWT(stringToConvert);
        Console.WriteLine(BWTString.ToString() + $" Позиция конца строки - {lastPosition}");
        Console.WriteLine("Исходная строка - " + BWT.ReverceBWT(BWTString, lastPosition).ToString());
    }
}

class Sorting
{
    public static bool BubbleSuffixSort(int[] array, string stringToConvert)
    {
        if (array == null)
        {
            return false;
        }
        for (int i = array.Length - 1; i >= 0; --i)
        {
            for (int j = i; j >= 0; --j)
            {
                if (String.Compare(stringToConvert[array[i]..], stringToConvert[array[j]..]) < 0)
                {
                    (array[j], array[i]) = (array[i], array[j]);
                }
            }
        }
        return true;
    }

}

class BWT
{
    public static (StringBuilder BWTString, int lastPosition) DirectBWT(string stringToConvert)
    {
        if (stringToConvert == null)
        {
            return (null, 0);
        }
        stringToConvert += "\0";
        int[] arrayOfIndex = new int[stringToConvert.Length];
        for (int i = 0; i < stringToConvert.Length; ++i)
        {
            arrayOfIndex[i] = i;
        }
        Sorting.BubbleSuffixSort(arrayOfIndex, stringToConvert);
        var BWTString = new StringBuilder(stringToConvert.Length);
        for (int i = 0; i < stringToConvert.Length; ++i)
        {
            BWTString.Append(stringToConvert[(stringToConvert.Length + arrayOfIndex[i] - 1) % stringToConvert.Length]);
        }
        int lastPosition = BWTString.ToString().IndexOf('\0');
        BWTString = BWTString.Replace("\0", "");
        return (BWTString, lastPosition);
    }
    public static StringBuilder ReverceBWT(StringBuilder BWTString, int lastPosition)
    {
        StringBuilder BWTStringWithAdditionalSymbol = new(BWTString.Length + 1);
        for (int i = 0; i < BWTString.Length; ++i)
        {
            BWTStringWithAdditionalSymbol.Append(BWTString[i]);
        }
        BWTStringWithAdditionalSymbol.Insert(lastPosition, "\0");
        char[] arrayOfChars = BWTStringWithAdditionalSymbol.ToString().ToCharArray();
        int[] arrayOfIndex = new int[arrayOfChars.Length];
        for (int i = 0; i < arrayOfChars.Length; ++i)
        {
            arrayOfIndex[i] = i;
        }
        for (int count = 0; count < arrayOfChars.Length; ++count)
        {
            for (int j = 1; j < arrayOfChars.Length; ++j)
            {
                int i = j - 1;
                if (arrayOfChars[i] > arrayOfChars[j])
                {
                    (arrayOfIndex[j], arrayOfIndex[i]) = (arrayOfIndex[i], arrayOfIndex[j]);
                    (arrayOfChars[j], arrayOfChars[i]) = (arrayOfChars[i], arrayOfChars[j]);
                }
            }
        }
        int currentIndex = 0;
        StringBuilder reverseBWTString = new(arrayOfChars.Length);
        for (int i = 0; i < arrayOfChars.Length; ++i)
        {
            reverseBWTString.Append(arrayOfChars[currentIndex]);
            currentIndex = arrayOfIndex[currentIndex];
        }
        reverseBWTString.Replace("\0", "");
        return reverseBWTString;
    }
}

class BWTTest
{
    public static bool Test()
    {
        string test1 = "banana";
        (StringBuilder BWTString1, int lastPosition1) = BWT.DirectBWT(test1);
        string answer1 = BWT.ReverceBWT(BWTString1, lastPosition1).ToString();
        string test2 = "SIX.MIXED.PIXIES.SIFT.SIXTY.PIXIE.DUST.BOXES";
        (StringBuilder BWTString2, int lastPosition2) = BWT.DirectBWT(test2);
        string answer2 = BWT.ReverceBWT(BWTString2, lastPosition2).ToString();
        string test3 = "ехал грека через реку видит грека в реке рак сунул грека руку в реку рак за руку грека цап";
        (StringBuilder BWTString3, int lastPosition3) = BWT.DirectBWT(test3);
        string answer3 = BWT.ReverceBWT(BWTString3, lastPosition3).ToString();
        return (String.Compare(test1, answer1) == 0) && (String.Compare(test2, answer2) == 0) && (String.Compare(test3, answer3) == 0);
    }
}
