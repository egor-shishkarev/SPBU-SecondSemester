namespace Trees;

public class Operand: IOperand
{
    public Operand(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public string StringRepresentation => Value.ToString();

    public float Calculate()
    {
        return Value;
    }

    public void Print() => Console.Write(StringRepresentation);
}
