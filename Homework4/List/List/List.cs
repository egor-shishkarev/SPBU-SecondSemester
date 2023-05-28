namespace Lists;

public class List<T>
    where T: IComparable
{
    private protected Node? Head;


    private protected int count = 0;

    public int Count => count;

    private protected class Node
    {
        public T Value { get; set; }

        public Node? Next { get; set; }

        public Node(T value, Node next)
        {
            Value = value;
            Next = next;
        }
    }

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
