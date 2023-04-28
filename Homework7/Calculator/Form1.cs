namespace Calculator
{
    public partial class Form1 : Form
    {
        private CalculatorLogic calculatorLogic = new CalculatorLogic();
        public Form1()
        {
            InitializeComponent();

            outputWindow.DataBindings.Add("Text", calculatorLogic, "DisplayValue", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void NumberOrOperationClick(object sender, EventArgs e)
        {

        }
    }
}