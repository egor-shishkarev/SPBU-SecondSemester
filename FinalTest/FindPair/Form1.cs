namespace FindPair
{
    public partial class Form1 : Form
    {
        Logic logic;

        public int numberOfPairs;
        public Form1(int number)
        {
            numberOfPairs = number;
            logic = new Logic(number);
            InitializeComponent();
        }

        private void On_Click(object sender, EventArgs e)
        {
            logic.OpenCard(sender);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}