namespace SkipList;

using System.Collections;

public class SkipList<T>: IList<T>
    where T: IComparable
{
    private readonly Node Head = new Node(default, Array.Empty<Node>());

    private readonly Node Tail = new Node(default, Array.Empty<Node>());

    public int Count { get; private set; }

    public bool IsReadOnly => false;

    private int maxHeight;

    private int currentHeight;

    public SkipList()
    {
        Head.Next[0] = Tail;
    }

    public SkipList(int maxHeight)
    {
        Head.Next[0] = Tail;
        this.maxHeight = maxHeight;
    }

    private class Node 
    { 
        public T Value { get; set; }

        int Index { get; set; }

        int Level { get; set; } 


        /// <summary>
        /// Array of nodes in environment. 0 - next node, 1 - down level node.
        /// </summary>
        public Node[] Next { get; set; }
        
        public Node(T item, Node[] next)
        {
            Value = item;
            Next = next;
        }

        public Node(T item)
        {
            Value = item;
        }
    } 

    public IEnumerator<T> GetEnumerator() => new Enumerator(this);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public class Enumerator: IEnumerator<T>
    {
        Node currentNode;

        private readonly SkipList<T> skipList;

        public Enumerator(SkipList<T> skipList)
        {
            currentNode = skipList.Head;
            this.skipList = skipList;
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
            currentNode = skipList.Head;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool MoveNext()
        {
            if (currentNode == skipList.Tail)
            {
                return false;
            }

            currentNode = currentNode.Next[0];

            return true;
        }
    }

    public T this[int index]
    {
        get
        {
            return (T)this[index];
        }
        set
        {
            throw new NotSupportedException("In this type of list, insertion by index is not provided!");
        }
    }

    public int IndexOf(T item)
    {
        throw new NotSupportedException();
    }

    public void Insert(int index, T item)
    {
        throw new NotSupportedException("In this type of list, insertion by index is not provided!");
    }

    public void RemoveAt(int index)
    {
        return;
    }

    public void Add(T item)
    {
        Node currentNode = Head;

        Node newNode = new Node(item);

        int currentHeightOfNode = currentNode.Next.Length;

        while (true)
        {
            if ((item.CompareTo(currentNode.Value) > 0 && currentNode.Next[currentHeightOfNode] == Tail) || (item.CompareTo(currentNode.Value) > 0 && item.CompareTo(currentNode.Next[currentHeightOfNode].Value) < 0))
            {
                if (currentHeightOfNode == 0)
                {
                    currentNode.Next[0] = newNode;
                    newNode.Next[0] = currentNode.Next[currentHeightOfNode];
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
    }

    public void Clear()
    {

    }

    public bool Contains(T item)
    {
        if (Head.Next[0] == default)
        {
            return false;
        }

        Node currentNode = Head;

        Node newNode = new Node(item);

        int currentHeightOfNode = currentNode.Next.Length;

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
        return false;
    }
}