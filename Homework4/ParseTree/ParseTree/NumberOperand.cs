namespace Trees;

/// <summary>
/// Class of node in parse tree, containing integer number.
/// </summary>
public class NumberOperand : IOperand
{
    /// <summary>
    /// Constructor for node.
    /// </summary>
    /// <param name="value">Integer number, that will contain in node.</param>
    public NumberOperand(int value) => Value = value;

    /// <summary>
    /// Integer number, that containg in node.
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// Represent integer number in node as a string.
    /// </summary>
    public string StringRespresentation => Value.ToString();

    /// <summary>
    /// Print to console integer number as a string.
    /// </summary>
    public void Print() => Console.WriteLine(StringRespresentation);

    /// <summary>
    /// Calculate node - in this case just return number.
    /// </summary>
    /// <returns>Number, containing in node.</returns>
    public double Calculate() => Value;
}

