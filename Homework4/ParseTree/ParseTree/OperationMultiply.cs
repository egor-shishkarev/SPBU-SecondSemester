namespace Trees;

public class OperationMultiply : Operation
{
    /// <summary>
    /// Create a new instance of OperationMultiply class.
    /// </summary>
    /// <param name="leftOperand">Left operand in parse tree.</param>
    /// <param name="rightOperand">Right operand in parse tree.</param>
    public OperationMultiply(IOperand leftOperand, IOperand rightOperand)
            :base("*", leftOperand, rightOperand)
    {
    }

    /// <summary>
    /// Method, that calculates operand with multiplication.
    /// </summary>
    /// <returns>Float value - result of multiplication.</returns>
    public override float Calculate()
    {
        return (float)LeftOperand.Calculate() * (float)RightOperand.Calculate();
    }
}
