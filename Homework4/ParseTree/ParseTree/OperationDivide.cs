namespace Trees;

public class OperationDivide: Operation
{
    private readonly float delta = 0.0001f;

    /// <summary>
    /// Create a new instance of OperationDivide class.
    /// </summary>
    /// <param name="leftOperand">Left operand in parse tree.</param>
    /// <param name="rightOperand">Right operand in parse tree.</param>
    public OperationDivide(Operand leftOperand, Operand rightOperand)
        :base("/", leftOperand, rightOperand)
    {
    }

    /// <summary>
    /// Method, that calculates operand with addition.
    /// </summary>
    /// <returns>Float value - result of addition.</returns>
    public override float Calculate()
    {
        var leftOperandResult = LeftOperand.Calculate();
        var rightOperandResult = RightOperand.Calculate();
        if ((rightOperandResult - 0.0f) < delta)
        {
            throw new DivideByZeroException("Can't divide by zero!");
        }
        return leftOperandResult / (float) rightOperandResult;
    }
}
