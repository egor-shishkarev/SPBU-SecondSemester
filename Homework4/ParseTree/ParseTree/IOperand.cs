namespace Trees;

public interface IOperand
{
    /// <summary>
    /// Returns value of operand.
    /// </summary>
    /// <returns></returns>
    public float Calculate();

    /// <summary>
    /// Returns operand as a string.
    /// </summary>
    public string StringRepresentation { get; }

    /// <summary>
    /// Print operand in console.
    /// </summary>
    public void Print();
}
