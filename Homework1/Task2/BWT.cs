namespace Transform;

using System.Text;

public static class BWT
{
    public static (StringBuilder BWTString, int lastPosition) DirectBWT(string stringToConvert)
    {
        if (stringToConvert.Contains('\0'))
        {
            return (new StringBuilder(0), 0);
        }
        if (string.IsNullOrEmpty(stringToConvert))
        {
            return (new StringBuilder(0), 0);
        }
        stringToConvert += "\0";
        (var arrayOfIndex, bool notNull) = Sorting.BubbleSuffixSort(stringToConvert);
        if (!notNull)
        {
            return (new StringBuilder(0), 0);
        }
        var BWTString = new StringBuilder(stringToConvert.Length);
        for (int i = 0; i < stringToConvert.Length; ++i)
        {
            BWTString.Append(stringToConvert[(stringToConvert.Length + arrayOfIndex[i] - 1) % stringToConvert.Length]);
        }
        int lastPosition = BWTString.ToString().IndexOf('\0');
        BWTString = BWTString.Replace("\0", "");
        return (BWTString, lastPosition);
    }

    public static StringBuilder ReverseBWT(StringBuilder BWTString, int lastPosition)
    {
        if (BWTString == null || string.IsNullOrEmpty(BWTString.ToString()) || (lastPosition > BWTString.Length || lastPosition < 0))
        {
            return new StringBuilder(0);
        }
        StringBuilder BWTStringWithAdditionalSymbol = new(BWTString.Length + 1);
        for (int i = 0; i < BWTString.Length; ++i)
        {
            BWTStringWithAdditionalSymbol.Append(BWTString[i]);
        }
        BWTStringWithAdditionalSymbol.Insert(lastPosition, '\0');
        var arrayOfChars = BWTStringWithAdditionalSymbol.ToString().ToCharArray();
        var arrayOfIndex = new int[arrayOfChars.Length];
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
                    (arrayOfIndex[j], arrayOfIndex[i]) = (arrayOfIndex[i], arrayOfIndex[j]);
                    (arrayOfChars[j], arrayOfChars[i]) = (arrayOfChars[i], arrayOfChars[j]);
                }
            }
        }
        int currentIndex = 0;
        StringBuilder reverseBWTString = new(arrayOfChars.Length);
        for (int i = 0; i < arrayOfChars.Length; ++i)
        {
            reverseBWTString.Append(arrayOfChars[currentIndex]);
            currentIndex = arrayOfIndex[currentIndex];
        }
        reverseBWTString.Replace("\0", "");
        return reverseBWTString;
    }
}