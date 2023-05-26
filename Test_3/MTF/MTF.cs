namespace MTF;

public class MTFEncoding
{
    static public int[] Encode(string inputString)
    {
        if (string.IsNullOrEmpty(inputString))
        {
            throw new ArgumentNullException("Input string was null or empty!");
        }

        var alphabet = new List<char>();
        var MTFSequence = new List<int>();

        for (int i = 97; i <= 122; ++i)
        {
            alphabet.Add((char)i);
        }

        for (int i = 0; i < inputString.Length; ++i)
        {
            if ((int)inputString[i] < 0 || (int)inputString[i] > 128)
            {
                throw new ArgumentException("Not supported symbol!");
            }
            MTFSequence.Add(alphabet.IndexOf(inputString[i]));
            alphabet.Remove(inputString[i]);
            alphabet.Insert(0, inputString[i]);
        }

        return MTFSequence.ToArray();
    }
}

/*А вот контрольная: Реализовать кодирование алгоритмом Move-To-Front строк английского алфавита.
 * На вход программе подаётся строка, на выход — закодированная MTF последовательность чисел. 
 * Например, по строке banana должна выдаваться кодовая последовательность [1,1,13,1,1,1]. Обязательны комментарии и юнит-тесты.*/