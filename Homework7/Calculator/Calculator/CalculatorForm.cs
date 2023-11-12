namespace Calculator;

/// <summary>
/// Form of calculator.
/// </summary>
public partial class CalculatorForm : Form
{
    /// <summary>
    /// Instance of caluclator logic class.
    /// </summary>
    private readonly CalculatorLogic calculatorLogic = new();

    /// <summary>
    /// Create a new Form.
    /// </summary>
    public CalculatorForm()
    {
        InitializeComponent();

        OutputWindow.DataBindings.Add("Text", calculatorLogic, "DisplayNumber", true, DataSourceUpdateMode.OnPropertyChanged);
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Event of delete button click.
    /// </summary>
    /// <param name="sender">Who sends, in our case it may be a Form, or a Button.</param>
    /// <param name="e">Event arguments.</param>
    private void DeleteButton_Click(object sender, EventArgs e)
    {
        calculatorLogic.ClearDisplay();
    }

    /// <summary>
    /// Event on clicking button except delete button.
    /// </summary>
    /// <param name="sender">Who sends, in our case a Button.</param>
    /// <param name="e">Event arguments.</param>
    private void NumberOrOperationClick(object sender, EventArgs e)
    {
        var _sender = sender as Button;
        calculatorLogic.AddElement(_sender!.Text.First());
    }
}