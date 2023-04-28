using System.ComponentModel;

namespace Calculator;

public class CalculatorLogic: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private string displayNumber = "0";
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
}
