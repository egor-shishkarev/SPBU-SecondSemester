namespace StackCalculatorClass;

/// <summary>
/// Class of calculator for postfix expression.
/// </summary>
public class StackCalculator
{
    /// <summary>
    /// Interface of stack
    /// </summary>
    private readonly IStack stackCalculator;


    /// <summary>
    /// Constructor of stack calculator.
    /// </summary>
    /// <param name="stack"></param>
    public StackCalculator(IStack stack)
    {
        stackCalculator = stack;
    }

    /// <summary>
    /// Main method to calculate exepression.
    /// </summary>
    /// <param name="expression">String, that we want to calculate.</param>
    /// <returns>(..., false) - if in expression was division by zero, (result of exepression, true) - if all was right.</returns>
    /// <exception cref="ArgumentNullException">Expression is null</exception>
    /// <exception cref="ArgumentException">EXpression is empty</exception>
    /// <exception cref="InvalidOperationException">Can't pop from empty stack</exception>
    public (float result, bool notDivisionByZero) CalculateExpression(string expression)
    {
        if (expression == null) 
        {
            throw new ArgumentNullException("Expression to convert is null");
        }

        if (string.IsNullOrEmpty(expression))
        {
            throw new ArgumentException("Expression is empty");
        }

        var splittedString = expression.Split();
        foreach (var item in splittedString)
        {
            if (IsOperation(item))
            {
                float firstElement;
                float secondElement;
                try
                {
                    secondElement = stackCalculator.Pop();
                    firstElement = stackCalculator.Pop();
                }
                catch
                {
                    throw new InvalidOperationException("Can't pop from empty stack!");
                }
                float result;
                switch (item)
                {
                    case "+":
                        {
                            result = firstElement + secondElement;
                            break;
                        }
                    case "-":
                        {
                            result = firstElement - secondElement;
                            break;
                        }
                    case "*":
                        {
                            result = firstElement * secondElement;
                            break;
                        }
                    case "/":
                        {
                            const float delta = 0.00001F;
                            if (Math.Abs(secondElement - 0.0F) < delta)
                            {
                                return (0.0F, false);
                            }
                            result = firstElement / secondElement;
                            break;
                        } 
                    default:
                        {
                            throw new ArgumentException("Unexpected operation!");
                        }
                }
                stackCalculator.Push(result);
            } 
            else
            {
                float newElement;
                if (!float.TryParse(item, out newElement))
                {
                    throw new ArgumentException("Unexpected symbol!");
                }
                stackCalculator.Push(newElement);
            }
        }
        float resultOfExpression;
        try
        {
            resultOfExpression = stackCalculator.Pop();
        }
        catch
        {
            throw new InvalidOperationException("Can't pop from empty stack!");
        }

        if (!stackCalculator.IsEmpty())
        {
            throw new ArgumentException("Wrong exception!");
        }

        return (resultOfExpression, true);
    }

    /// <summary>
    /// Method, that checks if the first symbol in string is operator.
    /// </summary>
    /// <param name="element">String, that we want check.</param>
    /// <returns>True - if first element in string was +, -, * or /, Fasle - otherwise.</returns>
    private bool IsOperation(string element)
    {
        return element[0] == '+' || element[0] == '-' || element[0] == '*' || element[0] == '/';
    }
}