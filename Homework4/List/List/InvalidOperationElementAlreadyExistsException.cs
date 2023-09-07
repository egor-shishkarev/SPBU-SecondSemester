namespace Lists;

public class InvalidOperationElementAlreadyExistsException : InvalidOperationException
{
    public InvalidOperationElementAlreadyExistsException() { }

    public InvalidOperationElementAlreadyExistsException(string message) : base(message) { }
}
