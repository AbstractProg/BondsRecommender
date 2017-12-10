namespace FrontEnd
{
   partial class SellBondDlg
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
         this.cancelButton = new System.Windows.Forms.Button();
         this.sellButton = new System.Windows.Forms.Button();
         this.bondsGridView = new System.Windows.Forms.DataGridView();
         this.comissionNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.label5 = new System.Windows.Forms.Label();
         this.panel2 = new System.Windows.Forms.Panel();
         this.panel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.bondsGridView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.comissionNumericUpDown)).BeginInit();
         this.panel2.SuspendLayout();
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
         this.panel1.Size = new System.Drawing.Size(284, 56);
         this.panel1.TabIndex = 1;
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
         // cancelButton
         // 
         this.cancelButton.Location = new System.Drawing.Point(74, 282);
         this.cancelButton.Name = "cancelButton";
         this.cancelButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.cancelButton.Size = new System.Drawing.Size(75, 23);
         this.cancelButton.TabIndex = 9;
         this.cancelButton.Text = "ביטול";
         this.cancelButton.UseVisualStyleBackColor = true;
         // 
         // sellButton
         // 
         this.sellButton.Location = new System.Drawing.Point(169, 282);
         this.sellButton.Name = "sellButton";
         this.sellButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.sellButton.Size = new System.Drawing.Size(75, 23);
         this.sellButton.TabIndex = 8;
         this.sellButton.Text = "מכור";
         this.sellButton.UseVisualStyleBackColor = true;
         this.sellButton.Click += new System.EventHandler(this.sellButton_Click);
         // 
         // bondsGridView
         // 
         this.bondsGridView.AllowUserToAddRows = false;
         this.bondsGridView.AllowUserToDeleteRows = false;
         this.bondsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.bondsGridView.Dock = System.Windows.Forms.DockStyle.Top;
         this.bondsGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
         this.bondsGridView.Location = new System.Drawing.Point(0, 56);
         this.bondsGridView.MultiSelect = false;
         this.bondsGridView.Name = "bondsGridView";
         this.bondsGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.bondsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.bondsGridView.Size = new System.Drawing.Size(284, 150);
         this.bondsGridView.TabIndex = 10;
         // 
         // comissionNumericUpDown
         // 
         this.comissionNumericUpDown.DecimalPlaces = 2;
         this.comissionNumericUpDown.Location = new System.Drawing.Point(74, 19);
         this.comissionNumericUpDown.Name = "comissionNumericUpDown";
         this.comissionNumericUpDown.Size = new System.Drawing.Size(55, 20);
         this.comissionNumericUpDown.TabIndex = 12;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(132, 21);
         this.label5.Name = "label5";
         this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.label5.Size = new System.Drawing.Size(84, 13);
         this.label5.TabIndex = 11;
         this.label5.Text = "עמלה (אחוזים):";
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.comissionNumericUpDown);
         this.panel2.Controls.Add(this.label5);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel2.Location = new System.Drawing.Point(0, 206);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(284, 54);
         this.panel2.TabIndex = 13;
         // 
         // SellBondDlg
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 336);
         this.Controls.Add(this.panel2);
         this.Controls.Add(this.bondsGridView);
         this.Controls.Add(this.cancelButton);
         this.Controls.Add(this.sellButton);
         this.Controls.Add(this.panel1);
         this.Name = "SellBondDlg";
         this.Text = "SellBond";
         this.Load += new System.EventHandler(this.SellBondDlg_Load);
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.bondsGridView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.comissionNumericUpDown)).EndInit();
         this.panel2.ResumeLayout(false);
         this.panel2.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Label portfolioNameLabel;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button cancelButton;
      private System.Windows.Forms.Button sellButton;
      private System.Windows.Forms.DataGridView bondsGridView;
      private System.Windows.Forms.NumericUpDown comissionNumericUpDown;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Panel panel2;
   }
}