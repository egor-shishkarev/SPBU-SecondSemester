namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        private readonly CalculatorLogic calculatorLogic = new();
        public CalculatorForm()
        {
            InitializeComponent();

            OutputWindow.DataBindings.Add("Text", calculatorLogic, "DisplayNumber", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            calculatorLogic.ClearDisplay();
        }

        private void NumberOrOperationClick(object sender, EventArgs e)
        {
            var _sender = sender as Button;
            calculatorLogic.AddElement(_sender!.Text.First());
        }
    }
}