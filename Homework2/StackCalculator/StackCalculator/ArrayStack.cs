namespace StackCalculatorClass;

/// <summary>
/// Class of stack founded on array.
/// </summary>
public class ArrayStack: IStack
{
    /// <summary>
    /// Index of the top element in stack.
    /// </summary>
    private int indexOfTop = -1;

    /// <summary>
    /// Size of stack - count of elements in stack.
    /// </summary>
    private int currentSize = 2;

    /// <summary>
    /// Array that represents stack.
    /// </summary>
    private float[] stack;

    /// <summary>
    /// Constructor of stack based on array.
    /// </summary>
    public ArrayStack()
    {
        stack = new float[currentSize];
    }

    /// <summary>
    /// Method, that resize array, multiplying size by 2.
    /// </summary>
    public void ResizeStack()
    {
        currentSize *= 2;
        var additionalStack = new float[currentSize];
        stack.CopyTo(additionalStack, 0);
        stack = additionalStack;
    }

    /// <summary>
    /// Method, that push element in stack.
    /// </summary>
    /// <param name="number">Number, that we want to push in stack.</param>
    public void Push(float number)
    {
        ++indexOfTop;
        if (currentSize - indexOfTop < 2)
        {
            ResizeStack();
        }
        stack[indexOfTop] = number;
    }

    /// <summary>
    /// Method, that returns element from the top of stack.
    /// </summary>
    /// <returns>Number from the top of stack.</returns>
    /// <exception cref="Exception">Empty stack</exception>
    public float Pop()
    {
        if (IsEmpty())
        {
            throw new Exception();
        }
        --indexOfTop;
        return stack[indexOfTop + 1];
    }

    /// <summary>
    /// Method,that checks if stack is empty.
    /// </summary>
    /// <returns>True - if stack is empty, False - if stack is not empty.</returns>
    public bool IsEmpty() => indexOfTop == -1;
}
