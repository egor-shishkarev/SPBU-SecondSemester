namespace Trees;

/// <summary>
/// Class of multiplication operation.
/// </summary>
public class OperationMultiply: Operation
{
    /// <summary>
    /// Calculate - multiply LeftOperand on RightOperand.
    /// </summary>
    /// <returns></returns>
    public override double Calculate()
    {
        return LeftOperand.Calculate() * RightOperand.Calculate();
    }

    /// <summary>
    /// Create node in tree.
    /// </summary>
    /// <param name="leftOperand">Left node in tree.</param>
    /// <param name="rightOperand">Right node in tree.</param>
    public OperationMultiply(IOperand leftOperand, IOperand rightOperand)
        : base(leftOperand, rightOperand, '*')
    {
    }
}