namespace FrontEnd
{
    partial class OpenNewPortfolio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.portfolioNameTextBox = new System.Windows.Forms.TextBox();
            this.createPortfolioButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.MoneyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 34);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "שם התיק:";
            // 
            // portfolioNameTextBox
            // 
            this.portfolioNameTextBox.Location = new System.Drawing.Point(12, 31);
            this.portfolioNameTextBox.Name = "portfolioNameTextBox";
            this.portfolioNameTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.portfolioNameTextBox.Size = new System.Drawing.Size(170, 20);
            this.portfolioNameTextBox.TabIndex = 1;
            this.portfolioNameTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // createPortfolioButton
            // 
            this.createPortfolioButton.Enabled = false;
            this.createPortfolioButton.Location = new System.Drawing.Point(97, 104);
            this.createPortfolioButton.Name = "createPortfolioButton";
            this.createPortfolioButton.Size = new System.Drawing.Size(75, 23);
            this.createPortfolioButton.TabIndex = 2;
            this.createPortfolioButton.Text = "צור תיק";
            this.createPortfolioButton.UseVisualStyleBackColor = true;
            this.createPortfolioButton.Click += new System.EventHandler(this.createPortfolioButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 63);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "סכום:";
            // 
            // MoneyNumericUpDown
            // 
            this.MoneyNumericUpDown.DecimalPlaces = 1;
            this.MoneyNumericUpDown.Location = new System.Drawing.Point(62, 63);
            this.MoneyNumericUpDown.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            this.MoneyNumericUpDown.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.MoneyNumericUpDown.Name = "MoneyNumericUpDown";
            this.MoneyNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MoneyNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.MoneyNumericUpDown.TabIndex = 4;
            this.MoneyNumericUpDown.Value = new decimal(new int[] {
            250000,
            0,
            0,
            0});
            // 
            // OpenNewPortfolio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 139);
            this.Controls.Add(this.MoneyNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.createPortfolioButton);
            this.Controls.Add(this.portfolioNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "OpenNewPortfolio";
            this.Text = "OpenNewPortfolio";
            this.Load += new System.EventHandler(this.OpenNewPortfolio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MoneyNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox portfolioNameTextBox;
        private System.Windows.Forms.Button createPortfolioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown MoneyNumericUpDown;
    }
}