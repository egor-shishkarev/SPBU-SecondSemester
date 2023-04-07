using System.Text;

namespace Trees;

public class ParseTree
{
    private readonly IOperand root;

    public ParseTree(string expression)
    {
        if (!BracketsBalance(expression))
        {
            throw new ArgumentException("Incorrect position or number of brackets", nameof(expression));
        }
        var currentIndex = 0;
        root = ParseExpression(expression, ref currentIndex);
    }

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
            throw new ArgumentException("Wrong position of operation");
        }
        currentIndex += 2;
        var newOperation = CreateOperation(expression, ref currentIndex, operationSign);
        if (expression[currentIndex] != ' ' && expression[currentIndex] != ')')
        {
            throw new ArgumentException("Incorrect symbol");
        }
        ++currentIndex;
        return newOperation;
    }

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
 
    public string StringRepresentation => root.StringRespresentation;

    public void Print() => Console.WriteLine(StringRepresentation);

    public double Calculate() => root.Calculate();

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

    private static bool IsOperation(char symbol)
    {
        return symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';
    }
}