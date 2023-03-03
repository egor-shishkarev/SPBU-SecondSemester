namespace Task1;

class MainProgram
{
    static void Main(string[] args)
    {
        if (args is null)
        {
            throw new ArgumentNullException(nameof(args));
        }
        if (!SortingTest.Test())
        {
            Console.WriteLine("Тесты не пройдены!");
            return;
        }
        Console.WriteLine("Тесты успешно пройдены!");
        Console.WriteLine("Введите число элементов массива => ");
        int numberOfElements;
        while (!int.TryParse(Console.ReadLine(), out numberOfElements) || numberOfElements <= 0 || numberOfElements > 50000000)
        {
            Console.WriteLine("Было введено не число или слишком большое/маленькое число, повторите ввод => ");
        }
        var array = new int[numberOfElements];
        Console.WriteLine("Вводите числа через Enter: ");
        for (int i = 0; i < numberOfElements; ++i)
        {
            while (!int.TryParse(Console.ReadLine(), out array[i]))
            {
                Console.WriteLine("Было введено не число, повторите ввод => ");
            }
        }
        if (!Sorting.BubbleSort(array))
        {
            Console.WriteLine("Произошла ошибка при сортировке массива!");
            return;
        }
        Console.WriteLine("Отсортированный массив: ");
        for (int i = 0; i < array.Length; ++i)
        {
            Console.Write(array[i].ToString() + " ");
        }
    }
}

class Sorting
{
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
                    (array[j], array[i]) = (array[i], array[j]);
                }
            }
        }
        return true;
    }
}

class SortingTest
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
        int[] test3 = new int[1000];
        for (int i = 0; i < 1000; ++i)
        {
            test3[i] = 1000 - i;
        }
        bool firstAnswer = Sorting.BubbleSort(test1);
        bool secondAnswer = Sorting.BubbleSort(test2);
        bool thirdAnswer = Sorting.BubbleSort(test3);
        bool firstCheck = VerifyTest(test1);
        bool secondCheck = VerifyTest(test2);
        bool thirdCheck = VerifyTest(test3);
        return firstAnswer && secondAnswer && thirdAnswer && firstCheck && secondCheck && thirdCheck;
    }
}
