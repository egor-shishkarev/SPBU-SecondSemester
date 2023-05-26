namespace SkipList;

using System.Collections;
using System.Runtime.InteropServices;
using System.Xml.Linq;

public class SkipList<T>: IList<T>
    where T: IComparable
{
    private readonly Node Head = new(default, new List<Node>());

    private readonly Node Tail = new(default, new List<Node>());

    public int Count { get; private set; }

    public bool IsReadOnly => false;

    private int maxHeight;

    private int currentHeight;

    public SkipList()
    {
        Head.Next.Add(Tail);
    }

    public SkipList(int maxHeight)
    {
        Head.Next.Add(Tail);
        this.maxHeight = maxHeight;
    }

    private class Node 
    { 
        public T Value { get; set; }

        /// <summary>
        /// Array of nodes in environment. 
        /// </summary>
        public List<Node> Next { get; set; }
        
        public Node(T item, List<Node> next)
        {
            Value = item;
            Next = next;
        }

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
        throw new NotSupportedException("In this type of list, searching index of element is not provided!");
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

        int currentHeightOfNode = currentNode.Next.Count - 1;

        while (true)
        {
            if ((item.CompareTo(currentNode.Value) > 0 && currentNode.Next[currentHeightOfNode] == Tail) || (item.CompareTo(currentNode.Value) > 0 && item.CompareTo(currentNode.Next[currentHeightOfNode].Value) < 0))
            {
                if (currentHeightOfNode == 0)
                {
                    var tempNode = currentNode.Next[0];
                    currentNode.Next[0] = newNode;
                    newNode.Next.Add(tempNode);
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
        ++Count;
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
        var random = new Random();

        return random.NextDouble() > 0.5;
    }
}