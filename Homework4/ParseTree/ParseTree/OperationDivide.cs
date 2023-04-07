namespace Trees;

/// <summary>
/// Class of division operation.
/// </summary>
public class OperationDivide : Operation
{
    /// <summary>
    /// Calculate - divide LeftOperand on RightOperand.
    /// </summary>
    /// <returns></returns>
    public override double Calculate()
    {
        var rightOperandValue = RightOperand.Calculate();
        const double delta = 0.00001F;
        if (Math.Abs(rightOperandValue - 0.0F) < delta)
        {
            throw new DivideByZeroException();
        }
        return LeftOperand.Calculate() / RightOperand.Calculate();
    }

    /// <summary>
    /// Create node in tree.
    /// </summary>
    /// <param name="leftOperand">Left node in tree.</param>
    /// <param name="rightOperand">Right node in tree.</param>
    public OperationDivide(IOperand leftOperand, IOperand rightOperand)
        : base(leftOperand, rightOperand, '/')
    {
    }
}