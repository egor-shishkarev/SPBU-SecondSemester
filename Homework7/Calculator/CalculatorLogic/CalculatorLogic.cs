namespace Calculator;

using System.ComponentModel;

public class CalculatorLogic : INotifyPropertyChanged
{
    private string displayNumber = "0";

    private string systemNumber = "0";

    private char operationSign = ' ';

    private State currentState = State.Number;

    private enum State
    {
        Number,
        Operation,
        Equality,
        Error
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void ClearDisplay()
    {
        DisplayNumber = "0";
        systemNumber = "0";
        operationSign = ' ';
        currentState = State.Number;
    }

    public string DisplayNumber
    {
        get
        {
            return displayNumber;
        }

        private set
        {
            displayNumber = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(displayNumber)));
        }
    }


    public void AddElement(char element)
    {
        switch (currentState)
        {
            case State.Number:
                {
                    if (char.IsDigit(element))
                    {
                        if (DisplayNumber == "0" || DisplayNumber == "Error")
                        {
                            DisplayNumber = element.ToString();
                        }
                        else
                        {
                            DisplayNumber += element;
                        }
                        break;
                    }
                    if (IsOperationSign(element))
                    {
                        try
                        {
                            Calculate(element);
                        }
                        catch (DivideByZeroException)
                        {
                            ClearDisplay();
                            currentState = State.Error;
                            DisplayNumber = "Error";
                        }
                        break;
                    }

                    if (operationSign != ' ' || element == '=')
                    {
                        try
                        {
                            CalculateTwoFloatsOnDisplay();
                        }
                        catch (DivideByZeroException)
                        {
                            ClearDisplay();
                            currentState = State.Error;
                            DisplayNumber = "Error";
                            break;
                        }
                        currentState = State.Equality;
                        break;
                    }

                    break;
                }
            case State.Operation:
                {
                    if (IsOperationSign(element))
                    {
                        operationSign = element;
                    }

                    if (element == '=')
                    {
                        try
                        {
                            DisplayNumber = CalculateTwoFloats(systemNumber, DisplayNumber, operationSign);
                        }
                        catch (DivideByZeroException)
                        {
                            ClearDisplay();
                            currentState = State.Error;
                            DisplayNumber = "Error";
                            break;
                        }
                        currentState = State.Equality;
                        break;
                    }

                    if (char.IsDigit(element))
                    {
                        systemNumber = DisplayNumber;
                        DisplayNumber = element.ToString();

                        currentState = State.Number;
                        break;
                    }

                    break;
                }
            case State.Equality:
                {
                    if (element == '=')
                    {
                        try
                        {
                            DisplayNumber = CalculateTwoFloats(DisplayNumber, systemNumber, operationSign);
                        }
                        catch (DivideByZeroException)
                        {
                            ClearDisplay();
                            currentState = State.Error;
                            DisplayNumber = "Error";
                            break;
                        }
                    }

                    if (char.IsDigit(element))
                    {
                        systemNumber = DisplayNumber;
                        DisplayNumber = element.ToString();

                        currentState = State.Number;
                        break;
                    }

                    if (IsOperationSign(element))
                    {
                        operationSign = element;
                        break;
                    }
                    break;
                }
            case State.Error:
                {
                    if (char.IsDigit(element))
                    {
                        systemNumber = "0";
                        DisplayNumber = element.ToString();
                        currentState = State.Number;
                        break;
                    }
                    break;
                }
        }
    }

    private void Calculate(char element)
    {
        if (operationSign == ' ')
        {
            operationSign = element;
            systemNumber = DisplayNumber;
        }
        else
        {
            CalculateTwoFloatsOnDisplay();
            operationSign = element;
        }
        currentState = State.Operation;
    }

    private string CalculateTwoFloats(string firstNumberString, string secondNumberString, char operationSign)
    {
        if (!float.TryParse(firstNumberString, out var firstNumber))
        {
            throw new ArgumentException("Not a float number!", nameof(firstNumberString));
        }
        if (!float.TryParse(secondNumberString, out var secondNumber))
        {
            throw new ArgumentException("Not a float number!", nameof(secondNumberString));
        }

        return DoOperation(firstNumber, secondNumber, operationSign).ToString();
    }

    private void CalculateTwoFloatsOnDisplay()
    {
        var tempValue = DisplayNumber;

        DisplayNumber = CalculateTwoFloats(systemNumber, DisplayNumber, operationSign);

        systemNumber = tempValue;
    }
    private bool IsOperationSign(char symbol)
    {
        return symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';
    }

    private float DoOperation(float firstNumber, float secondNumber, char operationSign)
    {
        switch (operationSign)
        {
            case '+':
                return firstNumber + secondNumber;

            case '-':
                return firstNumber - secondNumber;

            case '*':
                return firstNumber * secondNumber;

            case '/':
                if (Math.Abs(secondNumber - 0.0F) < 0.00001F)
                {
                    throw new DivideByZeroException(nameof(secondNumber));
                }
                return firstNumber / secondNumber;
            default:
                throw new ArgumentException("Not operation sign!");
        }
    }
}
