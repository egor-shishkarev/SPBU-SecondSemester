namespace Trees;

/// <summary>
/// Class of addition operation.
/// </summary>
public class OperationAdd: Operation
{
    /// <summary>
    /// Calculate - add LeftOperand and RightOperand.
    /// </summary>
    /// <returns></returns>
    public override double Calculate()
    {
        return LeftOperand.Calculate() + RightOperand.Calculate();
    }

    /// <summary>
    /// Create node in tree.
    /// </summary>
    /// <param name="leftOperand">Left node in tree.</param>
    /// <param name="rightOperand">Right node in tree.</param>
    public OperationAdd(IOperand leftOperand, IOperand rightOperand)
        : base(leftOperand, rightOperand, '+')
    {
    }
}
