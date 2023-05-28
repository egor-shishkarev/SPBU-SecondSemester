namespace Trees;

public abstract class Operation: IOperand
{

    public Operation(string operationSign, Operand leftOperand, Operand rightOperand)
    {
        ArgumentException.ThrowIfNullOrEmpty(operationSign, nameof(operationSign));
        OperationSign = operationSign;
        LeftOperand = leftOperand ?? throw new ArgumentNullException(nameof(leftOperand));
        RightOperand = rightOperand ?? throw new ArgumentNullException(nameof(rightOperand));
    }

    public abstract float Calculate();

    public Operand LeftOperand { get; }

    public Operand RightOperand { get; }

    public string OperationSign { get; }

    public string StringRepresentation => $"({OperationSign} {LeftOperand.StringRepresentation} {RightOperand.StringRepresentation})";

    public void Print() => Console.Write(StringRepresentation);
}
