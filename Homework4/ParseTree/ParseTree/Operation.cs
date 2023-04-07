namespace Trees;
public abstract class Operation: IOperand
{
    public IOperand RightOperand { get; }

    public IOperand LeftOperand { get; }

    public char OperationSign { get; }

    public Operation(IOperand rightOperand, IOperand leftOperand, char operationSign)
    {
        RightOperand = rightOperand;
        LeftOperand = leftOperand;
        OperationSign = operationSign;
    }

    public string StringRespresentation
        => $"({OperationSign} {LeftOperand.StringRespresentation} {RightOperand.StringRespresentation})";

    public abstract double Calculate();

    public void Print()
        => Console.WriteLine(StringRespresentation);

}
