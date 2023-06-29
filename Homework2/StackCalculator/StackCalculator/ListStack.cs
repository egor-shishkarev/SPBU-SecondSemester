namespace StackCalculatorClass;

/// <summary>
/// Class of stack founded on List.
/// </summary>
public class ListStack: IStack
{
    /// <summary>
    /// List - view of stack;
    /// </summary>
    private readonly List<float> stack;

    /// <summary>
    /// Constructor of stack based on list.
    /// </summary>
    public ListStack()
    {
        stack = new List<float>();
    }

    /// <summary>
    /// Method, that push elements in stack (add element to list).
    /// </summary>
    /// <param name="number">Number, that we want to add to stack.</param>
    public void Push(float number)
    {
        stack.Add(number);
    }

    /// <summary>
    /// Method, that return number from stack.
    /// </summary>
    /// <returns>Number from the top of stack</returns>
    /// <exception cref="InvalidOperationException">Empty stack</exception>
    public float Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Can't pop from empty stack!");
        }
        var elementToPop = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);
        return elementToPop;
    }
    
    /// <summary>
    /// Method, that checks if stack is empty.
    /// </summary>
    /// <returns>True - if stack is empty, Fasle - if stack is not empty.</returns>
    public bool IsEmpty() => stack.Count == 0;

}
