namespace LZW;

using TrieClass;
public static class Encode
{
    public static byte[] EncodeFile(byte[] binaryFile)
    {
        //Console.WriteLine("NormalFile");
        //foreach (byte b in binaryFile)
        //{
        //    Console.WriteLine(b);
        //}
        if (binaryFile == null)
        {
            throw new ArgumentNullException(nameof(binaryFile), "Binary file mustn't be null!");
        }
        var trie = new Trie();
        for (int i = 0; i < 256; ++i)
        {
            var newByte = new List<byte> { (byte)i };
            trie.Add(newByte, i);
        }
        int currentSizeOfTrie = 256;
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
            //Console.Write("P - ");
            //WriteBytes(previousSymbol);
            //Console.Write("C - ");
            //WriteBytes(currentSymbol);
            //Console.Write("P + C - ");
            //WriteBytes(sumOfSymbols);
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
            //item.AddRange(newLZWBites);
            newLZWBites.AddRange(item);
        }
        //Console.WriteLine("___________________________");
        //foreach (var item in LZWBites)
        //{
        //    foreach (var subItem in item)
        //    {
        //        Console.WriteLine(subItem == true ? 1 : 0);
        //    }
        //    Console.WriteLine("----");
        //}
        //Console.WriteLine("___________________________");
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
        Console.WriteLine($"Коэффициент сжатия - {binaryFile.Length / (float)newLZWBytes.Count}");
        //foreach (var item in newLZWBytes)
        //{
        //    Console.WriteLine(item);
        //}
        return newLZWBytes.ToArray();
    }

    private static byte BoolToByte(List<bool> oneByte)
    {
        int currentByte = 0;
        for (int i = oneByte.Count - 1; i >= 0; --i)
        {
            currentByte += oneByte[i] == true ? (int)Math.Pow(2, 7 - i) : 0;
        }
        return (byte)currentByte;
    }

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

    private static List<bool> ResizeBits(List<bool> bites, int currentBitsForSymbol)
    {
        while (bites.Count != currentBitsForSymbol)
        {
            bites.Insert(0, false);
        }
        return bites;
    }

    private static List<int> BoolToInt(List<bool> bites)
    {
        var intBites = new List<int>();
        foreach (var bite in bites)
        {
            intBites.Add(bite == true ? 1 : 0);
        }
        return intBites;
    }
    // Extra method for printing byte arrat - need to delete after completing task
    //private static void WriteBytes(List<byte> bytes)
    //{
    //    foreach(var item in bytes)
    //    {
    //        Console.Write(item);
    //    }
    //    Console.WriteLine();
    //}
    // ---------------------------------------------------------------------------
}

