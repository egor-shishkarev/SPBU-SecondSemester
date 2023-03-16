namespace StackCalculatorClass;

/// <summary>
/// Interface for FIFO container
/// </summary>
public interface IStack
{
    /// <summary>
    /// Method that add new element to stack.
    /// </summary>
    /// <param name="newElement">Element, that we want to add to stack</param>
    void Push(float newElement);

    /// <summary>
    /// Method that returns and delete first element from stack.
    /// </summary>
    /// <returns>Element on the top of stack</returns>
    float Pop();

    /// <summary>
    /// Check stack for empty
    /// </summary>
    /// <returns>True - if stack is empty, False - if stack is not empty</returns>
    bool IsEmpty();
}
