namespace FrontEnd
{
    partial class Form1
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
            this.ExtractFundsButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.UpdateBondsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExtractFundsButton
            // 
            this.ExtractFundsButton.Location = new System.Drawing.Point(78, 96);
            this.ExtractFundsButton.Name = "ExtractFundsButton";
            this.ExtractFundsButton.Size = new System.Drawing.Size(146, 23);
            this.ExtractFundsButton.TabIndex = 0;
            this.ExtractFundsButton.Text = "חלץ מידע קרנות נאמנות";
            this.ExtractFundsButton.UseVisualStyleBackColor = true;
            this.ExtractFundsButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(75, 307);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 13);
            this.StatusLabel.TabIndex = 5;
            // 
            // UpdateBondsButton
            // 
            this.UpdateBondsButton.Location = new System.Drawing.Point(104, 44);
            this.UpdateBondsButton.Name = "UpdateBondsButton";
            this.UpdateBondsButton.Size = new System.Drawing.Size(102, 23);
            this.UpdateBondsButton.TabIndex = 6;
            this.UpdateBondsButton.Text = "עדכן מידע אג\"ח";
            this.UpdateBondsButton.UseVisualStyleBackColor = true;
            this.UpdateBondsButton.Click += new System.EventHandler(this.UpdateBondsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 338);
            this.Controls.Add(this.UpdateBondsButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.ExtractFundsButton);
            this.Name = "Form1";
            this.Text = "שמנדוזה המלצות";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExtractFundsButton;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button UpdateBondsButton;
    }
}

