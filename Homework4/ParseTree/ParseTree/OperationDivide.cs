namespace Trees;

public class OperationDivide : Operation
{
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

    public OperationDivide(IOperand leftOperand, IOperand rightOperand)
        : base(leftOperand, rightOperand, '/')
    {
    }
}