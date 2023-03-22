namespace Transform;

public static class Sorting
{
    public static (byte[], bool) BubbleSuffixSort(byte[] bytes)
    {
        if (bytes == null)
        {
            return (Array.Empty<byte>(), false);
        }
        var arrayOfIndex = new int[bytes.Length];
        for (int i = 0; i < bytes.Length; ++i)
        {
            arrayOfIndex[i] = i;
        }
        for (int i = arrayOfIndex.Length - 1; i >= 0; --i)
        {
            for (int j = i - 1; j >= 0; --j)
            {
                if (bytes[j] < bytes[i])
                {
                    (arrayOfIndex[j], arrayOfIndex[i]) = (arrayOfIndex[i], arrayOfIndex[j]);
                }
            }
        }
        return (bytes, true);
    }
}