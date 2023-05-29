namespace Trees;

public class OperationMinus : Operation
{
    /// <summary>
    /// Create a new instance of OperationMinus class.
    /// </summary>
    /// <param name="leftOperand">Left operand in parse tree.</param>
    /// <param name="rightOperand">Right operand in parse tree.</param>
    public OperationMinus(IOperand leftOperand, IOperand rightOperand)
            :base("-", leftOperand, rightOperand)
    {
    }

    /// <summary>
    /// Method, that calculates operand with subtraction.
    /// </summary>
    /// <returns>Float value - result of subtraction.</returns>
    public override float Calculate()
    {
        return (float)LeftOperand.Calculate() - (float)RightOperand.Calculate();
    }
}
