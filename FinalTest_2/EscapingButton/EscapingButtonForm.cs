namespace EscapingButton
{
    using ButtonLogic;

    public partial class EscapingButtonForm : Form
    {
        public EscapingButtonForm()
        {
            InitializeComponent();
        }

        private void button_MouseHover(object sender, EventArgs e)
        {
            var _sender = sender as Button;
            var currentPosition = _sender.Location;
            _sender.Location = ButtonLogic.MoveButton(currentPosition);
        }

        private void currentButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}