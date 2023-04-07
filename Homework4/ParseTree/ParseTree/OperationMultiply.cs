namespace Trees;

public class OperationMultiply: Operation
{
    public override double Calculate()
    {
        return LeftOperand.Calculate() * RightOperand.Calculate();
    }

    public OperationMultiply(IOperand leftOperand, IOperand rightOperand)
        : base(leftOperand, rightOperand, '*')
    {
    }
}