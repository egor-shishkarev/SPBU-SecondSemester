namespace Trees;

public class NumberOperand : IOperand
{
    public NumberOperand(int value) => Value = value;

    public int Value { get; set; }

    public string StringRespresentation => Value.ToString();

    public void Print() => Console.WriteLine(StringRespresentation);

    public double Calculate() => Value;
}

