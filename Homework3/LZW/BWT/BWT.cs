namespace Transform;

/// <summary>
/// Class of Burrows-Wheeler transform is made up of Direct and Reverse transformation.
/// </summary>
public static class BWT
{
    /// <summary>
    /// Direct transformation of byte array.
    /// </summary>
    /// <param name="bytes">Array, to which we want to apply the Burrows Wheeler transform. </param>
    /// <returns>Array of converted bytes and last position - need for reverse BWT.</returns>
    /// <exception cref="ArgumentNullException">Array of bytes was null.</exception>
    public static (byte[] BWTBytes, int lastPosition) DirectBWT(byte[] bytes)
    {
        if (bytes == null)
        {
            throw new ArgumentNullException(nameof(bytes), "Array of bytes mustn't be null!");
        }
        int[] arrayOfIndices = new int[bytes.Length];
        for (int i = 0; i < bytes.Length; ++i)
        {
            arrayOfIndices[i] = i;
        }
        int lastPosition = Sorting.BubbleSuffixSort(bytes, arrayOfIndices);
        var BWTBytes = new List<byte>();
        for (int i = 0; i < bytes.Length; ++i)
        {
            BWTBytes.Add(bytes[(bytes.Length + arrayOfIndices[i] - 1) % bytes.Length]);
        }
        return (BWTBytes.ToArray(), lastPosition);
    }

    public static byte[] ReverseBWT(byte[] BWTBytes, int lastPosition)
    {
        if (BWTBytes == null || lastPosition > BWTBytes.Length || lastPosition < 0 || BWTBytes == Array.Empty<byte>())
        {
            throw new ArgumentNullException(nameof(BWTBytes), "Array of bytes to which we apply BWT mustn't be null!");
        }
        var arrayOfIndex = new int[BWTBytes.Length];
        for (int i = 0; i < BWTBytes.Length; ++i)
        {
            arrayOfIndex[i] = i;
        }
        for (int count = 0; count < BWTBytes.Length; ++count)
        {
            for (int j = 1; j < BWTBytes.Length; ++j)
            {
                int i = j - 1;
                if (BWTBytes[i] > BWTBytes[j])
                {
                    (arrayOfIndex[j], arrayOfIndex[i]) = (arrayOfIndex[i], arrayOfIndex[j]);
                    (BWTBytes[j], BWTBytes[i]) = (BWTBytes[i], BWTBytes[j]);
                }
            }
        }
        int currentIndex = 0;
        var reverseBWTBytes = new List<byte>();
        for (int i = 0; i < BWTBytes.Length; ++i)
        {
            reverseBWTBytes.Add(BWTBytes[currentIndex]);
            currentIndex = arrayOfIndex[currentIndex];
        }
        return reverseBWTBytes.ToArray();
    }
}