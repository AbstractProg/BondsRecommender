namespace FrontEnd
{
   partial class BuyBondDlg
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
         this.panel1 = new System.Windows.Forms.Panel();
         this.portfolioNameLabel = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.panel2 = new System.Windows.Forms.Panel();
         this.partialNameTextBox = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.MoneyNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.panel3 = new System.Windows.Forms.Panel();
         this.UnitsNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.label2 = new System.Windows.Forms.Label();
         this.comissionNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.label5 = new System.Windows.Forms.Label();
         this.buyButton = new System.Windows.Forms.Button();
         this.cancelButton = new System.Windows.Forms.Button();
         this.bondsGridView = new System.Windows.Forms.DataGridView();
         this.panel1.SuspendLayout();
         this.panel2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.MoneyNumericUpDown)).BeginInit();
         this.panel3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.UnitsNumericUpDown)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.comissionNumericUpDown)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.bondsGridView)).BeginInit();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.portfolioNameLabel);
         this.panel1.Controls.Add(this.label1);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel1.Location = new System.Drawing.Point(0, 0);
         this.panel1.Name = "panel1";
         this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.panel1.Size = new System.Drawing.Size(329, 56);
         this.panel1.TabIndex = 0;
         // 
         // portfolioNameLabel
         // 
         this.portfolioNameLabel.AutoSize = true;
         this.portfolioNameLabel.Location = new System.Drawing.Point(175, 31);
         this.portfolioNameLabel.Name = "portfolioNameLabel";
         this.portfolioNameLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.portfolioNameLabel.Size = new System.Drawing.Size(52, 13);
         this.portfolioNameLabel.TabIndex = 1;
         this.portfolioNameLabel.Text = "שם התיק";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(207, 9);
         this.label1.Name = "label1";
         this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.label1.Size = new System.Drawing.Size(74, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "תיק השקעות:";
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.partialNameTextBox);
         this.panel2.Controls.Add(this.label3);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel2.Location = new System.Drawing.Point(0, 56);
         this.panel2.Name = "panel2";
         this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.panel2.Size = new System.Drawing.Size(329, 39);
         this.panel2.TabIndex = 2;
         // 
         // partialNameTextBox
         // 
         this.partialNameTextBox.Location = new System.Drawing.Point(174, 10);
         this.partialNameTextBox.Name = "partialNameTextBox";
         this.partialNameTextBox.Size = new System.Drawing.Size(100, 20);
         this.partialNameTextBox.TabIndex = 1;
         this.partialNameTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(280, 13);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(37, 13);
         this.label3.TabIndex = 0;
         this.label3.Text = "סינון:";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(281, 20);
         this.label4.Name = "label4";
         this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.label4.Size = new System.Drawing.Size(36, 13);
         this.label4.TabIndex = 3;
         this.label4.Text = "סכום:";
         // 
         // MoneyNumericUpDown
         // 
         this.MoneyNumericUpDown.DecimalPlaces = 2;
         this.MoneyNumericUpDown.Location = new System.Drawing.Point(175, 18);
         this.MoneyNumericUpDown.Maximum = new decimal(new int[] {
            350000,
            0,
            0,
            0});
         this.MoneyNumericUpDown.Name = "MoneyNumericUpDown";
         this.MoneyNumericUpDown.Size = new System.Drawing.Size(87, 20);
         this.MoneyNumericUpDown.TabIndex = 4;
         this.MoneyNumericUpDown.Leave += new System.EventHandler(this.MoneyNumericUpDown_Leave);
         // 
         // panel3
         // 
         this.panel3.Controls.Add(this.UnitsNumericUpDown);
         this.panel3.Controls.Add(this.label2);
         this.panel3.Controls.Add(this.comissionNumericUpDown);
         this.panel3.Controls.Add(this.label5);
         this.panel3.Controls.Add(this.MoneyNumericUpDown);
         this.panel3.Controls.Add(this.label4);
         this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel3.Location = new System.Drawing.Point(0, 245);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(329, 81);
         this.panel3.TabIndex = 5;
         // 
         // UnitsNumericUpDown
         // 
         this.UnitsNumericUpDown.Enabled = false;
         this.UnitsNumericUpDown.Location = new System.Drawing.Point(12, 18);
         this.UnitsNumericUpDown.Maximum = new decimal(new int[] {
            35000,
            0,
            0,
            0});
         this.UnitsNumericUpDown.Name = "UnitsNumericUpDown";
         this.UnitsNumericUpDown.Size = new System.Drawing.Size(87, 20);
         this.UnitsNumericUpDown.TabIndex = 10;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(105, 20);
         this.label2.Name = "label2";
         this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.label2.Size = new System.Drawing.Size(46, 13);
         this.label2.TabIndex = 9;
         this.label2.Text = "יחידות:";
         // 
         // comissionNumericUpDown
         // 
         this.comissionNumericUpDown.DecimalPlaces = 2;
         this.comissionNumericUpDown.Location = new System.Drawing.Point(175, 44);
         this.comissionNumericUpDown.Name = "comissionNumericUpDown";
         this.comissionNumericUpDown.Size = new System.Drawing.Size(55, 20);
         this.comissionNumericUpDown.TabIndex = 6;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(233, 46);
         this.label5.Name = "label5";
         this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.label5.Size = new System.Drawing.Size(84, 13);
         this.label5.TabIndex = 5;
         this.label5.Text = "עמלה (אחוזים):";
         // 
         // buyButton
         // 
         this.buyButton.Enabled = false;
         this.buyButton.Location = new System.Drawing.Point(149, 341);
         this.buyButton.Name = "buyButton";
         this.buyButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.buyButton.Size = new System.Drawing.Size(75, 23);
         this.buyButton.TabIndex = 6;
         this.buyButton.Text = "קנה";
         this.buyButton.UseVisualStyleBackColor = true;
         this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
         // 
         // cancelButton
         // 
         this.cancelButton.Location = new System.Drawing.Point(55, 341);
         this.cancelButton.Name = "cancelButton";
         this.cancelButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.cancelButton.Size = new System.Drawing.Size(75, 23);
         this.cancelButton.TabIndex = 7;
         this.cancelButton.Text = "ביטול";
         this.cancelButton.UseVisualStyleBackColor = true;
         this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
         // 
         // bondsGridView
         // 
         this.bondsGridView.AllowUserToAddRows = false;
         this.bondsGridView.AllowUserToDeleteRows = false;
         this.bondsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.bondsGridView.Dock = System.Windows.Forms.DockStyle.Top;
         this.bondsGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
         this.bondsGridView.Location = new System.Drawing.Point(0, 95);
         this.bondsGridView.MultiSelect = false;
         this.bondsGridView.Name = "bondsGridView";
         this.bondsGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.bondsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.bondsGridView.Size = new System.Drawing.Size(329, 150);
         this.bondsGridView.TabIndex = 8;
         // 
         // BuyBondDlg
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(329, 390);
         this.Controls.Add(this.panel3);
         this.Controls.Add(this.bondsGridView);
         this.Controls.Add(this.cancelButton);
         this.Controls.Add(this.buyButton);
         this.Controls.Add(this.panel2);
         this.Controls.Add(this.panel1);
         this.Name = "BuyBondDlg";
         this.RightToLeftLayout = true;
         this.Text = "BuyBondDlg";
         this.Load += new System.EventHandler(this.BuyBondDlg_Load);
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.panel2.ResumeLayout(false);
         this.panel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.MoneyNumericUpDown)).EndInit();
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.UnitsNumericUpDown)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.comissionNumericUpDown)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.bondsGridView)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Label portfolioNameLabel;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.TextBox partialNameTextBox;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.NumericUpDown MoneyNumericUpDown;
      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.NumericUpDown comissionNumericUpDown;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Button buyButton;
      private System.Windows.Forms.Button cancelButton;
      private System.Windows.Forms.DataGridView bondsGridView;
      private System.Windows.Forms.NumericUpDown UnitsNumericUpDown;
      private System.Windows.Forms.Label label2;
   }
}