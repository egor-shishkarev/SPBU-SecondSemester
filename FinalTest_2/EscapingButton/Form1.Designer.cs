namespace EscapingButton
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            currentButton = new Button();
            SuspendLayout();
            // 
            // currentButton
            // 
            currentButton.Location = new Point(725, 375);
            currentButton.MaximumSize = new Size(75, 75);
            currentButton.MinimumSize = new Size(75, 75);
            currentButton.Name = "currentButton";
            currentButton.Size = new Size(75, 75);
            currentButton.TabIndex = 0;
            currentButton.Text = "Tap me";
            currentButton.UseVisualStyleBackColor = true;
            currentButton.Click += currentButton_Click;
            currentButton.MouseEnter += button_MouseHover;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(currentButton);
            Name = "Form1";
            Text = "Escaping Button";
            ResumeLayout(false);
        }

        #endregion

        private Button currentButton;
    }
}