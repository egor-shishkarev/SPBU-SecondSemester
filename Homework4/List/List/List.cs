using System.Xml.Linq;

namespace Lists;

/// <summary>
/// Class of own list.
/// </summary>
/// <typeparam name="T">Type of element in list. Should be IComparable.</typeparam>
public class List<T>
    where T: IComparable
{
    /// <summary>
    /// Main node in list.
    /// </summary>
    private protected Node? Head;

    /// <summary>
    /// Count of elements in list.
    /// </summary>
    private protected int count = 0;

    /// <summary>
    /// Method, which returns count of elements in list.
    /// </summary>
    public int Count => count;

    /// <summary>
    /// Element in list.
    /// </summary>
    private protected class Node
    {
        /// <summary>
        /// Value of node - T.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Next node in list. Can be null.
        /// </summary>
        public Node? Next { get; set; }

        /// <summary>
        /// Constructor for Node instance.
        /// </summary>
        /// <param name="value">Value which node contains.</param>
        /// <param name="next">Next node in list.</param>
        public Node(T value, Node next)
        {
            Value = value;
            Next = next;
        }
    }

    /// <summary>
    /// Method, which refers to the elements of the list.
    /// </summary>
    /// <param name="index">Index in list.</param>
    /// <returns>Element of list.</returns>
    public T this[int index]
    {
        get
        {
            return GetNodeValueByIndex(index);
        }
        set
        {
            ChangeValue(index, value);
        }
    }

    /// <summary>
    /// Changes value of element in list.
    /// </summary>
    /// <param name="index">Index in list.</param>
    /// <param name="newValue">New value for the element.</param>
    /// <exception cref="ArgumentOutOfRangeException">Index was out of range.</exception>
    public virtual void ChangeValue(int index, T newValue)
    {
        if (index > Count - 1 || index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        var currentNode = Head;
        for (int i = 0; i < index; ++i)
        {
            currentNode = currentNode!.Next;
        }
        currentNode!.Value = newValue;
    }

    /// <summary>
    /// Method to get value of node.
    /// </summary>
    /// <param name="index">Index in list.</param>
    /// <returns>Value of node.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Index was out of range.</exception>
    private T GetNodeValueByIndex(int index)
    {
        if (index > Count - 1 || index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        var currentNode = Head;
        for (int i = 0; i < index; ++i)
        {
            currentNode = currentNode!.Next;
        }
        return currentNode!.Value;
    }

    /// <summary>
    /// Method to add new elements in list by index.
    /// </summary>
    /// <param name="index">Index, where we want to add new element.</param>
    /// <param name="value">Value of new node.</param>
    /// <exception cref="ArgumentOutOfRangeException">Index was out of range.</exception>
    public virtual void Add(int index, T value)
    {
        if (index > Count || index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        var currentNode = Head;
        if (index == 0)
        {
            Head = new Node(value, Head!);
            ++count;
            return;
        }
        for (int i = 0; i < index - 1; ++i)
        {
            currentNode = currentNode!.Next;
        }
        var newNode = new Node(value, currentNode!.Next!);
        currentNode.Next = newNode;
        ++count;
    }

    /// <summary>
    /// Method to add new element in the end of list.
    /// </summary>
    /// <param name="value">Value of new node.</param>
    public virtual void Add(T value)
    {
        if (Count == 0)
        {
            Head = new Node(value, Head!);
            ++count;
            return;
        }
        var currentNode = Head;
        for (int i = 0; i < Count - 1; ++i)
        {
            currentNode = currentNode!.Next;
        }
        var newNode = new Node(value, currentNode!.Next!);
        currentNode.Next = newNode;
        ++count;
    }

    /// <summary>
    /// Method to remove element of list.
    /// </summary>
    /// <param name="index">Index in list.</param>
    /// <exception cref="ArgumentOutOfRangeException">Index was out of range.</exception>
    public void RemoveByIndex(int index)
    {
        if (index > Count - 1 || index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        if (index == 0)
        {
            Head = Head!.Next;
            --count;
            return;
        }
        var currentNode = Head;
        for (int i = 0; i < index - 1; ++i)
        {
            currentNode = currentNode!.Next;
        }
        currentNode!.Next = currentNode.Next!.Next;
        --count;
    }

    /// <summary>
    /// Method to check if such value contains in list.
    /// </summary>
    /// <param name="value">Value which we want to check.</param>
    /// <returns>True - if element with such value exist in list; otherwise - false.</returns>
    public bool Contains(T value)
    {
        var currentNode = Head;
        for (int i = 0; i < Count; ++i)
        {
            if (value.CompareTo(currentNode!.Value) == 0)
            {
                return true;
            }
            currentNode = currentNode!.Next;
        }
        return false;
    }
}
