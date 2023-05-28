namespace Transform;

/// <summary>
/// Class of sorting, including Bubble sort.
/// </summary>
public static class Sorting
{
    /// <summary>
    /// Main method of sorting
    /// </summary>
    /// <param name="bytes">Array of bytes, that we want to sort</param>
    /// <returns>Sorted array of bytes</returns>
    public static int BubbleSuffixSort(byte[] bytes, int[] arrayOfIndices)
    {
        if (bytes == null)
        {
            throw new ArgumentNullException(nameof(bytes), "Array of bytes mustn't be null");
        }
        if (arrayOfIndices == null)
        {
            throw new ArgumentNullException (nameof(arrayOfIndices), "Array of bytes mustn't be null");
        }
        for (int i = 0; i < bytes.Length; ++i)
        {
            arrayOfIndices[i] = i;
        }
        int lastPosition = 0;
        for (int i = 1; i < bytes.Length; ++i)
        {
            for (int j = i; j >= 1 && ByteComparison(bytes, arrayOfIndices[j - 1], arrayOfIndices[j]) == -1; --j)
            {
                if (j == lastPosition || j - 1 == lastPosition)
                {
                    lastPosition = j == lastPosition ? (j - 1) : j;
                }
                (arrayOfIndices[j], arrayOfIndices[j - 1]) = (arrayOfIndices[j - 1], arrayOfIndices[j]);
            }
        }
        return lastPosition;
    }

    /// <summary>
    /// Method, that compare two suffix is made up of bytes.
    /// </summary>
    /// <param name="bytes">Array of bytes</param>
    /// <param name="firstIndex">Index of first suffix</param>
    /// <param name="secondIndex">Index of second suffix</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">Array of bytes was null</exception>
    /// <exception cref="ArgumentOutOfRangeException">One of indices was less than 0 or more than length of array - 1</exception>
    private static int ByteComparison(byte[] bytes, int firstIndex, int secondIndex)
    {
        if (bytes == null)
        {
            throw new ArgumentNullException(nameof(bytes), "Array of bytes mustn't be null");
        }
        if (firstIndex < 0 || firstIndex > bytes.Length - 1)
        {
            throw new ArgumentOutOfRangeException(nameof(firstIndex), "Index must be more than 0 and less then length of array - 1");
        }
        if (secondIndex < 0 || secondIndex > bytes.Length - 1)
        {
            throw new ArgumentOutOfRangeException(nameof(secondIndex), "Index must be more than 0 and less then length of array - 1");
        }
        int maxIndex = Math.Max(firstIndex, secondIndex);
        for (int i = 0; i < bytes.Length - maxIndex; ++i)
        {
            if (bytes[firstIndex + i] < bytes[secondIndex + i])
            {
                return -1;
            }
            else if (bytes[firstIndex + i] > bytes[secondIndex + i])
            {
                return 1;
            }
        }
        if (firstIndex > secondIndex)
        {
            return -1;
        } 
        else if (secondIndex > firstIndex)
        {
            return 1;
        }
        return 0;
    }
}