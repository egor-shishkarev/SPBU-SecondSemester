namespace Trees;

public class OperationMinus: Operation
{
    public override double Calculate()
    {
        return LeftOperand.Calculate() - RightOperand.Calculate();
    }

    public OperationMinus(IOperand leftOperand, IOperand rightOperand)
        :base(leftOperand, rightOperand, '-')
    {
    }
}
