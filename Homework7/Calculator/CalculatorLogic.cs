using System.ComponentModel;

namespace Calculator;

public class CalculatorLogic: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private string displayNumber = "0";

    private string systemNumber = "0";

    private char operationSign = ' ';

    private State currentState = State.Number;

    public string DisplayValue 
    { 
        get
        {
            return displayNumber;
        }
        set
        {
            displayNumber = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(displayNumber)));
        }
    }

    private enum State
    {
        Number,
        NumberDot,
        NumberAfterDot,
        Operation,
        Equality,
        Error
    }

    public void ClearDisplay()
    {
        DisplayValue = "0";
        systemNumber = "0";
        operationSign = ' ';
        currentState = State.Number;
    }

    public void AddElement(char element)
    {
        switch (currentState)
        {
            case State.Number:
                {
                    break;
                }
            case State.NumberDot:
                {
                    break;
                }
            case State.NumberAfterDot:
                {
                    break;
                }
            case State.Operation:
                {
                    break;
                }
            case State.Equality:
                {
                    break;
                }
            case State.Error:
                {
                    break;
                }

        }
    }
}
