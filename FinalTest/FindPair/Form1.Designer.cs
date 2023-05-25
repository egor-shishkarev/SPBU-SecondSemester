using System.Windows.Forms;

namespace FindPair
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            int numberOfPairs = this.numberOfPairs;
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(50 * numberOfPairs, 50 * numberOfPairs);
            this.Text = "FindPair";
            var arrayOfButtons = new List<Button>();
            for (int i = 0; i < numberOfPairs * numberOfPairs; ++i)
            {
                arrayOfButtons.Add(new Button());
            }
            for (int i = 0; i < numberOfPairs; ++i)
            {
                for (int j = 0; j < numberOfPairs; ++j)
                {
                    var currentButton = arrayOfButtons[numberOfPairs * j + i];
                    currentButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                    currentButton.Location = new Point(i * 50, j * 50);
                    currentButton.Name = "Number1";
                    currentButton.Size = new Size(50, 50);
                    currentButton.TabIndex = numberOfPairs * j + i;
                    currentButton.UseVisualStyleBackColor = true;
                    currentButton.Click += On_Click;
                }
            }
            for (int i = 0; i < numberOfPairs * numberOfPairs; ++i)
            {
                Controls.Add(arrayOfButtons[i]);
            }
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
