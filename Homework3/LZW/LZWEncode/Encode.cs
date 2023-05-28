namespace LZW;

using TrieClass;

/// <summary>
/// Class of methods, which need to encode ".zipped" files.
/// </summary>
public static class Encode
{
    /// <summary>
    /// Main method to encode file.
    /// </summary>
    /// <param name="binaryFile">Array of bytes, which we want to encode.</param>
    /// <returns>Encoded array of bytes.</returns>
    /// <exception cref="ArgumentNullException">Binary file mustn't be null!</exception>
    public static byte[] EncodeFile(byte[] binaryFile)
    {
        if (binaryFile == null)
        {
            throw new ArgumentNullException(nameof(binaryFile), "Binary file mustn't be null!");
        }
        var trie = new Trie();
        int currentSizeOfTrie = 256;
        for (int i = 0; i < currentSizeOfTrie; ++i)
        {
            var newByte = new List<byte> { (byte)i };
            trie.Add(newByte, i);
        }
        int currentBitsForSymbol = 8;
        var previousSymbol = new List<byte>();
        var sumOfSymbols = new List<byte>();
        var currentSymbol = new List<byte>();
        var LZWBites = new List<List<bool>>();
        for (int i = 0; i < binaryFile.Length; ++i)
        {
            currentSymbol.Add(binaryFile[i]);
            foreach (var item in previousSymbol)
            {
                sumOfSymbols.Add(item);
            }
            foreach (var item in currentSymbol)
            {
                sumOfSymbols.Add(item);
            }
            if (trie.Contains(sumOfSymbols))
            {
                previousSymbol.Clear();
                foreach (var item in sumOfSymbols)
                {
                    previousSymbol.Add(item);
                }
            }
            else
            {
                trie.Add(sumOfSymbols, trie.Size);
                LZWBites.Add(IntToBits(trie.GetValue(previousSymbol), currentBitsForSymbol));
                previousSymbol.Clear();
                foreach (var item in currentSymbol)
                {
                    previousSymbol.Add(item);
                }
                if (trie.Size >= currentSizeOfTrie)
                {
                    currentSizeOfTrie *= 2;
                    ++currentBitsForSymbol;
                }
            }
            if (i == binaryFile.Length - 1)
            {
                LZWBites.Add(IntToBits(trie.GetValue(previousSymbol), currentBitsForSymbol));
            }
            currentSymbol.Clear();
            sumOfSymbols.Clear();
        }
        for (int i = 0; i < LZWBites.Count; ++i)
        {
            LZWBites[i] = ResizeBits(LZWBites[i], currentBitsForSymbol);
        }
        var newLZWBites = new List<bool>();
        foreach (var item in LZWBites)
        {
            newLZWBites.AddRange(item);
        }
        while (newLZWBites.Count % 8 != 0)
        {
            newLZWBites.Insert(0, false);
        }
        var newLZWBytes = new List<byte>();
        int counterForBites = 0;
        for (int i = 0; i < newLZWBites.Count / 8; ++i)
        {
            var oneByte = new List<bool>();
            while (counterForBites != 8)
            {
                oneByte.Add(newLZWBites[i * 8 + counterForBites]);
                ++counterForBites;
            }
            counterForBites = 0;
            newLZWBytes.Add(BoolToByte(oneByte));
        }
        newLZWBytes.Insert(0, (byte)currentBitsForSymbol);
        return newLZWBytes.ToArray();
    }

    /// <summary>
    /// Method, that transform array of bool elements to byte element.
    /// </summary>
    /// <param name="oneByte">Array of bool elements</param>
    /// <returns>One byte</returns>
    private static byte BoolToByte(List<bool> oneByte)
    {
        int currentByte = 0;
        for (int i = oneByte.Count - 1; i >= 0; --i)
        {
            currentByte += oneByte[i] == true ? (int)Math.Pow(2, 7 - i) : 0;
        }
        return (byte)currentByte;
    }

    /// <summary>
    /// Method, that transform integer number to array of bool elements.
    /// </summary>
    /// <param name="element">Number, which we want to transform.</param>
    /// <param name="currentBitsForSymbol">Power of two, or length of bool array, which we get.</param>
    /// <returns>List of bool elements.</returns>
    private static List<bool> IntToBits(int element, int currentBitsForSymbol) 
    {
        
        var bits = new List<bool>();
        int mask = (int)Math.Pow(2, currentBitsForSymbol - 1);
        for (int i = 0; i < currentBitsForSymbol; ++i)
        {
            bits.Add((element & mask) == (int)Math.Pow(2, currentBitsForSymbol - i - 1));
            mask >>= 1;
        }
        return bits;
    }

    /// <summary>
    /// Method, that add additional bool element to list.
    /// </summary>
    /// <param name="bites">List of bool elements, which we want to increase.</param>
    /// <param name="currentBitsForSymbol">Power of two, or length of bool list, which we get.</param>
    /// <returns>List of bool elements.</returns>
    private static List<bool> ResizeBits(List<bool> bites, int currentBitsForSymbol)
    {
        while (bites.Count != currentBitsForSymbol)
        {
            bites.Insert(0, false);
        }
        return bites;
    }
}

