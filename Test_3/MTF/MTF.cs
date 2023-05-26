namespace MTF;

/// <summary>
/// Class of Move-To-Front encoding.
/// </summary>
public class MTFEncoding
{
    /// <summary>
    /// Main method of encoding of English alphabet strings by the Move-To-Front algorithm.
    /// </summary>
    /// <param name="inputString">String of english alphabet, which we want to encode.</param>
    /// <returns>Sequence of ints.</returns>
    /// <exception cref="ArgumentNullException">Input string was null or empty.</exception>
    /// <exception cref="ArgumentException">Nonexpected symbol in input string.</exception>
    static public int[] Encode(string inputString)
    {
        if (string.IsNullOrEmpty(inputString))
        {
            throw new ArgumentNullException(nameof(inputString));
        }

        var alphabet = CreateAlphabet();
        var MTFSequence = new List<int>();

        for (int i = 0; i < inputString.Length; ++i)
        {
            if (inputString[i] < 32 || inputString[i] > 126)
            {
                throw new ArgumentException("Not supported symbol!");
            }
            MTFSequence.Add(alphabet.IndexOf(inputString[i]));
            alphabet.Remove(inputString[i]);
            alphabet.Insert(0, inputString[i]);
        }

        return MTFSequence.ToArray();
    }


    /// <summary>
    /// Auxiliary method to create alphabet. The first characters are lowercase letters, then uppercase, then numbers and other characters.
    /// </summary>
    /// <returns>List of chars that are in the alphabet.</returns>
    static private List<char> CreateAlphabet()
    {
        var alphabet = new List<char>();
        for (int i = 97; i <= 122; ++i)
        {
            alphabet.Add((char)i);
        }
        for (int i = 65; i <= 90; ++i)
        {
            alphabet.Add((char)i);
        }
        for (int i = 32; i <= 64; ++i)
        {
            alphabet.Add((char)i);
        }
        for (int i = 91; i <= 96; ++i)
        {
            alphabet.Add((char)i);
        }
        for (int i = 123; i <= 126; ++i)
        {
            alphabet.Add((char)i);
        }
        return alphabet;
    }
}