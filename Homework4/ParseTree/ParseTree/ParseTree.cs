using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace Trees;

public class ParseTree
{
    private readonly IOperand head;

    public ParseTree(string expression)
    {
        ArgumentException.ThrowIfNullOrEmpty(expression);
        int currentIndex = 0;
        head = CreateNewNode(expression, ref currentIndex);
        
    }

    private IOperand CreateNewNode(string expression, ref int currentIndex)
    {
        while (true)
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
            

        }

    }

    private Operation CreateNewOperation(string expression, char operationSign, ref int currentIndex)
    {
        switch (operationSign)
        {
            case '+': return new OperationAdd();
        }
    }

    private Operand CreateOperand(string expression, ref int currentIndex)
    {

    }

    public float Calculate() => head.Calculate();

    public string StringRepresentation => head.StringRepresentation;

    public void Print() => head.Print();

    private void IsInRange(string expression, int index)
    {
        if (expression.Length - 1 < index)
        {
            throw new ArgumentException("Incorrectly constructed expression!");
        }
    }

    private bool IsOperation(char symbol)
    {
        return symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';
    }
}
