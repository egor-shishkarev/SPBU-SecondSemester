namespace BubbleSort;

public static class Sorting
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
