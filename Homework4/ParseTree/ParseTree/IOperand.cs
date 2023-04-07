namespace Trees;

/// <summary>
/// Interface for element in parse tree.
/// </summary>
public interface IOperand
{
    /// <summary>
    /// Calculate operand.
    /// </summary>
    /// <returns>Result of calculating.</returns>
    double Calculate();

    /// <summary>
    /// Print operand to Console.
    /// </summary>
    void Print();

    /// <summary>
    /// Give string representation of operand
    /// </summary>
    /// <returns>Representation of operand</returns>
    string StringRespresentation { get; }
}
