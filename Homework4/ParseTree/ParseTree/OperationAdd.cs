namespace Trees;

public class OperationAdd: Operation
{
    /// <summary>
    /// Create a new instance of OperationAdd class.
    /// </summary>
    /// <param name="leftOperand">Left operand in parse tree.</param>
    /// <param name="rightOperand">Right operand in parse tree.</param>
    public OperationAdd(Operand leftOperand, Operand rightOperand)
        :base("+", leftOperand, rightOperand)
    { 
    }

    /// <summary>
    /// Method, that calculates operand with addition.
    /// </summary>
    /// <returns>Float value - result of addition.</returns>
    public override float Calculate()
    {
        return (float)LeftOperand.Calculate() + (float)RightOperand.Calculate();
    }
}
