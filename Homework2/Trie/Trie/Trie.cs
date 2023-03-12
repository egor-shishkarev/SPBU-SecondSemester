namespace Trie;

/// <summary>
/// Class of Trie.
/// </summary>
public class Trie
{
    /// <summary>
    /// Method, that add new string to Trie.
    /// </summary>
    /// <param name="element">String, that we want to add to Trie.</param>
    /// <returns>True - if element not in Trie, False - if element already was in Trie.</returns>
    static public bool Add(string element)
    {
        return true;
    }

    /// <summary>
    /// Method, that check if the string in Trie.
    /// </summary>
    /// <param name="element">String, that we want to check for containing in Trie. </param>
    /// <returns>True - if Trie contain string, False - if Trie doesn't contain string.</returns>
    public static bool Contains(string element) 
    { 
        return true;
    }

    /// <summary>
    /// Method, that remove string from Trie
    /// </summary>
    /// <param name="element"> String, that we want to remove from Trie.</param>
    /// <returns>True - if string contains in Trie, False - if string doesn't contain in Trie</returns>
    public static bool Remove(string element) 
    {  
        return false; 
    }

    /// <summary>
    /// Method, that returns how many string in Trie starts with given prefix.
    /// </summary>
    /// <param name="prefix">Prefix, that we want to count in Trie.</param>
    /// <returns>Number of strings, that contain given prefix</returns>
    public static int HowManyStartsWithPrefix(String prefix)
    {
        return 0;
    }
    /// <summary>
    /// Method, return count of strings, containing in Trie.
    /// </summary>
    public int Size { get { return 1; } }

}