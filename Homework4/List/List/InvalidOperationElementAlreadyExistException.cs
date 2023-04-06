namespace Lists;

public class InvalidOperationElementAlreadyExistException: InvalidOperationException
{
    public InvalidOperationElementAlreadyExistException() { }

    public InvalidOperationElementAlreadyExistException(string message) : base(message) { }
}
