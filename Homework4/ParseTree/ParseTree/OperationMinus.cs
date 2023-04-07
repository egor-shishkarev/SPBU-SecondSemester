namespace Trees;

/// <summary>
/// Class of subtraction operation.
/// </summary>
public class OperationMinus: Operation
{
    /// <summary>
    /// Calculate - subtract RightOperand from LeftOperand.
    /// </summary>
    /// <returns></returns>
    public override double Calculate()
    {
        return LeftOperand.Calculate() - RightOperand.Calculate();
    }

    /// <summary>
    /// Create node in tree.
    /// </summary>
    /// <param name="leftOperand">Left node in tree.</param>
    /// <param name="rightOperand">Right node in tree.</param>
    public OperationMinus(IOperand leftOperand, IOperand rightOperand)
        :base(leftOperand, rightOperand, '-')
    {
    }
}
