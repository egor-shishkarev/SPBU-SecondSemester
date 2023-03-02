using System;
using System.Text;

namespace task2
{
    internal class Program
    {
        public static bool Test()
        {
            string test1 = "banana";
            (StringBuilder BWTString1, int lastPosition1) = DirectBWT(test1);
            string answer1 = ReverceBWT(BWTString1, lastPosition1).ToString();
            string test2 = "SIX.MIXED.PIXIES.SIFT.SIXTY.PIXIE.DUST.BOXES";
            (StringBuilder BWTString2, int lastPosition2) = DirectBWT(test2);
            string answer2 = ReverceBWT(BWTString2, lastPosition2).ToString();
            string test3 = "ехал грека через реку видит грека в реке рак сунул грека руку в реку рак за руку грека цап";
            (StringBuilder BWTString3, int lastPosition3) = DirectBWT(test3);
            string answer3 = ReverceBWT(BWTString3, lastPosition3).ToString();
            return (String.Compare(test1, answer1) == 0) && (String.Compare(test2, answer2) == 0) && (String.Compare(test3, answer3) == 0);
        }
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
                    if (String.Compare(stringToConvert.Substring(array[i]), stringToConvert.Substring(array[j])) < 0)
                    {
                        int buffer = array[i];
                        array[i] = array[j];
                        array[j] = buffer;
                    }
                }
            }
            return true;
        }
        public static (StringBuilder BWTString, int lastPosition) DirectBWT(string stringToConvert)
        {
            if (stringToConvert == null)
            {
                return (null, 0);
            }
            stringToConvert = stringToConvert + "\0";
            int[] arrayOfIndex = new int[stringToConvert.Length];
            for (int i = 0; i < stringToConvert.Length; ++i)
            {
                arrayOfIndex[i] = i;
            }
            BubbleSuffixSort(arrayOfIndex, stringToConvert);
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
            StringBuilder BWTStringWithAdditionalSymbol = new StringBuilder(BWTString.Length + 1);
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
                        int bufferOfIndex = arrayOfIndex[i];
                        arrayOfIndex[i] = arrayOfIndex[j];
                        arrayOfIndex[j] = bufferOfIndex;
                        char bufferOfChar = arrayOfChars[i];
                        arrayOfChars[i] = arrayOfChars[j];
                        arrayOfChars[j] = bufferOfChar;
                    }
                }
            }
            int currentIndex = 0;
            StringBuilder reverseBWTString= new StringBuilder(arrayOfChars.Length);
            for (int i = 0; i < arrayOfChars.Length; ++i)
            {
                reverseBWTString.Append(arrayOfChars[currentIndex]);
                currentIndex = arrayOfIndex[currentIndex];
            }
            reverseBWTString.Replace("\0", "");
            return reverseBWTString;
        }
        static void Main(string[] args)
        {
            if (!Test())
            {
                Console.WriteLine("Тесты не были пройдены!");
                return;
            }
            Console.WriteLine("Тесты успешно пройдены!");
            Console.Write("Введите строку, которую хотите получить преобразованием Барроуза-Уилера => ");
            string stringToConvert = Console.ReadLine();
            (StringBuilder BWTString, int lastPosition) = DirectBWT(stringToConvert);
            Console.WriteLine(BWTString.ToString() + $" Позиция конца строки - {lastPosition}");
            Console.WriteLine("Исходная строка - " + ReverceBWT(BWTString, lastPosition).ToString());
            Console.ReadLine();
        }
    }
}
