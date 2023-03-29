namespace LZW;

/// <summary>
/// Class of methods, which need to decode ".zipped" files.
/// </summary>
public static class Decode
{
    /// <summary>
    /// Main method to decode files.
    /// </summary>
    /// <param name="binaryFile">Array of bytes, which we want to decode.</param>
    /// <returns>Original array of bytes.</returns>
    /// <exception cref="ArgumentNullException">Array of bytes mustn't be null!</exception>
    public static byte[] DecodeFile(byte[] binaryFile)
    {
        if (binaryFile == null)
        {
            throw new ArgumentNullException(nameof(binaryFile), "Array of bytes mustn't be null!");
        }
        var binaryFileList = binaryFile.ToList();
        int currentSizeForSymbol = binaryFileList[0];
        binaryFileList.RemoveAt(0);

        var dictionary = new Dictionary<int, List<byte>>();
        for (int i = 0; i < 256; ++i)
        {
            var element = new List<byte>() { (byte)i };
            dictionary.Add(i, element);
        }

        var allSymbols = ByteArrayToBoolArray(binaryFileList.ToArray(), currentSizeForSymbol);
        var allSymbolsInt = new List<int>();
        foreach (var element in allSymbols)
        {
            allSymbolsInt.Add(BoolToInt(element));
        }
        var currentSymbol = allSymbolsInt[0];
        var previousSymbol = allSymbolsInt[0];
        var result = new List<byte>() { (byte)currentSymbol };
        int dictionarySize = 256;
        for (int i = 1; i < allSymbolsInt.Count; ++i)
        {
            currentSymbol = allSymbolsInt[i];
            var sumOfSymbols = new List<byte>();
            foreach (var element in dictionary[previousSymbol])
            {
                sumOfSymbols.Add(element);
            }
            if (dictionary.ContainsKey(currentSymbol))
            {
                foreach (var item in dictionary[currentSymbol])
                {
                    result.Add(item);
                }
                sumOfSymbols.Add(dictionary[currentSymbol][0]);
                dictionary.Add(dictionarySize, sumOfSymbols);
                ++dictionarySize;
            }
            else 
            {
                var additionalList = new List<byte>();
                foreach (var item in dictionary[previousSymbol])
                {
                    additionalList.Add(item);
                }
                additionalList.Add(dictionary[previousSymbol][0]);
                dictionary.Add(currentSymbol, additionalList);
                ++dictionarySize;
                foreach (var item in dictionary[currentSymbol])
                {
                    result.Add(item);
                }
            }
            previousSymbol = currentSymbol;
        }
        return result.ToArray();
    }

    /// <summary>
    /// Method that transform byte array to bool array. For example - 67 => { 0, 1, 0, 0, 0, 0, 1, 1 }
    /// </summary>
    /// <param name="byteArray">Array of bytes, that we want to transform.</param>
    /// <param name="currentBitsForSymbol">Length of bool array or power of two.</param>
    /// <returns>List of list of bool.</returns>
    private static List<List<bool>> ByteArrayToBoolArray(byte[] byteArray, int currentBitsForSymbol)
    {
        var ListOfAllBites = new List<bool>();
        foreach (var item in byteArray)
        {
            ListOfAllBites.AddRange(ByteToBool(item));
        }
        var listOfSymbols = new List<List<bool>>();
        for (int i = ListOfAllBites.Count / currentBitsForSymbol - 1; i >= 0; --i)
        {
            int counterOfBits = 0;
            var oneElement = new List<bool>();
            while (counterOfBits != currentBitsForSymbol)
            {
                oneElement.Add(ListOfAllBites[ListOfAllBites.Count - (i + 1) * currentBitsForSymbol + counterOfBits]);
                ++counterOfBits;
            }
            listOfSymbols.Add(oneElement);
        }
        return listOfSymbols;
    }

    /// <summary>
    /// Method, that trasform byte array to bool array.
    /// </summary>
    /// <param name="oneByte">Byte, that we want to represent in bool array</param>
    /// <returns>List of bool elements - binary representation of a byte.</returns>
    private static List<bool> ByteToBool(byte oneByte)
    {
        var boolList = new List<bool>();
        int mask = (int)Math.Pow(2, 7);
        for (int i = 0; i < 8; ++i)
        {
            boolList.Add((oneByte & mask) == (int)Math.Pow(2, 7 - i));
            mask >>= 1;
        }
        return boolList;
    }

    /// <summary>
    /// Method, that transform list of bool elements to int.
    /// </summary>
    /// <param name="bits">List of bool values</param>
    /// <returns>Integer number</returns>
    private static int BoolToInt(List<bool> bits)
    {
        int result = 0;
        for (int i = 0; i < bits.Count; ++i)
        {
            result += bits[i] == true ? (int)Math.Pow(2, bits.Count - i - 1) : 0;
        }
        return result;
    }
}