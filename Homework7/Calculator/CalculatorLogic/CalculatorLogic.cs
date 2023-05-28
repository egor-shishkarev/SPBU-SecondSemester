using System.ComponentModel;

namespace Calculator;

public class CalculatorLogic: INotifyPropertyChanged
{
    private string displayNumber = "0";

    private string numberInMemory = "0";

    private string operationSign = "";

    private readonly float delta = 0.00000001f;

    private State currentState = State.Number;
    enum State
    {
        Number,
        NumberAfterDot,
        Operation,
        Equality,
        Error
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void AddElement(char symbol)
    {
        switch (currentState)
        {
            case State.Number:
            {
                if (char.IsDigit(symbol))
                {
                    if (DisplayNumber == "0" || DisplayNumber == "Error")
                    {
                        DisplayNumber = symbol.ToString();
                    }
                    else
                    {
                        DisplayNumber += symbol;
                    }
                    break;
                }
                if (symbol == '0' && DisplayNumber == "0")
                {
                    break;
                }
                if (symbol == '=' && operationSign != "")
                {
                    var tempNumber = DisplayNumber;
                    DisplayNumber = Calculate(DisplayNumber, numberInMemory, operationSign).ToString();
                    numberInMemory = tempNumber;
                    currentState = State.Number;
                }
                if (IsOperation(symbol))
                {
                    if (operationSign == "")
                    {
                        operationSign = symbol.ToString();
                        numberInMemory = DisplayNumber;
                    }
                    else
                    {
                        DisplayNumber = Calculate(DisplayNumber, numberInMemory, operationSign).ToString();
                        operationSign = symbol.ToString();
                    }
                    currentState = State.Operation;
                    break;
                }
                if (symbol == '.')
                {
                    currentState = State.NumberAfterDot;
                    if (DisplayNumber == "Error")
                    {
                        DisplayNumber = "0,";
                        break;
                    }
                    DisplayNumber += ",";
                    break;
                }
                break;
            }
            case State.NumberAfterDot:
            {
                if (char.IsDigit(symbol))
                {
                    DisplayNumber += symbol;
                    break;
                }
                if (symbol == '=' && operationSign != "")
                {
                    DisplayNumber = Calculate(DisplayNumber, numberInMemory, operationSign).ToString();
                    currentState = State.Number;
                    break;
                }
                if (IsOperation(symbol)) // Тут что?
                {
                    if (operationSign == "")
                    {
                        operationSign = symbol.ToString();
                        numberInMemory = DisplayNumber;
                    }
                    else
                    {
                        DisplayNumber = Calculate(DisplayNumber, numberInMemory, operationSign).ToString();
                        operationSign = symbol.ToString();
                    }
                    currentState = State.Operation;
                    break;
                }
                if (symbol == '=' && operationSign != "")
                {
                    DisplayNumber = Calculate(DisplayNumber, numberInMemory, operationSign).ToString();
                    currentState = State.Number;
                    break;
                }
                break;
            }
            case State.Operation:
                {
                    if (char.IsDigit(symbol))
                    {
                        numberInMemory = DisplayNumber;
                        DisplayNumber = symbol.ToString();
                        currentState = State.Number;
                        break;
                    }
                    if (IsOperation(symbol))
                    {
                        operationSign = symbol.ToString();
                        break;
                    }
                    if (symbol == '=')
                    {
                        try
                        {
                            DisplayNumber = Calculate(DisplayNumber, numberInMemory, operationSign).ToString();
                        } 
                        catch (DivideByZeroException)
                        {
                            ClearDisplay();
                            currentState = State.Error;
                            DisplayNumber = "Error";
                            break;
                        }
                        currentState = State.Equality;
                    }
                    break;
                }
            case State.Equality:
                {
                    if (char.IsDigit(symbol))
                    {
                        numberInMemory = DisplayNumber;
                        DisplayNumber = symbol.ToString();
                        currentState = State.Number;
                        break;
                    }
                    if (IsOperation(symbol))
                    {
                        operationSign = symbol.ToString();
                        //currentState = State.Operation; 
                        break;
                    }
                    if (symbol == '=')
                    {
                        try
                        {
                            DisplayNumber = Calculate(DisplayNumber, numberInMemory, operationSign).ToString();
                        } 
                        catch (DivideByZeroException)
                        {
                            ClearDisplay();
                            currentState = State.Error;
                            DisplayNumber = "Error";
                            break;
                        }
                    }
                    break;
                }
            case State.Error:
                {
                    if (char.IsDigit(symbol))
                    {
                        DisplayNumber = symbol.ToString();
                        numberInMemory = "0";
                        currentState = State.Number;
                    }
                    break;
                }
        }
    }
    
    private float Calculate(string numberOnDisplay, string numberInMemory, string operationSign)
    {
        if (!float.TryParse(numberInMemory, out float firstNumber))
        {
            throw new ArgumentException("Not a number!");
        }
        if (!float.TryParse(numberOnDisplay, out float secondNumber))
        {
            throw new ArgumentException("Not a number!");
        }
        switch (operationSign)
        {
            case "+":
            {
                return firstNumber + secondNumber;
            }
            case "-":
            {
                return firstNumber - secondNumber;
            }
            case "*":
            {
                return firstNumber * secondNumber;
            }
            case "/": 
            {
                if (Math.Abs(secondNumber - 0.0f) < delta)
                {
                    throw new DivideByZeroException("Can't divide by zero!");
                }
                this.numberInMemory = "";
                DisplayNumber = "Error";
                currentState = State.Error;
                return firstNumber / secondNumber;
            }
            default:
            {
                throw new NotSupportedException("Not supported operation!");
            }
        }
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


    /// <summary>
    /// The method that clears the calculator window.
    /// </summary>
    public void ClearDisplay()
    {
        DisplayNumber = "0";
        numberInMemory = "";
        operationSign = "";
        currentState = State.Number;
    }

    private bool IsOperation(char symbol)
    {
        return symbol == '-' || symbol == '+' || symbol == '*' || symbol == '/';
    }
}