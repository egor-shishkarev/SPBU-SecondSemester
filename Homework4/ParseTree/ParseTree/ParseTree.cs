namespace Trees;

public class ParseTree
{
    private readonly IOperand head;
    public ParseTree(string expression)
    {
        
    }

    public float Calculate()
    {
        return 0f;
    }

    public string StringRepresentation => head.StringRepresentation;

    public void Print() => head.Print();
}
