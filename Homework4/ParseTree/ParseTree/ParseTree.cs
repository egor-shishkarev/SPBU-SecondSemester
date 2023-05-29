namespace Trees;

using System.Text;

/// <summary>
/// Class of parse tree, which respresents expression in tree, can print and calculate it.
/// </summary>
public class ParseTree
{
    /// <summary>
    /// Main operand in tree.
    /// </summary>
    private readonly IOperand head;

    /// <summary>
    /// Constructor for parse tree.
    /// </summary>
    /// <param name="expression">Expression - {sign {operand1} {operand2}}, where operands can be as expression.</param>
    /// <exception cref="ArgumentException">Wrong parenthesis balance.</exception>
    public ParseTree(string expression)
    {
        ArgumentException.ThrowIfNullOrEmpty(expression);
        int currentIndex = 0;
        if (!AreParenthesesBalanced(expression))
        {
            throw new ArgumentException("Wrong parenthesis balance!");
        }
        head = CreateNewNode(expression, ref currentIndex);
    }

    /// <summary>
    /// Creates a new operand in parse tree.
    /// </summary>
    /// <param name="expression">Expression which we want to represent in tree.</param>
    /// <param name="currentIndex">Index in expression.</param>
    /// <returns>Operand.</returns>
    /// <exception cref="ArgumentException">Wrong expression.</exception>
    private IOperand CreateNewNode(string expression, ref int currentIndex)
    {
        if (expression[currentIndex] != '(')
        {
            throw new ArgumentException("Incorrect placement of parenthesis!");
        }
        ++currentIndex;
        IsInRange(expression, currentIndex);
        var operationSign = expression[currentIndex];
        if (!IsOperation(operationSign))
        {
            throw new ArgumentException("This symbol is not an operation!");
        }
        ++currentIndex;
        IsInRange(expression, currentIndex);
        if (expression[currentIndex] != ' ')
        {
            throw new ArgumentException("There is no space between the operation and the operand!");
        }
        ++currentIndex;
        IsInRange(expression, currentIndex);
        var operation = CreateNewOperation(expression, operationSign, ref currentIndex);

        ++currentIndex;
        return operation;
    }

    /// <summary>
    /// Create new operation - {sign {operand1} {operand2}}
    /// </summary>
    /// <param name="expression">Expression, which we want to represent in tree.</param>
    /// <param name="operationSign">Sign of operation.</param>
    /// <param name="currentIndex">Index in expression.</param>
    /// <returns>Operation instance.</returns>
    /// <exception cref="ArgumentException">Not supported operation sign.</exception>
    private Operation CreateNewOperation(string expression, char operationSign, ref int currentIndex)
    {
        return operationSign switch
        {
            '+' => new OperationAdd(CreateOperand(expression, ref currentIndex), CreateOperand(expression, ref currentIndex)),
            '-' => new OperationMinus(CreateOperand(expression, ref currentIndex), CreateOperand(expression, ref currentIndex)),
            '*' => new OperationMultiply(CreateOperand(expression, ref currentIndex), CreateOperand(expression, ref currentIndex)),
            '/' => new OperationDivide(CreateOperand(expression, ref currentIndex), CreateOperand(expression, ref currentIndex)),
            _ => throw new ArgumentException("Not supported operation sign."),
        };
    }

    /// <summary>
    /// Create new operand for operation.
    /// </summary>
    /// <param name="expression">Expression, which we want to represent in tree.</param>
    /// <param name="currentIndex">Index in expression.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">Wrong expression.</exception>
    private IOperand CreateOperand(string expression, ref int currentIndex)
    {
        if (expression.Length - 1 <= currentIndex)
        {
            throw new ArgumentException("Wrong expression");
        }
        if (expression[currentIndex] == '(')
        {
            return CreateNewNode(expression, ref currentIndex);
        }
        else
        {
            var stringNumber = new StringBuilder();
            while (expression[currentIndex] != ' ' && expression[currentIndex] != ')')
            {
                stringNumber.Append(expression[currentIndex]);
                currentIndex++;
            }
            if (!int.TryParse(stringNumber.ToString(), out int number))
            {
                throw new ArgumentException("Not supported symbol!");
            }
            ++currentIndex;
            return new Operand(number);
        }
    }

    /// <summary>
    /// Calculate parse tree.
    /// </summary>
    /// <returns>Float number - result of calculation.</returns>
    public float Calculate() => head.Calculate();

    /// <summary>
    /// Returns representation of tree.
    /// </summary>
    public string StringRepresentation => head.StringRepresentation;

    /// <summary>
    /// Print representation of tree in console.
    /// </summary>
    public void Print() => head.Print();

    /// <summary>
    /// Additional method to check if we still in range of expression.
    /// </summary>
    /// <param name="expression">Expression, which we want to represent in tree.</param>
    /// <param name="index">Index in expression.</param>
    /// <exception cref="ArgumentException">Went beyond expression.</exception>
    private static void IsInRange(string expression, int index)
    {
        if (expression.Length - 1 < index)
        {
            throw new ArgumentException("Incorrectly constructed expression!");
        }
    }

    /// <summary>
    /// Additional method to check if symbol is operation.
    /// </summary>
    /// <param name="symbol">Symbol, which we want to check.</param>
    /// <returns>True - if symbol is +, -, *, /; otherwise - false.</returns>
    private static bool IsOperation(char symbol)
    {
        return symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';
    }

    /// <summary>
    /// Method to check balance of parenthesis. For example (()) - right, (() - wrong.
    /// </summary>
    /// <param name="expression">Expression, which we want to represent in tree.</param>
    /// <returns>True - balance is maintained; otherwise - false;</returns>
    private static bool AreParenthesesBalanced(string expression)
    {
        var summOfParanthesis = 0;
        for (int i = 0; i < expression.Length; ++i)
        {
            if (expression[i] == '(')
            {
                ++summOfParanthesis;
                continue;
            }
            if (expression[i] == ')')
            {
                --summOfParanthesis;
                continue;
            }
        }
        return summOfParanthesis == 0;
    }
}
