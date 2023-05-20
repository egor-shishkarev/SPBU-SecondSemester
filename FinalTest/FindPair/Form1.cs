namespace FindPair
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Logic for game;
        /// </summary>
        Logic logic;

        public int numberOfPairs;
        public Form1(int number)
        {
            numberOfPairs = number;
            logic = new Logic(number);
            InitializeComponent();
        }

        /// <summary>
        /// Event on button click - opening a card.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void On_Click(object sender, EventArgs e)
        {
            logic.OpenCard(sender);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}