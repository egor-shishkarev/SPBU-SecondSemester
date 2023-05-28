namespace Lists;

public class UniqueList<T>: List<T> where T: IComparable
{
    public override void ChangeValue(int index, T newValue)
    {
        var currentNode = Head;
        for (int i = 0; i < Count; ++i)
        {
            if (i != index && newValue.CompareTo(currentNode!.Value) == 0)
            {
                throw new InvalidOperationElementAlreadyExistException("Element already exist in list!");
            }
            currentNode = currentNode!.Next;
        }
        base.ChangeValue(index, newValue);
    }

    public override void Add(int index, T value)
    {
        if (Contains(value))
        {
            throw new InvalidOperationElementAlreadyExistException("Element already exist in list!");
        }
        base.Add(index, value);
    }

    public override void Add(T value)
    {
        if (Contains(value))
        {
            throw new InvalidOperationElementAlreadyExistException("Element already exist in list!");
        }
        base.Add(value);
    }

    public void RemoveByValue(T value)
    {
        if (Count == 0)
        {
            return;
        }
        if (value.CompareTo(Head!.Value) == 0)
        {
            Head = Head.Next;
        }
        var currentNode = Head;
        for (int i = 0; i < Count - 1; ++i)
        {
            if (value.CompareTo(currentNode!.Next!.Value) == 0)
            {
                currentNode.Next = currentNode.Next.Next;
                --count;
                return;
            }
            currentNode = currentNode!.Next;
        }
        if (value.CompareTo(currentNode!.Value) != 0)
        {
            throw new InvalidOperationRemoveNonexistentElementException(nameof(value));
        }
        --count;
    }
}
