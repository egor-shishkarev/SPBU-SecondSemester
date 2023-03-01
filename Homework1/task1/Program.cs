using System;

namespace task1
{
    class Program
    {
        public static bool VerifyTest(int[] array)
        {
            if (array == null)
            {
                return false;
            }
            for (int i = 0; i < array.Length - 1; ++i)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool Test()
        {
            int[] test1 = { 5, 4, 3, 2, 1 };
            int[] test2 = { int.MinValue, int.MaxValue, 0 };
            int[] test3 = null;
            int[] test4 = new int[1000];
            for (int i = 0; i < 1000; ++i)
            {
                test4[i] = 1000 - i;
            }
            bool firstAnswer = BubbleSort(test1);
            bool secondAnswer = BubbleSort(test2);
            bool thirdAnswer = !BubbleSort(test3);
            bool fourthAnswer = BubbleSort(test4);
            bool firstCheck = VerifyTest(test1);
            bool secondCheck = VerifyTest(test2);
            bool thirdCheck = !VerifyTest(test3);
            bool fourthCheck = VerifyTest(test4);
            return firstAnswer && secondAnswer && thirdAnswer && fourthAnswer && firstCheck && secondCheck && thirdCheck && fourthCheck;  
        }
        public static bool BubbleSort(int[] array)
        {
            if (array == null)
            {
                return false;
            }
            for (int i = array.Length - 1; i >= 0; --i)
            {
                for (int j = i; j >= 0; --j)
                {
                    if (array[i] < array[j])
                    {
                        int buffer = array[i];
                        array[i] = array[j];
                        array[j] = buffer;
                    }
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            if (!Test())
            {
                Console.WriteLine("Тесты не пройдены!");
                return;
            } 
            Console.WriteLine("Тесты успешно пройдены!");
            Console.WriteLine("Введите число элементов массива => ");
            int numberOfElements = 0;
            while (!int.TryParse(Console.ReadLine(), out numberOfElements))
            {
                Console.WriteLine("Было введено не число, повторите ввод => ");
            }
            while (numberOfElements > 500000000)
            {
                Console.WriteLine("Слишком большое количество элементов массива, повторите ввод с меньшим количеством!");
                int.TryParse(Console.ReadLine(), out numberOfElements);
            }
            int[] array = new int[numberOfElements];
            Console.WriteLine("Вводите числа через Enter: ");
            for (int i = 0; i < numberOfElements; ++i)
            {
                while (!int.TryParse(Console.ReadLine(), out array[i]))
                {
                    Console.WriteLine("Было введено не число, повторите ввод => ");
                }
            }
            if (!BubbleSort(array))
            {
                Console.WriteLine("Произошла ошибка при сортировке массива!");
                return;
            }
            Console.WriteLine("Отсортированный массив: ");
            for (int i = 0; i < array.Length; ++i)
            {
                Console.Write(array[i].ToString() + " ");
            }
            Console.WriteLine("\nНажмите Enter для выхода");
            Console.ReadLine();
        }
    }
}
