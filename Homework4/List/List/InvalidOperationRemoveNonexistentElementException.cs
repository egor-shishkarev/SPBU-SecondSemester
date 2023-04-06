namespace Lists;

public class InvalidOperationRemoveNonexistentElementException: InvalidOperationException
{
    public InvalidOperationRemoveNonexistentElementException() { }

    public InvalidOperationRemoveNonexistentElementException(string message) : base(message) { }
}
