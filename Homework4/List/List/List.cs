namespace Lists;

/// <summary>
/// Class of structure List.
/// </summary>
/// <typeparam name="Type">Type of list elements.</typeparam>
public class List<Type>
{
    /// <summary>
    /// Field - count of elements in List.
    /// </summary>
    private protected int size;


    /// <summary>
    /// Field - the first element in List
    /// </summary>
    private protected Node? head;

    /// <summary>
    /// Sets or Gets the element at the given index. 
    /// </summary>
    /// <param name="position">Index of element.</param>
    /// <returns>Value of element at the given index.</returns>
    public Type this[int position] 
    {
        get { return GetNode(position).Value; }
        set { ChangeValue(value, position); }
    }

    /// <summary>
    /// Method, that add new element to List.
    /// </summary>
    /// <param name="element">Element, that we want to add.</param>
    /// <param name="position">Index, to which we want add new element.</param>
    /// <exception cref="ArgumentOutOfRangeException">Position is out of range.</exception>
    public virtual void Add(Type element, int position)
    {
        if (position < 0 || position > size)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Wrong position");
        }
        if (position == 0)
        {
            head = new Node(element, head!);
        }
        else
        {
            var previousNode = GetNode(position - 1);
            var newNode = new Node(element, previousNode.Next!);
            previousNode.Next = newNode;
        }
        ++size;
    }

    /// <summary>
    /// Method, that remove element in List by index.
    /// </summary>
    /// <param name="position">Index of element, that we want to remove.</param>
    /// <exception cref="ArgumentOutOfRangeException">Position is out of range</exception>
    public void Remove(int position)
    {
        if (position < 0 || position >= size)
        {
            throw new InvalidOperationRemoveNonexistentElementException(nameof(position));
        }
        if (position == 0)
        {
            head = head?.Next;
        } 
        else
        {
            var currentNode = GetNode(position - 1);
            currentNode.Next = currentNode.Next!.Next;
        }
        --size;
    }

    /// <summary>
    /// Method, that change value of element at the given index.
    /// </summary>
    /// <param name="newValue">New value.</param>
    /// <param name="position">Index of element, that we want to change.</param>
    /// <exception cref="ArgumentOutOfRangeException">Position is out of range</exception>
    public virtual void ChangeValue(Type newValue, int position)
    {
        if (position < 0 || position >= size)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range");
        }
        var currentNode = GetNode(position);
        currentNode.Value = newValue;
    }

    /// <summary>
    /// Current count of elements in List.
    /// </summary>
    public int Size => size;

    /// <summary>
    /// Check List to empty.
    /// </summary>
    public bool IsEmpty => size == 0;

    /// <summary>
    /// Class of elements in List.
    /// </summary>
    private protected class Node
    {
        /// <summary>
        /// Field, that contains value of Node.
        /// </summary>
        public Type Value { get; set; }

        /// <summary>
        /// Next element in List.
        /// </summary>
        public Node? Next { get; set; }

        /// <summary>
        /// Constructor for Node.
        /// </summary>
        /// <param name="element">Value of element.</param>
        /// <param name="next">Next Node in List.</param>
        public Node(Type element, Node next)
        {
            Value = element;
            Next = next;
        }
    }

    /// <summary>
    /// Auxiliary method to get Node by position.
    /// </summary>
    /// <param name="position">Position of Node, that we want to get.</param>
    /// <returns>Node with given position.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Wrong position</exception>
    private protected Node GetNode(int position)
    {
        if (position < 0 || position > size)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Wrong position");
        }
        var currentNode = head;
        for (int i = 0; i < position; ++i)
        {
            currentNode = currentNode!.Next;
        }
        return currentNode!;
    }
}
