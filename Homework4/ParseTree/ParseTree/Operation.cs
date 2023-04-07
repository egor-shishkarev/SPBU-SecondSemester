namespace Trees;

/// <summary>
/// Abstract class for operaions such as addition, subtraction, multiplication and division.
/// </summary>
public abstract class Operation: IOperand
{
    /// <summary>
    /// Left node in tree.
    /// </summary>
    public IOperand LeftOperand { get; }

    /// <summary>
    /// Right node in tree.
    /// </summary>
    public IOperand RightOperand { get; }

    /// <summary>
    /// Sign of operation - +, -, * or /
    /// </summary>
    public char OperationSign { get; }

    /// <summary>
    /// Constructor for operation node.
    /// </summary>
    /// <param name="leftOperand">Left node in tree.</param>
    /// <param name="rightOperand">Right node in tree</param>
    /// <param name="operationSign">Sign of operation.</param>
    public Operation(IOperand leftOperand, IOperand rightOperand, char operationSign)
    {
        LeftOperand = leftOperand;
        RightOperand = rightOperand;
        OperationSign = operationSign;
    }

    /// <summary>
    /// Represents current node as a string.
    /// </summary>
    public string StringRespresentation
        => $"({OperationSign} {LeftOperand.StringRespresentation} {RightOperand.StringRespresentation})";

    /// <summary>
    /// Calculate the expression containing in node.
    /// </summary>
    /// <returns>Double number - result of calculating.</returns>
    public abstract double Calculate();

    /// <summary>
    /// Print to console expression as a string.
    /// </summary>
    public void Print()
        => Console.WriteLine(StringRespresentation);

}
