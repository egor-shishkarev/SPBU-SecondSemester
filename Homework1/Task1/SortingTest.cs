using BubbleSort;

public static class SortingTest
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
        var test1 = new[] { 5, 4, 3, 2, 1 };
        var test2 = new[] { int.MinValue, int.MaxValue, 0 };
        var test3 = new int[1000];
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