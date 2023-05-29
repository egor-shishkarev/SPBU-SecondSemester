namespace SkipList;

using System.Collections;

/// <summary>
/// Special list, where operation of Remove, Add, Contains are O(logN).
/// </summary>
/// <typeparam name="T">Type of elements in list.</typeparam>
public class SkipList<T> : IList<T> where T : IComparable
{
    /// <summary>
    /// Main node in Skip List.
    /// </summary>
    private Node Head = new(default!, new Node[1]);

    /// <summary>
    /// End node in Skip List.
    /// </summary>
    private readonly Node Tail = new(default!, Array.Empty<Node>());

    /// <summary>
    /// Count of elements in list.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// A property that indicates whether the structure can be changed after creation.
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// Random function for adding elements to the up levels.
    /// </summary>
    private readonly Random random = new();

    /// <summary>
    /// Additional field to check if List is changed.
    /// </summary>
    private int currentVersionOfList = 0;

    /// <summary>
    /// Constructor for SkipList.
    /// </summary>
    public SkipList()
    {
        Head.Next[0] = Tail;
    }

    /// <summary>
    /// Specific constructor for SkipList, where you can choose max height.
    /// </summary>
    /// <param name="maxHeight">Max count of levels in skip list.</param>
    public SkipList(int maxHeight)
    {
        if (maxHeight < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxHeight));
        }
        Head.Next[0] = Tail;
    }

    /// <summary>
    /// Element in Skip List.
    /// </summary>
    private class Node
    {
        /// <summary>
        /// Value of Node.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Links to the following nodes at the i-th level.
        /// </summary>
        public Node[] Next { get; set; }

        /// <summary>
        /// Constructor for node.
        /// </summary>
        /// <param name="item">Value of Node.</param>
        /// <param name="next">Following nodes.</param>
        public Node(T item, Node[] next)
        {
            Value = item;
            Next = next;
        }
    }

    /// <summary>
    /// Creates new enumerator.
    /// </summary>
    /// <returns></returns>
    public IEnumerator<T> GetEnumerator() => new Enumerator(this);

    /// <summary>
    /// Return enumerator.
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    /// Enumerator for Skip List.
    /// </summary>
    public class Enumerator : IEnumerator<T>
    {
        Node currentNode;

        private readonly SkipList<T> skipList;

        private readonly int currentVersionOfList;

        public Enumerator(SkipList<T> skipList)
        {
            this.skipList = skipList;
            this.currentVersionOfList = skipList.currentVersionOfList;
            currentNode = this.skipList.Head;
        }

        public T Current
        {
            get
            {
                if (currentNode == skipList.Head)
                {
                    throw new InvalidOperationException();
                }
                return currentNode.Value!;
            }
        }

        object IEnumerator.Current => Current;

        public void Reset()
        {
            if (currentVersionOfList != skipList.currentVersionOfList)
            {
                throw new ArgumentException("List was changed!");
            }
            currentNode = skipList.Head;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (currentVersionOfList != skipList.currentVersionOfList)
            {
                throw new ArgumentException("List was changed!");
            }
            if (currentNode == skipList.Tail || currentNode.Next[0] == skipList.Tail)
            {
                return false;
            }

            currentNode = currentNode.Next[0];

            return true;
        }
    }

    /// <summary>
    /// Method to return element's value by construction  - SkipList[index].
    /// </summary>
    /// <param name="index">Index of element, which value we want to return.</param>
    /// <returns>Value of element.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Index was out of range.</exception>
    /// <exception cref="NotSupportedException">Can't change values in Skip List.</exception>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var currentNode = Head;
            for (int i = 0; i <= index; ++i)
            {
                currentNode = currentNode.Next[0];
            }

            return currentNode.Value;
        }
        set
        {
            throw new NotSupportedException("In this type of list, insertion by index is not provided!");
        }
    }

    /// <summary>
    /// Find index of element in Skip List.
    /// </summary>
    /// <param name="item">Value of element, which index we want to find.</param>
    /// <returns>Index of element in Skip List.</returns>
    /// <exception cref="ArgumentNullException">Item was null.</exception>
    public int IndexOf(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        var currentNode = Head;
        for (int i = 0; i <= Count; ++i)
        {
            if (item.CompareTo(currentNode.Value) == 0)
            {
                return i - 1;
            }
            currentNode = currentNode.Next[0];
        }
        return -1;
    }

    /// <summary>
    /// Not supported operation in Skip List.
    /// </summary>
    /// <param name="index">Index.</param>
    /// <param name="item">Value.</param>
    /// <exception cref="NotSupportedException">Not supported operation in Skip List.</exception>
    public void Insert(int index, T item)
    {
        throw new NotSupportedException("In this type of list, insertion by index is not provided!");
    }

    /// <summary>
    /// Remove element from Skip List by index.
    /// </summary>
    /// <param name="index">Index of element, which we want to remove.</param>
    public void RemoveAt(int index)
    {
        Remove(this[index]);
    }

    /// <summary>
    /// Method, which add new element to Skip List.
    /// </summary>
    /// <param name="item">Value, which we want to add in Skip List.</param>
    /// <exception cref="ArgumentNullException">Item was null.</exception>
    public void Add(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        var heightOfNewNode = 1;

        while (heightOfNewNode <= Head.Next.Length && RandomMoving())
        {
            ++heightOfNewNode;
        }

        var newNode = new Node(item, new Node[heightOfNewNode]);

        var previousNodesOnEachLevel = GetPreviousNodesOnEachLevel(item);

        for (int i = 0; i < heightOfNewNode && i < Head.Next.Length; ++i)
        {
            newNode.Next[i] = previousNodesOnEachLevel[i].Next[i];
            previousNodesOnEachLevel[i].Next[i] = newNode;
        }

        if (heightOfNewNode > Head.Next.Length)
        {
            var newHead = new Node(default!, new Node[heightOfNewNode]);
            Head.Next.CopyTo(newHead.Next, 0);
            newHead.Next[heightOfNewNode - 1] = newNode;
            Head = newHead;
            newNode.Next[heightOfNewNode - 1] = Tail;
        }
        ++currentVersionOfList;
        ++Count;
    }

    /// <summary>
    /// Clears Skip List.
    /// </summary>
    public void Clear()
    {
        ++currentVersionOfList;
        Count = 0;
        Head = new Node(default!, new Node[1]);
        Head.Next[0] = Tail;
    }

    public bool Contains(T item)
    {
        var previousNodes = GetPreviousNodesOnEachLevel(item);

        return previousNodes[0].Next[0] != Tail && item.CompareTo(previousNodes[0].Next[0].Value) == 0;
    }

    /// <summary>
    /// Copies Skip List to array starting from the specified index.
    /// </summary>
    /// <param name="array">Array where we want copy our Skip List.</param>
    /// <param name="arrayIndex">The index from which the Skip List will start in the array.</param>
    /// <exception cref="ArgumentNullException">Arrat was null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Index was out of range.</exception>
    /// <exception cref="ArgumentException">Not enough space in array.</exception>
    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        if (arrayIndex < 0 || arrayIndex > array.Length - 1)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        }
        if (Count + arrayIndex > array.Length)
        {
            throw new ArgumentException("Not enough space in array!");
        }
        var currentNode = Head.Next[0];
        for (int i = 0; i < Count; ++i)
        {
            array[arrayIndex + i] = currentNode.Value;
            currentNode = currentNode.Next[0];
        }
    }

    /// <summary>
    /// Removes an element from Skip List.
    /// </summary>
    /// <param name="item">Value of element, which we want to remove.</param>
    /// <returns>True - if element contains in list; otherwise - false.</returns>
    /// <exception cref="ArgumentNullException">Item was null.</exception>
    public bool Remove(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        var previousNodesOnEachLevels = GetPreviousNodesOnEachLevel(item);
        var nextNode = previousNodesOnEachLevels[0].Next[0];
        if (nextNode != Tail && item.CompareTo(nextNode.Value) == 0)
        {
            for (int i = 0; i < nextNode.Next.Length; ++i)
            {
                previousNodesOnEachLevels[i].Next[i] = nextNode.Next[i];
            }
            --Count;
            ++currentVersionOfList;
            return true;
        }
        return false;
    }

    /// <summary>
    /// An additional function to move an item to a new level.
    /// </summary>
    /// <returns></returns>
    private bool RandomMoving()
    {
        return random.NextDouble() > 0.5;
    }

    /// <summary>
    /// Method to find previous nodes for every level in Skip List.
    /// </summary>
    /// <param name="item">Value for which we want to find previous nodes.</param>
    /// <returns>Array of previous nodes.</returns>
    /// <exception cref="ArgumentNullException">Item was null.</exception>
    private Node[] GetPreviousNodesOnEachLevel(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        var currentNode = Head;
        var previousNodes = new Node[Head.Next.Length];
        for (var i = Head.Next.Length - 1; i >= 0; --i)
        {
            var isMore = item.CompareTo(currentNode.Next[i].Value) > 0;

            while (isMore && currentNode.Next[i] != Tail)
            {
                currentNode = currentNode.Next[i];
                isMore = item.CompareTo(currentNode.Next[i].Value) > 0;
            }
            previousNodes[i] = currentNode;
        }
        return previousNodes;
    }
}