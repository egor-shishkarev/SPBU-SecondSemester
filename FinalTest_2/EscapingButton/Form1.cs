namespace EscapingButton
{
    using ButtonLogic;

    public partial class Form1 : Form
    {
        ButtonLogic buttonLogic = new ButtonLogic();
        public Form1()
        {
            InitializeComponent();
        }

        private void button_MouseHover(object sender, EventArgs e)
        {
            var _sender = sender as Button;
            var currentPosition = _sender.Location;
            _sender.Location = buttonLogic.MoveButton(currentPosition);
        }

        private void currentButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}