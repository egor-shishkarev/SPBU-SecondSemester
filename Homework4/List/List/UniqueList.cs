namespace Lists;

/// <summary>
/// Class of List, that doesn't contains duplicate values.
/// </summary>
/// <typeparam name="Type">Type of elements in List</typeparam>
public class UniqueList<Type>: List<Type>
{
    /// <summary>
    /// Method to check if element already in List.
    /// </summary>
    /// <param name="element">Element, which we want to check.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">Value mustn't be null</exception>
    private bool Contains(Type element)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element), "Value mustn't be null");
        }
        var currentNode = head;

        for (int i = 0; i < size; ++i)
        {
            if (element.Equals(currentNode!.Value))
            {
                return true;
            }
            currentNode = currentNode.Next;
        }
        return false;
    }

    /// <summary>
    /// Method to add new element in Unique List. Can't add already existent element.
    /// </summary>
    /// <param name="element">Element, that we want to add.</param>
    /// <param name="position">Index in List, to which we want add new element.</param>
    /// <exception cref="InvalidOperationElementAlreadyExistException">Can't add already existent element.</exception>
    public override void Add(Type element, int position)
    {
        if (Contains(element))
        {
            throw new InvalidOperationElementAlreadyExistException(nameof(element));
        }
        base.Add(element, position);
    }

    /// <summary>
    /// Method, that change value of element. If new value already exist and current Node value doesn't equals newValue - throw exception.
    /// </summary>
    /// <param name="newValue">Value, that we want to change.</param>
    /// <param name="position">Index of element in List, which value we want to change.</param>
    /// <exception cref="InvalidOperationElementAlreadyExistException">Can't change value, because this value already in List.</exception>
    public override void ChangeValue(Type newValue, int position)
    {
        if (Contains(newValue) && !GetNode(position).Value!.Equals(newValue))
        {
            throw new InvalidOperationElementAlreadyExistException(nameof(newValue));
        }
        base.ChangeValue(newValue, position);
    }
}
