namespace Lists;

/// <summary>
/// Class descendant List with non-repeating values.
/// </summary>
/// <typeparam name="T">Type of element in list. Should be IComparable.</typeparam>
public class UniqueList<T> : List<T> where T : IComparable
{
    /// <summary>
    /// Special method for UniqueList to change values. Additionally checks if the element with such value already exists in the list.
    /// </summary>
    /// <param name="index">Index in list.</param>
    /// <param name="newValue">New value of node.</param>
    /// <exception cref="InvalidOperationElementAlreadyExistsException">Element with such value already exist in list.</exception>
    public override void ChangeValue(int index, T newValue)
    {
        if (newValue == null)
        {
            throw new ArgumentNullException(nameof(newValue));
        }
        var currentNode = Head;
        for (int i = 0; i < Count; ++i)
        {
            if (i != index && newValue.CompareTo(currentNode!.Value) == 0)
            {
                throw new InvalidOperationElementAlreadyExistsException("Element already exist in list!");
            }
            currentNode = currentNode!.Next;
        }
        base.ChangeValue(index, newValue);
    }

    /// <summary>
    /// Special method for UniqueList to add new elements in list by index. Additionally checks if the element with such value already exist in the list.
    /// </summary>
    /// <param name="index">Index in list.</param>
    /// <param name="value">Value of new node.</param>
    /// <exception cref="InvalidOperationElementAlreadyExistsException">Element with such value already exist in list.</exception>
    public override void Add(int index, T value)
    {
        if (Contains(value))
        {
            throw new InvalidOperationElementAlreadyExistsException("Element already exist in list!");
        }
        base.Add(index, value);
    }

    /// <summary>
    /// Special method for UniqueList to add new elements in the end of list. Additionally checks if the element with such value already exist in the list.
    /// </summary>
    /// <param name="value">Value of new node.</param>
    /// <exception cref="InvalidOperationElementAlreadyExistsException">Element with such value already exist in list.</exception>
    public override void Add(T value)
    {
        if (Contains(value))
        {
            throw new InvalidOperationElementAlreadyExistsException("Element already exist in list!");
        }
        base.Add(value);
    }

    /// <summary>
    /// Special method for UniqueList to remove elements by value. 
    /// </summary>
    /// <param name="value">Node's value which we want to remove.</param>
    /// <exception cref="InvalidOperationRemoveNonexistentElementException">Element with such value already exist in list.</exception>
    public void RemoveByValue(T value)
    {
        if (Count == 0)
        {
            throw new ArgumentException("You cannot delete an item from an empty list!");
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
                --Count;
                return;
            }
            currentNode = currentNode!.Next;
        }
        if (value.CompareTo(currentNode!.Value) != 0)
        {
            throw new InvalidOperationRemoveNonexistentElementException(nameof(value));
        }
        --Count;
    }
}
