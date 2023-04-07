namespace Trees;

public class OperationAdd: Operation
{
    public override double Calculate()
    {
        return LeftOperand.Calculate() + RightOperand.Calculate();
    }

    public OperationAdd(IOperand leftOperand, IOperand rightOperand)
        : base(leftOperand, rightOperand, '+')
    {
    }

}
