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
            this.StatusLabel = new System.Windows.Forms.Label();
            this.UpdateBondsButton = new System.Windows.Forms.Button();
            this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.curBondLabel = new System.Windows.Forms.Label();
            this.ResultsGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(12, 316);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 13);
            this.StatusLabel.TabIndex = 5;
            // 
            // UpdateBondsButton
            // 
            this.UpdateBondsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpdateBondsButton.Location = new System.Drawing.Point(0, 0);
            this.UpdateBondsButton.Name = "UpdateBondsButton";
            this.UpdateBondsButton.Size = new System.Drawing.Size(632, 23);
            this.UpdateBondsButton.TabIndex = 6;
            this.UpdateBondsButton.Text = "עדכן אג\"חים";
            this.UpdateBondsButton.UseVisualStyleBackColor = true;
            this.UpdateBondsButton.Click += new System.EventHandler(this.UpdateBondsButton_Click);
            // 
            // downloadProgressBar
            // 
            this.downloadProgressBar.Location = new System.Drawing.Point(12, 284);
            this.downloadProgressBar.Name = "downloadProgressBar";
            this.downloadProgressBar.Size = new System.Drawing.Size(560, 23);
            this.downloadProgressBar.TabIndex = 7;
            this.downloadProgressBar.Visible = false;
            // 
            // curBondLabel
            // 
            this.curBondLabel.AutoSize = true;
            this.curBondLabel.Location = new System.Drawing.Point(524, 310);
            this.curBondLabel.Name = "curBondLabel";
            this.curBondLabel.Size = new System.Drawing.Size(0, 13);
            this.curBondLabel.TabIndex = 8;
            // 
            // ResultsGridView
            // 
            this.ResultsGridView.AllowUserToAddRows = false;
            this.ResultsGridView.AllowUserToDeleteRows = false;
            this.ResultsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ResultsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ResultsGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.ResultsGridView.Location = new System.Drawing.Point(0, 23);
            this.ResultsGridView.Name = "ResultsGridView";
            this.ResultsGridView.ReadOnly = true;
            this.ResultsGridView.Size = new System.Drawing.Size(632, 239);
            this.ResultsGridView.TabIndex = 10;
            this.ResultsGridView.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 338);
            this.Controls.Add(this.ResultsGridView);
            this.Controls.Add(this.curBondLabel);
            this.Controls.Add(this.downloadProgressBar);
            this.Controls.Add(this.UpdateBondsButton);
            this.Controls.Add(this.StatusLabel);
            this.Name = "Form1";
            this.Text = "שמנדוזה המלצות";
            ((System.ComponentModel.ISupportInitialize)(this.ResultsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button UpdateBondsButton;
        private System.Windows.Forms.ProgressBar downloadProgressBar;
        private System.Windows.Forms.Label curBondLabel;
        private System.Windows.Forms.DataGridView ResultsGridView;
    }
}

