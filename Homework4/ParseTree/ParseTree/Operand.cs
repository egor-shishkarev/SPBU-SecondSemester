using System.Globalization;

namespace Trees;

/// <summary>
/// Number operand in parse tree - {124} for example
/// </summary>
public class Operand: IOperand
{
    /// <summary>
    /// Constructor for operand.
    /// </summary>
    /// <param name="value"></param>
    public Operand(int value)
    {
        Value = value;
    }

    /// <summary>
    /// Number of operand.
    /// </summary>
    public int Value { get; }

    /// <summary>
    /// Change int number to string for console output.
    /// </summary>
    public string StringRepresentation => Value.ToString("G", NumberFormatInfo.CurrentInfo);

    /// <summary>
    /// Just return number.
    /// </summary>
    /// <returns>Float number - value of operand.</returns>
    public float Calculate()
    {
        return Value;
    }

    /// <summary>
    /// Print string representation to console.
    /// </summary>
    public void Print() => Console.Write(StringRepresentation);
}
