namespace Calculator
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
            Number1 = new Button();
            Number2 = new Button();
            Number3 = new Button();
            Number4 = new Button();
            Number5 = new Button();
            Number6 = new Button();
            Number7 = new Button();
            Number8 = new Button();
            Number9 = new Button();
            Number0 = new Button();
            PlusButton = new Button();
            MinusButton = new Button();
            MultiplyButton = new Button();
            DivisionButton = new Button();
            DeleteButton = new Button();
            EqualButton = new Button();
            OutputWindow = new TextBox();
            DotButton = new Button();
            SuspendLayout();
            // 
            // Number1
            // 
            Number1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Number1.Location = new Point(12, 156);
            Number1.Name = "Number1";
            Number1.Size = new Size(80, 80);
            Number1.TabIndex = 1;
            Number1.Text = "1";
            Number1.UseVisualStyleBackColor = true;
            Number1.Click += NumberOrOperationClick;
            // 
            // Number2
            // 
            Number2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Number2.Location = new Point(98, 156);
            Number2.Name = "Number2";
            Number2.Size = new Size(80, 80);
            Number2.TabIndex = 2;
            Number2.Text = "2";
            Number2.UseVisualStyleBackColor = true;
            Number2.Click += NumberOrOperationClick;
            // 
            // Number3
            // 
            Number3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Number3.Location = new Point(184, 156);
            Number3.Name = "Number3";
            Number3.Size = new Size(80, 80);
            Number3.TabIndex = 3;
            Number3.Text = "3";
            Number3.UseVisualStyleBackColor = true;
            Number3.Click += NumberOrOperationClick;
            // 
            // Number4
            // 
            Number4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Number4.Location = new Point(12, 242);
            Number4.Name = "Number4";
            Number4.Size = new Size(80, 80);
            Number4.TabIndex = 4;
            Number4.Text = "4";
            Number4.UseVisualStyleBackColor = true;
            Number4.Click += NumberOrOperationClick;
            // 
            // Number5
            // 
            Number5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Number5.Location = new Point(98, 242);
            Number5.Name = "Number5";
            Number5.Size = new Size(80, 80);
            Number5.TabIndex = 5;
            Number5.Text = "5";
            Number5.UseVisualStyleBackColor = true;
            Number5.Click += NumberOrOperationClick;
            // 
            // Number6
            // 
            Number6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Number6.Location = new Point(184, 242);
            Number6.Name = "Number6";
            Number6.Size = new Size(80, 80);
            Number6.TabIndex = 6;
            Number6.Text = "6";
            Number6.UseVisualStyleBackColor = true;
            Number6.Click += NumberOrOperationClick;
            // 
            // Number7
            // 
            Number7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Number7.Location = new Point(12, 328);
            Number7.Name = "Number7";
            Number7.Size = new Size(80, 80);
            Number7.TabIndex = 7;
            Number7.Text = "7";
            Number7.UseVisualStyleBackColor = true;
            Number7.Click += NumberOrOperationClick;
            // 
            // Number8
            // 
            Number8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Number8.Location = new Point(98, 328);
            Number8.Name = "Number8";
            Number8.Size = new Size(80, 80);
            Number8.TabIndex = 8;
            Number8.Text = "8";
            Number8.UseVisualStyleBackColor = true;
            Number8.Click += NumberOrOperationClick;
            // 
            // Number9
            // 
            Number9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Number9.Location = new Point(184, 328);
            Number9.Name = "Number9";
            Number9.Size = new Size(80, 80);
            Number9.TabIndex = 9;
            Number9.Text = "9";
            Number9.UseVisualStyleBackColor = true;
            Number9.Click += NumberOrOperationClick;
            // 
            // Number0
            // 
            Number0.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Number0.Location = new Point(98, 414);
            Number0.Name = "Number0";
            Number0.Size = new Size(80, 80);
            Number0.TabIndex = 0;
            Number0.Text = "0";
            Number0.UseVisualStyleBackColor = true;
            Number0.Click += NumberOrOperationClick;
            // 
            // PlusButton
            // 
            PlusButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PlusButton.Location = new Point(270, 228);
            PlusButton.Name = "PlusButton";
            PlusButton.Size = new Size(80, 62);
            PlusButton.TabIndex = 12;
            PlusButton.Text = "+";
            PlusButton.UseVisualStyleBackColor = true;
            PlusButton.Click += NumberOrOperationClick;
            // 
            // MinusButton
            // 
            MinusButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MinusButton.Location = new Point(270, 296);
            MinusButton.Name = "MinusButton";
            MinusButton.Size = new Size(80, 62);
            MinusButton.TabIndex = 13;
            MinusButton.Text = "-";
            MinusButton.UseVisualStyleBackColor = true;
            MinusButton.Click += NumberOrOperationClick;
            // 
            // MultiplyButton
            // 
            MultiplyButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MultiplyButton.Location = new Point(270, 364);
            MultiplyButton.Name = "MultiplyButton";
            MultiplyButton.Size = new Size(80, 62);
            MultiplyButton.TabIndex = 14;
            MultiplyButton.Text = "*";
            MultiplyButton.UseVisualStyleBackColor = true;
            MultiplyButton.Click += NumberOrOperationClick;
            // 
            // DivisionButton
            // 
            DivisionButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DivisionButton.Location = new Point(270, 432);
            DivisionButton.Name = "DivisionButton";
            DivisionButton.Size = new Size(80, 62);
            DivisionButton.TabIndex = 15;
            DivisionButton.Text = "/";
            DivisionButton.UseVisualStyleBackColor = true;
            DivisionButton.Click += NumberOrOperationClick;
            // 
            // DeleteButton
            // 
            DeleteButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DeleteButton.Location = new Point(270, 156);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(80, 65);
            DeleteButton.TabIndex = 11;
            DeleteButton.Text = "C";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // EqualButton
            // 
            EqualButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            EqualButton.Location = new Point(184, 414);
            EqualButton.Name = "EqualButton";
            EqualButton.Size = new Size(80, 80);
            EqualButton.TabIndex = 15;
            EqualButton.Text = "=";
            EqualButton.UseVisualStyleBackColor = true;
            EqualButton.Click += NumberOrOperationClick;
            // 
            // OutputWindow
            // 
            OutputWindow.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            OutputWindow.Location = new Point(12, 86);
            OutputWindow.Multiline = true;
            OutputWindow.Name = "OutputWindow";
            OutputWindow.ReadOnly = true;
            OutputWindow.Size = new Size(338, 52);
            OutputWindow.TabIndex = 16;
            OutputWindow.Text = "0";
            OutputWindow.TextAlign = HorizontalAlignment.Right;
            // 
            // DotButton
            // 
            DotButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DotButton.Location = new Point(12, 414);
            DotButton.Name = "DotButton";
            DotButton.Size = new Size(80, 80);
            DotButton.TabIndex = 10;
            DotButton.Text = ".";
            DotButton.UseVisualStyleBackColor = true;
            DotButton.Click += NumberOrOperationClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 507);
            Controls.Add(DotButton);
            Controls.Add(OutputWindow);
            Controls.Add(EqualButton);
            Controls.Add(DeleteButton);
            Controls.Add(DivisionButton);
            Controls.Add(MultiplyButton);
            Controls.Add(MinusButton);
            Controls.Add(PlusButton);
            Controls.Add(Number0);
            Controls.Add(Number9);
            Controls.Add(Number8);
            Controls.Add(Number7);
            Controls.Add(Number6);
            Controls.Add(Number5);
            Controls.Add(Number4);
            Controls.Add(Number3);
            Controls.Add(Number2);
            Controls.Add(Number1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            RightToLeft = RightToLeft.No;
            Text = "Калькулятор";
            TopMost = true;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Number1;
        private Button Number2;
        private Button Number3;
        private Button Number4;
        private Button Number5;
        private Button Number6;
        private Button Number7;
        private Button Number8;
        private Button Number9;
        private Button Number0;
        private Button PlusButton;
        private Button MinusButton;
        private Button MultiplyButton;
        private Button DivisionButton;
        private Button DeleteButton;
        private Button EqualButton;
        private TextBox OutputWindow;
        private Button DotButton;
    }
}