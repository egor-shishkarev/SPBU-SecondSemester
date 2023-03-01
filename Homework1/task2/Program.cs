using System;

namespace task2
{
    internal class Program
    {
        public static bool BubbleSort(int[] array, string stringToConvert)
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
            int[] arrayOfIndex = new int[stringToConvert.Length];
            for (int i = 0; i < stringToConvert.Length; ++i)
            {
                arrayOfIndex[i] = i;
            }
            BubbleSort(arrayOfIndex, stringToConvert);
            var BWTString = new StringBuilder(stringToConvert.Length);
            for (int i = 0; i < stringToConvert.Length; ++i)
            {
                BWTString.Append(stringToConvert[(stringToConvert.Length + arrayOfIndex[i] - 1) % stringToConvert.Length]);
            }
            int lastPosition = BWTString.ToString().IndexOf('\0') - 1;
            BWTString = BWTString.Replace("\0", "");
            return (BWTString, lastPosition);
        }
        public static StringBuilder ReverceBWT(StringBuilder BWTString, int lastPosition)
        {
            StringBuilder originalString = new StringBuilder(BWTString.Length + 1);
            for (int i = 0; i < BWTString.Length; ++i)
            {
                originalString.Append(BWTString[i]);
            }
            originalString.Insert(lastPosition, "\0");

            return originalString;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите строку, которую хотите получить преобразованием Барроуза-Уилера => ");
            string stringToConvert = Console.ReadLine() + "\0";
            (StringBuilder BWTString, int lastPosition) = (DirectBWT(stringToConvert).BWTString, DirectBWT(stringToConvert).lastPosition);
            Console.WriteLine(BWTString.ToString() + $" Позиция конца строки - {lastPosition}");
            Console.WriteLine(BWTString.Length);
            Console.WriteLine(ReverceBWT(BWTString, lastPosition));
            Console.ReadLine();
        }
    }
}
