namespace LZW;

public static class Decode
{
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
        //Console.WriteLine("DecodeDecodeDecodeDecodeDecodeDecodeDecodeDecodeDecode");
        //foreach ( var symbol in allSymbols )
        //{
        //    foreach ( var item in symbol ) 
        //    {
        //        Console.WriteLine(item == true ? 1 : 0);
        //    }
        //    Console.WriteLine("--------");
        //}
        var currentSymbol = allSymbolsInt[0];
        var previousSymbol = allSymbolsInt[0];
        var result = new List<byte>() { (byte)currentSymbol };
        int dictionarySize = 256;
        //foreach (var symbol in allSymbolsInt)
        //{
        //    Console.WriteLine(symbol);
        //}
        // In this code is mistake - need to review!!!
        for (int i = 1; i < allSymbolsInt.Count; ++i)
        {
            currentSymbol = allSymbolsInt[i];
            var sumOfSymbols = new List<byte>();
            foreach (var element in dictionary[previousSymbol])
            {
                sumOfSymbols.Add(element);
            }
            //if (!dictionary.ContainsKey(currentSymbol))
            //{
            //    var additionalList = new List<byte>();
            //    foreach (var item in dictionary[previousSymbol])
            //    {
            //        additionalList.Add(item);
            //    }
            //    additionalList.Add(dictionary[previousSymbol][0]);
            //    dictionary.Add(currentSymbol, additionalList);
            //    ++dictionarySize;
            //}
            //sumOfSymbols.Add(dictionary[currentSymbol][0]);

            //bool flagOfMoreThanTwoSymbols = dictionary[currentSymbol].Count > 1;
            //for (int j = 0; j < dictionary[currentSymbol].Count; ++j)
            //{
            //    if (!(flagOfMoreThanTwoSymbols && (j == dictionary[currentSymbol].Count - 1)))
            //    {
            //        sumOfSymbols.Add(dictionary[currentSymbol][0]);
            //    }
            //}
            //foreach (var element in dictionary[currentSymbol])
            //{
            //    sumOfSymbols.Add(element);
            //}
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
                //sumOfSymbols.Add(dictionary[currentSymbol][0]);
            }
            //if (i == allSymbolsInt.Count - 1)
            //{
            //    foreach (var item in dictionary[previousSymbol])
            //    {
            //        result.Add(item);
            //    }
            //}
            previousSymbol = currentSymbol;
        }
        return result.ToArray();
    }

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