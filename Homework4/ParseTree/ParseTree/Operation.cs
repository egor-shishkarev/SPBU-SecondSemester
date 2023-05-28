namespace Trees;

/// <summary>
/// Abstract class for all operation.
/// </summary>
public abstract class Operation: IOperand
{
    /// <summary>
    /// Create a new operation node with operation sign, left operand and right operand.
    /// </summary>
    /// <param name="operationSign">Sign of operation.</param>
    /// <param name="leftOperand">Left operand in parse tree.</param>
    /// <param name="rightOperand">Right operand in parse tree.</param>
    /// <exception cref="ArgumentNullException">Left operand or Right operand were null.</exception>
    public Operation(string operationSign, IOperand leftOperand, IOperand rightOperand)
    {
        ArgumentException.ThrowIfNullOrEmpty(operationSign, nameof(operationSign));
        OperationSign = operationSign;
        LeftOperand = leftOperand ?? throw new ArgumentNullException(nameof(leftOperand));
        RightOperand = rightOperand ?? throw new ArgumentNullException(nameof(rightOperand));
    }

    /// <summary>
    /// Abstract method to calculate operation - ({sign} {operand1} {operand2})
    /// </summary>
    /// <returns>Float number - result of calculation.</returns>
    public abstract float Calculate();

    /// <summary>
    /// Left operand in parse tree.
    /// </summary>
    public IOperand LeftOperand { get; }

    /// <summary>
    /// Right operand in parse tree.
    /// </summary>
    public IOperand RightOperand { get; }

    /// <summary>
    /// Sign of operation.
    /// </summary>
    public string OperationSign { get; }

    /// <summary>
    /// Returns a representation of operand.
    /// </summary>
    public string StringRepresentation => $"({OperationSign} {LeftOperand.StringRepresentation} {RightOperand.StringRepresentation})";

    /// <summary>
    /// Print string representation to console.
    /// </summary>
    public void Print() => Console.Write(StringRepresentation);
}
