namespace SkipList;

using System.Collections;

public class SkipList<T>: IList<T>
    where T: IComparable
{
    private Node Head = new(default!, new List<Node>());

    private readonly Node Tail = new(default!, new List<Node>());

    public int Count { get; private set; }

    public bool IsReadOnly => false;

    /// <summary>
    /// Max count of levels in skip list.
    /// </summary>
    private int maxHeight;

    /// <summary>
    /// Random function for adding elements to the following levels.
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
        Head.Next.Add(Tail);
    }

    /// <summary>
    /// Specific constructor for SkipList, where you can choose max height.
    /// </summary>
    /// <param name="maxHeight">Max count of levels in skip list.</param>
    public SkipList(int maxHeight)
    {
        if (maxHeight < 0)
        {
            throw new ArgumentOutOfRangeException("Count of levels less than zero is not possible!");
        }
        Head.Next.Add(Tail);
        this.maxHeight = maxHeight;
    }

    private class Node // Done
    { 
        /// <summary>
        /// Value of Node.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Array of nodes in environment.
        /// </summary>
        public List<Node> Next { get; set; }
        
        /// <summary>
        /// Constructor for node, where next nodes are known.
        /// </summary>
        /// <param name="item">Value of Node.</param>
        /// <param name="next">Nodes in environment.</param>
        public Node(T item, List<Node> next)
        {
            Value = item;
            Next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public Node(T item)
        {
            Value = item;
            Next = new List<Node>();
        }
    } 

    public IEnumerator<T> GetEnumerator() => new Enumerator(this);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public class Enumerator: IEnumerator<T>
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

    public T this[int index] // Done
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

    public int IndexOf(T item) // Done
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

    public void Insert(int index, T item) // Done
    {
        throw new NotSupportedException("In this type of list, insertion by index is not provided!");
    }

    public void RemoveAt(int index) // Done
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        var currentNode = Head;
        for (int i = 0; i < index; ++i)
        {
            currentNode = currentNode.Next[0];
        }
        currentNode.Next[0] = currentNode.Next[0].Next[0];
        ++currentVersionOfList;
        --Count;
        return;
    }

    public void Add(T item) // + Moving node to a new Level.
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        Node currentNode = Head;

        Node newNode = new(item);

        int currentHeightOfNode = currentNode.Next.Count - 1;

        while (true)
        {
            if ((item.CompareTo(currentNode.Value) > 0 && currentNode.Next[currentHeightOfNode] == Tail) || 
                (item.CompareTo(currentNode.Value) > 0 && item.CompareTo(currentNode.Next[currentHeightOfNode].Value) < 0) || 
                currentNode == Head && item.CompareTo(currentNode.Next[currentHeightOfNode].Value) < 0)
            {
                if (currentHeightOfNode == 0)
                {
                    var tempNode = currentNode.Next[0];
                    currentNode.Next[0] = newNode;
                    newNode.Next.Add(tempNode);
                    MovingNodeToNewLevel(currentNode, newNode);
                    break;
                }
                --currentHeightOfNode;
                currentNode = currentNode.Next[currentHeightOfNode];
            }
            else
            {
                currentNode = currentNode.Next[currentHeightOfNode];
            }
        }
        ++currentVersionOfList;
        ++Count;
    }

    public void Clear() // Done
    {
        ++currentVersionOfList;
        Count = 0;
        Head = new Node(default!, new List<Node>());
        Head.Next.Add(Tail);
    }

    public bool Contains(T item)
    {
        if (Head.Next[0] == default)
        {
            return false;
        }

        Node currentNode = Head;

        int currentHeightOfNode = currentNode.Next.Count - 1;

        while (true)
        {
            if (item.CompareTo(currentNode.Value) == 0)
            {
                return true;
            }
            if ((item.CompareTo(currentNode.Value) > 0 && currentNode.Next[currentHeightOfNode] == Tail) || (item.CompareTo(currentNode.Value) > 0 && item.CompareTo(currentNode.Next[currentHeightOfNode].Value) < 0))
            {
                if (currentHeightOfNode == 0)
                {
                    return false;
                }
                --currentHeightOfNode;
                currentNode = currentNode.Next[currentHeightOfNode];
            }
            else
            {
                currentNode = currentNode.Next[currentHeightOfNode];
            }
        }
    }

    public void CopyTo(T[] array, int arrayIndex)
    {

    }

    public bool Remove(T item)
    {
        ++currentVersionOfList;
        return false;
    }

    private void MovingNodeToNewLevel(Node currentNode, Node newNode)
    {
        int maxHeight = currentNode.Next.Count - 1;
        int currentHeight = 0;
        var adjacentNodes = new List<Node>() { newNode };
        while (RandomMoving() && currentHeight < maxHeight)
        {
            var tempNode = currentNode.Next[currentHeight + 1];
            var newLevelNode = new Node(newNode.Value);
            currentNode.Next[currentHeight + 1].Next[currentHeight + 1] = newLevelNode;
            newLevelNode.Next.Add(newNode);


        }
    }

    private bool RandomMoving()
    {
        return random.NextDouble() > 0.5;
    }
}