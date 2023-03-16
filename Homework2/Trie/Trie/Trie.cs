namespace TrieClass;

/// <summary>
/// Class of Trie.
/// </summary>
public class Trie
{
    /// <summary>
    /// Main node of Trie.
    /// </summary>
    private readonly TrieNode head;

    /// <summary>
    /// Create new Trie
    /// </summary>
    public Trie()
    {
        head = new TrieNode();
    }

    /// <summary>
    /// Class of elements of Trie.
    /// </summary>
    private class TrieNode
    {
        /// <summary>
        /// Create new element.
        /// </summary>
        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
        }

        /// <summary>
        /// Value that indicates that the word is complete.
        /// </summary>
        public bool IsFinished { get; set; }

        /// <summary>
        /// Count of words, that contain this element.
        /// </summary>
        public int CountOfWords { get; set; }

        /// <summary>
        /// Dictionary of next nodes.
        /// </summary>
        public Dictionary<char, TrieNode> Children { get;  } 
    }

    /// <summary>
    /// Method, that add new string to Trie.
    /// </summary>
    /// <param name="element">String, that we want to add to Trie.</param>
    /// <returns>True - if element not in Trie, False - if element already was in Trie.</returns>
    public bool Add(string element)
    {
        if (element == null)
        {
            throw new Exception();
        }
        if (Contains(element))
        {
            return false;
        }
        var currentNode = head;
        foreach (char symbol in element)
        {
            ++currentNode.CountOfWords;
            if (!currentNode.Children.ContainsKey(symbol))
            {
                currentNode.Children.Add(symbol, new TrieNode());
            }
            currentNode = currentNode.Children[symbol];
        }
        ++currentNode.CountOfWords;
        currentNode.IsFinished = true;
        return true;
    }

    /// <summary>
    /// Method, that check if the string in Trie.
    /// </summary>
    /// <param name="element">String, that we want to check for containing in Trie. </param>
    /// <returns>True - if Trie contain string, False - if Trie doesn't contain string.</returns>
    public bool Contains(string element) 
    { 
        if (element == null)
        {
            throw new Exception();
        }
        var currentNode = head;
        foreach (char symbol in element)
        {
            if (currentNode.Children.ContainsKey(symbol))
            {
                currentNode = currentNode.Children[symbol];
            } 
            else
            {
                return false;
            }
        }
        return currentNode.IsFinished;
    }

    /// <summary>
    /// Method, that remove string from Trie
    /// </summary>
    /// <param name="element"> String, that we want to remove from Trie.</param>
    /// <returns>True - if Trie contains string, False - if Trie doesn't contains string</returns>
    public bool Remove(string element) 
    {  
        if (element == null)
        {
            throw new Exception();
        }
        if (!Contains(element))
        {
            return false;
        }
        var currentNode = head;
        foreach (char symbol in element)
        {
            --currentNode.CountOfWords;
            if (currentNode.Children[symbol].CountOfWords == 1)
            {
                currentNode.Children.Remove(symbol);
                return true;
            }
            currentNode = currentNode.Children[symbol];
        }
        --currentNode.CountOfWords;
        currentNode.IsFinished = false;
        return true;
    }

    /// <summary>
    /// Method, that returns how many string in Trie starts with given prefix.
    /// </summary>
    /// <param name="prefix">Prefix, that we want to count in Trie.</param>
    /// <returns>Number of strings, that contain given prefix</returns>
    public int HowManyStartsWithPrefix(string prefix)
    {
        if (prefix == null)
        {
            throw new Exception();
        }
        var currentNode = head;
        foreach(char symbol in prefix)
        {
            if (!currentNode.Children.ContainsKey(symbol))
            {
                return 0;
            }
            currentNode = currentNode.Children[symbol];
        }
        return currentNode.CountOfWords;
    }

    /// <summary>
    /// Method, return count of strings, containing in Trie.
    /// </summary>
    public int Size => head.CountOfWords;
}
