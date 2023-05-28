namespace Calculator;

using System.ComponentModel;

public class CalculatorLogic : INotifyPropertyChanged
{
    /// <summary>
    /// Current display number.
    /// </summary>
    private string displayNumber = "0";

    /// <summary>
    /// Current number in memory.
    /// </summary>
    private string numberInMemory = "0";

    /// <summary>
    /// Current operation sign.
    /// </summary>
    private string operationSign = "";

    /// <summary>
    /// Constant for division.
    /// </summary>
    private readonly float delta = 0.00000001f;

    /// <summary>
    /// Current state of calculator.
    /// </summary>
    private State currentState = State.Number;

    /// <summary>
    /// States for calculator.
    /// </summary>
    enum State
    {
        Number,
        Dot,
        NumberAfterDot,
        Operation,
        Equality,
        Error
    }

    /// <summary>
    /// Event of changing displayNumber.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Main method to add symbols in calculators window.
    /// </summary>
    /// <param name="symbol">Symbol which we want to add.</param>
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
                    try
                    {
                        var tempNumber = DisplayNumber;
                        DisplayNumber = Calculate(numberInMemory, DisplayNumber, operationSign).ToString();
                        numberInMemory = tempNumber;
                    } 
                    catch (DivideByZeroException)
                    {
                        ClearDisplay();
                        DisplayNumber = "Error";
                        currentState = State.Error;
                        break;
                    }
                    currentState = State.Equality;
                }
                if (IsOperation(symbol))
                {
                    try
                    {
                        if (operationSign == "")
                        {
                            operationSign = symbol.ToString();
                            numberInMemory = DisplayNumber;
                        }
                        else
                        {
                            var tempNumber = DisplayNumber;
                            DisplayNumber = Calculate(numberInMemory, DisplayNumber, operationSign).ToString();
                            numberInMemory = tempNumber;
                            operationSign = symbol.ToString();
                        }
                        currentState = State.Operation;
                        break;
                    }
                    catch (DivideByZeroException)
                    {
                        ClearDisplay();
                        DisplayNumber = "Error";
                        currentState = State.Error;
                    }
                    
                }
                if (symbol == ',')
                {
                    currentState = State.Dot;
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
            case State.Dot:
            {
                if (char.IsDigit(symbol))
                {
                    DisplayNumber += symbol;
                    currentState = State.NumberAfterDot;
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
                    try
                    {
                        var tempNumber = DisplayNumber;
                        DisplayNumber = Calculate(numberInMemory, DisplayNumber, operationSign).ToString();
                        numberInMemory = tempNumber;
                        currentState = State.Operation;
                    } 
                    catch (DivideByZeroException) 
                    {
                        ClearDisplay();
                        DisplayNumber = "Error";
                        currentState = State.Error;
                    }
                    break;
                }
                if (IsOperation(symbol))
                {
                    try
                    {
                        if (operationSign == "")
                        {
                            operationSign = symbol.ToString();
                            numberInMemory = DisplayNumber;
                        }
                        else
                        {
                            var tempNumber = DisplayNumber;
                            DisplayNumber = Calculate(numberInMemory, DisplayNumber, operationSign).ToString();
                            numberInMemory = tempNumber;
                            operationSign = symbol.ToString();
                        }
                        currentState = State.Operation;
                    }
                    catch (DivideByZeroException)
                    {
                        ClearDisplay();
                        DisplayNumber = "Error";
                        currentState = State.Error;
                        break;
                    }
                    break;
                }
                if (symbol == '=' && operationSign != "")
                {
                    try
                    {
                        var tempNumber = DisplayNumber;
                        DisplayNumber = Calculate(numberInMemory, DisplayNumber, operationSign).ToString();
                        numberInMemory = tempNumber;
                    }
                    catch (DivideByZeroException)
                    {
                        ClearDisplay();
                        DisplayNumber = "Error";
                        currentState = State.Error;
                        break;
                    }
                    currentState = State.Equality;
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
                        DisplayNumber = Calculate(numberInMemory, DisplayNumber, operationSign).ToString();
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


    /// <summary>
    /// Method to calculate two numbers, represented as a string.
    /// </summary>
    /// <param name="numberOnDisplay">Current number on display.</param>
    /// <param name="numberInMemory">Saved number for future operations.</param>
    /// <param name="operationSign">Sign of the operation.</param>
    /// <returns>Float number - result of operation.</returns>
    /// <exception cref="ArgumentException">String was not a float number.</exception>
    /// <exception cref="DivideByZeroException">Division by zero.</exception>
    /// <exception cref="NotSupportedException">Operation not in -, +, *, /</exception>
    private float Calculate(string numberOnDisplay, string numberInMemory, string operationSign)
    {
        if (!float.TryParse(numberOnDisplay, out float firstNumber))
        {
            throw new ArgumentException("Not a number!");
        }
        if (!float.TryParse(numberInMemory, out float secondNumber))
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

    /// <summary>
    /// The method by which we pass the number to the output.
    /// </summary>
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
        numberInMemory = "0";
        operationSign = "";
        currentState = State.Number;
    }

    /// <summary>
    /// Additional method to check if 
    /// </summary>
    /// <param name="symbol">Symbol which we want to check.</param>
    /// <returns>true - if symbol in -, +, *, /; otherwise - false;</returns>
    private bool IsOperation(char symbol)
    {
        return symbol == '-' || symbol == '+' || symbol == '*' || symbol == '/';
    }
}