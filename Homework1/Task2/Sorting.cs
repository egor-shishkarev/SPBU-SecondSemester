namespace Transform;

public static class Sorting
{
    public static (int[], bool) BubbleSuffixSort(string stringToConvert)
    {
        if (stringToConvert == null)
        {
            return (Array.Empty<int>(), false);
        }
        var arrayOfIndex = new int[stringToConvert.Length];
        for (int i = 0; i < stringToConvert.Length; ++i)
        {
            arrayOfIndex[i] = i;
        }
        for (int i = arrayOfIndex.Length - 1; i >= 0; --i)
        {
            for (int j = i - 1; j >= 0; --j)
            {
                if (string.CompareOrdinal(stringToConvert[arrayOfIndex[i]..], stringToConvert[arrayOfIndex[j]..]) < 0)
                {
                    (arrayOfIndex[j], arrayOfIndex[i]) = (arrayOfIndex[i], arrayOfIndex[j]);
                }
            }
        }
        return (arrayOfIndex, true);
    }
}
