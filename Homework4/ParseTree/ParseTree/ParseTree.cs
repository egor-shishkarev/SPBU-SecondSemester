namespace Trees;

using System.Text;

/// <summary>
/// Class of Parse Tree for calculating expressions.
/// </summary>
public class ParseTree
{
    /// <summary>
    /// Main node in tree.
    /// </summary>
    private readonly IOperand root;

    /// <summary>
    /// Contructor of Parse Tree.
    /// </summary>
    /// <param name="expression">Expression as a string that we want to calculate.</param>
    /// <exception cref="ArgumentException">Wrong balance of brackets in expression.</exception>
    public ParseTree(string expression)
    {
        if (!BracketsBalance(expression))
        {
            throw new ArgumentException("Incorrect position or number of brackets", nameof(expression));
        }
        var currentIndex = 0;
        root = ParseExpression(expression, ref currentIndex);
    }

    /// <summary>
    /// Parsing expressions in smaller operands.
    /// </summary>
    /// <param name="expression">Expression as a string that we want to calculate.</param>
    /// <param name="currentIndex">Current index in expression.</param>
    /// <returns>Operand, that we parse.</returns>
    /// <exception cref="ArgumentException">Wrong symbol or it's position in expression.</exception>
    private IOperand ParseExpression(string expression, ref int currentIndex)
    {
        if (expression[currentIndex] != '(')
        {
            throw new ArgumentException("Open bracket is not contain");
        }
        ++currentIndex;
        var operationSign = expression[currentIndex];
        if (!IsOperation(operationSign))
        {
            throw new ArgumentException("Unexpected operation");
        }
        currentIndex += 2;
        var newOperation = CreateOperation(expression, ref currentIndex, operationSign);
        if (currentIndex < expression.Length && expression[currentIndex] != ' ' && expression[currentIndex] != ')')
        {
            throw new ArgumentException("Incorrect symbol");
        }
        ++currentIndex;
        return newOperation;
    }

    /// <summary>
    /// Create operation node.
    /// </summary>
    /// <param name="expression">Expression as a string that we want to calculate.</param>
    /// <param name="currentIndex">Current index in expression.</param>
    /// <param name="operationSign">Operation sign in expression.</param>
    /// <returns>Operation node.</returns>
    /// <exception cref="ArgumentException">Wrong operation sign.</exception>
    private Operation CreateOperation(string expression, ref int currentIndex, char operationSign)
    {
        return operationSign switch
        {
            '+' => new OperationAdd(CreateOperand(expression, ref currentIndex), CreateOperand(expression, ref currentIndex)),
            '-' => new OperationMinus(CreateOperand(expression, ref currentIndex), CreateOperand(expression, ref currentIndex)),
            '*' => new OperationMultiply(CreateOperand(expression, ref currentIndex), CreateOperand(expression, ref currentIndex)),
            '/' => new OperationDivide(CreateOperand(expression, ref currentIndex), CreateOperand(expression, ref currentIndex)),
            _ => throw new ArgumentException("This is not an operation sign", nameof(operationSign)),
        };
    }

    /// <summary>
    /// Create operand node.
    /// </summary>
    /// <param name="expression">Expression as a string that we want to calculate.</param>
    /// <param name="currentIndex">Current index in expression.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException">Current index was out of range.</exception>
    /// <exception cref="ArgumentException">Substring was not a number.</exception>
    private IOperand CreateOperand(string expression, ref int currentIndex)
    {
        if (currentIndex >= expression.Length || currentIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(currentIndex));
        }
        if (expression[currentIndex] == '(')
        {
            return ParseExpression(expression, ref currentIndex);
        }

        var stringNumber = new StringBuilder();

        while (expression[currentIndex] != ' ' && expression[currentIndex] != ')')
        {
            stringNumber.Append(expression[currentIndex]);
            ++currentIndex;
        }
        if (!int.TryParse(stringNumber.ToString(), out int number))
        {
            throw new ArgumentException("It is not a number");
        }
        ++currentIndex;
        return new NumberOperand(number);
    }
 
    /// <summary>
    /// Returns a representation of expression in tree.
    /// </summary>
    public string StringRepresentation => root.StringRespresentation;

    /// <summary>
    /// Print to console representation of tree.
    /// </summary>
    public void Print() => Console.WriteLine(StringRepresentation);

    /// <summary>
    /// Return result of calculating expression in tree.
    /// </summary>
    /// <returns>Result of expression.</returns>
    public double Calculate() => root.Calculate();

    /// <summary>
    /// Additional method to check brackets balance in expression.
    /// </summary>
    /// <param name="expression">Expression as a string that we want to calculate.</param>
    /// <returns>True - if balance is normal, False - otherwise.</returns>
    public static bool BracketsBalance(string expression)
    {
        var bracketsBalance = 0;
        for (int i = 0; i < expression.Length; ++i)
        {
            if (expression[i] == '(')
            {
                ++bracketsBalance;
            } else if (expression[i] == ')')
            {
                --bracketsBalance;
            }
            if (bracketsBalance < 0)
            {
                return false;
            }
        }
        return bracketsBalance == 0;
    }

    /// <summary>
    /// Additional method to check if the symbol is operation sign.
    /// </summary>
    /// <param name="symbol">Symbol, that we want to check.</param>
    /// <returns>True - if symbol is +,-,* or /, False - otherwise.</returns>
    private static bool IsOperation(char symbol)
    {
        return symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';
    }
}