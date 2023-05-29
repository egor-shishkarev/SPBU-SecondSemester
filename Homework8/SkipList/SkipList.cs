﻿namespace SkipList;

using System.Collections;
using System.Xml.Linq;

public class SkipList<T>: IList<T>
    where T: IComparable
{
    private Node Head = new(default!, new List<Node>() { default! });

    private readonly Node Tail = new(default!, new List<Node>());

    public int Count { get; private set; }

    public bool IsReadOnly => false;

    /// <summary>
    /// Max count of levels in skip list.
    /// </summary>
    private readonly int maxHeight = 3;

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
            throw new ArgumentOutOfRangeException("Count of levels less than zero is not possible!");
        }
        Head.Next[0] = Tail;
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
            Next = new List<Node>() { default!, default! };
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

        int heightOfNewNode = 0;

        int currentHeightOfSkipList = Head.Next.Count - 1;

        while (RandomMoving() && heightOfNewNode < maxHeight)
        {
            ++heightOfNewNode;
        }

        var listOfNodes = new List<Node>();
        for (int i = 0; i <= heightOfNewNode; ++i)
        {
            listOfNodes.Add(new Node(item));
            if (i - 1 >= 0)
            {
                listOfNodes[i - 1].Next[1] = listOfNodes[i];
            }
        }
        Node currentNode = Head;

        var newNode = listOfNodes[0];
        while (true)
        {
            if (currentNode == Head)
            {
                if (heightOfNewNode >= currentHeightOfSkipList)
                {
                    for (int i = currentHeightOfSkipList + 1; i <= heightOfNewNode; ++i)
                    {
                        var node = listOfNodes[i];
                        Head.Next.Add(node);
                        node.Next[0] = Tail;
                    }
                }
                if (item.CompareTo(currentNode.Next[currentHeightOfSkipList].Value) < 0 || currentNode.Next[0] == Tail)
                {
                    var tempNode = currentNode.Next[currentHeightOfSkipList];
                    currentNode.Next[currentHeightOfSkipList] = newNode;
                    newNode.Next[currentHeightOfSkipList] = tempNode;
                    if (currentNode.Next.Count == 1 || currentNode.Next[1] == default)
                    {
                        break;
                    }
                    if (currentHeightOfSkipList == 0)
                    {
                        break;
                    }
                    currentNode = currentNode.Next[currentHeightOfSkipList - 1];
                    newNode = listOfNodes[listOfNodes.IndexOf(newNode) + 1];
                }
                if (currentNode.Next[currentHeightOfSkipList] != Tail)
                {
                    currentNode = currentNode.Next[currentHeightOfSkipList];
                    continue;
                }
                else
                {
                    --currentHeightOfSkipList;
                    currentNode = currentNode.Next[currentHeightOfSkipList];
                    continue;
                }
            }
            else
            {
                if ((item.CompareTo(currentNode.Value) > 0 && currentNode.Next[0] == Tail) ||
                (item.CompareTo(currentNode.Value) > 0 && item.CompareTo(currentNode.Next[0].Value) < 0) ||
                currentNode == Head && item.CompareTo(currentNode.Next[0].Value) < 0 ||
                currentNode == Head && currentNode.Next[0] == Tail)
                {
                    var tempNode = currentNode.Next[0];
                    currentNode.Next[0] = newNode;
                    newNode.Next[0] = tempNode;
                    if (currentNode.Next.Count == 1 || currentNode.Next[1] == default)
                    {
                        break;
                    }
                    if (currentHeightOfSkipList == 0)
                    {
                        break;
                    }
                    currentNode = currentNode.Next[1];
                    if (listOfNodes.IndexOf(newNode) + 1 >= listOfNodes.Count - 1)
                    {
                        break;
                    }
                    newNode = listOfNodes[listOfNodes.IndexOf(newNode) + 1];
                }
                else
                {
                    if (currentNode.Next[0] != Tail)
                    {
                        currentNode = currentNode.Next[0];
                        continue;
                    }
                    else
                    {
                        currentNode = currentNode.Next[1];
                        currentHeightOfSkipList = 0;
                        continue;
                    }
                }
            }


            
        }
        ++currentVersionOfList;
        ++Count;
    }

    public void Clear() // Done
    {
        ++currentVersionOfList;
        Count = 0;
        Head = new Node(default!, new List<Node>() { default! });
        Head.Next[0] = Tail;
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

    public void CopyTo(T[] array, int arrayIndex) // Done
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

    public bool Remove(T item)
    {
        ++currentVersionOfList;
        return false;
    }

    private bool RandomMoving()
    {
        return random.NextDouble() > 0.5;
    }
}