using System.Security;

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
        head = new TrieNode(-1);
    }

    /// <summary>
    /// Class of elements of Trie.
    /// </summary>
    private class TrieNode
    {
        /// <summary>
        /// Create new element.
        /// </summary>
        public TrieNode(int value)
        {
            Children = new Dictionary<byte, TrieNode>();
            Value = value;
        }

        /// <summary>
        /// Value that indicates that the word is complete.
        /// </summary>
        public bool IsFinished { get; set; }

        /// <summary>
        /// Count of words, that contain this element.
        /// </summary>
        public int CountOfBytes { get; set; }

        /// <summary>
        /// Dictionary of next nodes.
        /// </summary>
        public Dictionary<byte, TrieNode> Children { get; }

        /// <summary>
        /// Field for value of node.
        /// </summary>
        public int Value { get; }
    }

    /// <summary>
    /// Method, that add new string to Trie.
    /// </summary>
    /// <param name="element">String, that we want to add to Trie.</param>
    /// <returns>True - if element not in Trie, False - if element already was in Trie.</returns>
    public void Add(List<byte> element, int value)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element), "List of bytes mustn't be null!");
        }
        var currentNode = head;
        foreach (byte part in element)
        {
            ++currentNode.CountOfBytes;
            if (!currentNode.Children.ContainsKey(part))
            {
                currentNode.Children.Add(part, new TrieNode(value));
            }
            currentNode = currentNode.Children[part];
        }
        ++currentNode.CountOfBytes;
        currentNode.IsFinished = true;
    }

    /// <summary>
    /// Method, that check if the string in Trie.
    /// </summary>
    /// <param name="element">String, that we want to check for containing in Trie. </param>
    /// <returns>True - if Trie contain string, False - if Trie doesn't contain string.</returns>
    public bool Contains(List<byte> element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element), "List of bytes mustn't be null!");
        }
        var currentNode = head;
        foreach (byte part in element)
        {
            if (currentNode.Children.ContainsKey(part))
            {
                currentNode = currentNode.Children[part];
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
    public bool Remove(List<byte> element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element), "List of bytes mustn't be null!");
        }
        if (!Contains(element))
        {
            return false;
        }
        var currentNode = head;
        foreach (byte part in element)
        {
            --currentNode.CountOfBytes;
            if (currentNode.Children[part].CountOfBytes == 1)
            {
                currentNode.Children.Remove(part);
                return true;
            }
            currentNode = currentNode.Children[part];
        }
        --currentNode.CountOfBytes;
        currentNode.IsFinished = false;
        return true;
    }

    /// <summary>
    /// Method, that returns how many string in Trie starts with given prefix.
    /// </summary>
    /// <param name="prefix">Prefix, that we want to count in Trie.</param>
    /// <returns>Number of strings, that contain given prefix</returns>
    public int HowManyStartsWithPrefix(List<byte> prefix)
    {
        if (prefix == null)
        {
            throw new ArgumentNullException(nameof(prefix), "List of bytes mustn't be null!");
        }
        var currentNode = head;
        foreach (byte part in prefix)
        {
            if (!currentNode.Children.ContainsKey(part))
            {
                return 0;
            }
            currentNode = currentNode.Children[part];
        }
        return currentNode.CountOfBytes;
    }

    /// <summary>
    /// Method, return count of strings, containing in Trie.
    /// </summary>
    public int Size => head.CountOfBytes;

    public int GetValue(List<byte> element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element), "List of bytes mustn't be null!");
        }
        var currentNode = head;
        for (int i = 0; i < element.Count; i++)
        {
            if (!currentNode.Children.ContainsKey(element[i]))
            {
                return -1;
            }
            currentNode = currentNode.Children[element[i]];
        }
        return currentNode.Value;
    }
}