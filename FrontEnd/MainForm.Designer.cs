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
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.tabPage1 = new System.Windows.Forms.TabPage();
         this.tabPage2 = new System.Windows.Forms.TabPage();
         this.panel2 = new System.Windows.Forms.Panel();
         this.holdingsDataGridView = new System.Windows.Forms.DataGridView();
         this.panel1 = new System.Windows.Forms.Panel();
         this.cashLabel = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.עדכןנתוניםToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.אפשרויותהורדתנתוניםToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.portflioComboBox = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.buyBondButton = new System.Windows.Forms.Button();
         this.sellBondButton = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         ((System.ComponentModel.ISupportInitialize)(this.ResultsGridView)).BeginInit();
         this.tabControl1.SuspendLayout();
         this.tabPage1.SuspendLayout();
         this.tabPage2.SuspendLayout();
         this.panel2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.holdingsDataGridView)).BeginInit();
         this.panel1.SuspendLayout();
         this.menuStrip1.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // StatusLabel
         // 
         this.StatusLabel.AutoSize = true;
         this.StatusLabel.Location = new System.Drawing.Point(48, 490);
         this.StatusLabel.Name = "StatusLabel";
         this.StatusLabel.Size = new System.Drawing.Size(0, 13);
         this.StatusLabel.TabIndex = 5;
         // 
         // UpdateBondsButton
         // 
         this.UpdateBondsButton.Location = new System.Drawing.Point(107, 105);
         this.UpdateBondsButton.Name = "UpdateBondsButton";
         this.UpdateBondsButton.Size = new System.Drawing.Size(196, 23);
         this.UpdateBondsButton.TabIndex = 6;
         this.UpdateBondsButton.Text = "עדכן אג\"חים";
         this.UpdateBondsButton.UseVisualStyleBackColor = true;
         this.UpdateBondsButton.Click += new System.EventHandler(this.UpdateBondsButton_Click);
         // 
         // downloadProgressBar
         // 
         this.downloadProgressBar.Location = new System.Drawing.Point(48, 458);
         this.downloadProgressBar.Name = "downloadProgressBar";
         this.downloadProgressBar.Size = new System.Drawing.Size(560, 23);
         this.downloadProgressBar.TabIndex = 7;
         this.downloadProgressBar.Visible = false;
         // 
         // curBondLabel
         // 
         this.curBondLabel.AutoSize = true;
         this.curBondLabel.Location = new System.Drawing.Point(560, 484);
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
         this.ResultsGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
         this.ResultsGridView.Location = new System.Drawing.Point(39, 6);
         this.ResultsGridView.Name = "ResultsGridView";
         this.ResultsGridView.ReadOnly = true;
         this.ResultsGridView.Size = new System.Drawing.Size(749, 232);
         this.ResultsGridView.TabIndex = 10;
         // 
         // tabControl1
         // 
         this.tabControl1.Controls.Add(this.tabPage1);
         this.tabControl1.Controls.Add(this.tabPage2);
         this.tabControl1.Location = new System.Drawing.Point(72, 141);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.tabControl1.RightToLeftLayout = true;
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(858, 289);
         this.tabControl1.TabIndex = 11;
         // 
         // tabPage1
         // 
         this.tabPage1.Controls.Add(this.ResultsGridView);
         this.tabPage1.Location = new System.Drawing.Point(4, 22);
         this.tabPage1.Name = "tabPage1";
         this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage1.Size = new System.Drawing.Size(850, 263);
         this.tabPage1.TabIndex = 0;
         this.tabPage1.Text = "חפש אג\"ח";
         this.tabPage1.UseVisualStyleBackColor = true;
         // 
         // tabPage2
         // 
         this.tabPage2.Controls.Add(this.panel2);
         this.tabPage2.Controls.Add(this.panel1);
         this.tabPage2.Controls.Add(this.label3);
         this.tabPage2.Location = new System.Drawing.Point(4, 22);
         this.tabPage2.Name = "tabPage2";
         this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 35, 3, 3);
         this.tabPage2.Size = new System.Drawing.Size(850, 263);
         this.tabPage2.TabIndex = 1;
         this.tabPage2.Text = "תיק וירטואלי";
         this.tabPage2.UseVisualStyleBackColor = true;
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.holdingsDataGridView);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel2.Location = new System.Drawing.Point(3, 67);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(844, 190);
         this.panel2.TabIndex = 6;
         // 
         // holdingsDataGridView
         // 
         this.holdingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.holdingsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.holdingsDataGridView.Location = new System.Drawing.Point(0, 0);
         this.holdingsDataGridView.Name = "holdingsDataGridView";
         this.holdingsDataGridView.Size = new System.Drawing.Size(844, 190);
         this.holdingsDataGridView.TabIndex = 3;
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.cashLabel);
         this.panel1.Controls.Add(this.label2);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel1.Location = new System.Drawing.Point(3, 35);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(844, 32);
         this.panel1.TabIndex = 5;
         // 
         // cashLabel
         // 
         this.cashLabel.AutoSize = true;
         this.cashLabel.Dock = System.Windows.Forms.DockStyle.Right;
         this.cashLabel.Location = new System.Drawing.Point(792, 0);
         this.cashLabel.Name = "cashLabel";
         this.cashLabel.Size = new System.Drawing.Size(13, 13);
         this.cashLabel.TabIndex = 6;
         this.cashLabel.Text = "0";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Dock = System.Windows.Forms.DockStyle.Right;
         this.label2.Location = new System.Drawing.Point(805, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(39, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "מזומן:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(751, 143);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(48, 13);
         this.label3.TabIndex = 2;
         this.label3.Text = "החזקות:";
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(1029, 24);
         this.menuStrip1.TabIndex = 12;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // optionsToolStripMenuItem
         // 
         this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.עדכןנתוניםToolStripMenuItem,
            this.אפשרויותהורדתנתוניםToolStripMenuItem});
         this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
         this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
         this.optionsToolStripMenuItem.Text = "Options";
         // 
         // עדכןנתוניםToolStripMenuItem
         // 
         this.עדכןנתוניםToolStripMenuItem.Name = "עדכןנתוניםToolStripMenuItem";
         this.עדכןנתוניםToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
         this.עדכןנתוניםToolStripMenuItem.Text = "עדכן נתונים";
         // 
         // אפשרויותהורדתנתוניםToolStripMenuItem
         // 
         this.אפשרויותהורדתנתוניםToolStripMenuItem.Name = "אפשרויותהורדתנתוניםToolStripMenuItem";
         this.אפשרויותהורדתנתוניםToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
         this.אפשרויותהורדתנתוניםToolStripMenuItem.Text = "אפשרויות הורדת נתונים";
         this.אפשרויותהורדתנתוניםToolStripMenuItem.Click += new System.EventHandler(this.DownloadSettingsStripMenuItem_Click);
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
         this.aboutToolStripMenuItem.Text = "About";
         // 
         // portflioComboBox
         // 
         this.portflioComboBox.AllowDrop = true;
         this.portflioComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.portflioComboBox.FormattingEnabled = true;
         this.portflioComboBox.Location = new System.Drawing.Point(906, 52);
         this.portflioComboBox.Name = "portflioComboBox";
         this.portflioComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.portflioComboBox.Size = new System.Drawing.Size(111, 21);
         this.portflioComboBox.TabIndex = 13;
         this.portflioComboBox.SelectedIndexChanged += new System.EventHandler(this.portflioComboBox_SelectedIndexChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(943, 36);
         this.label1.Name = "label1";
         this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.label1.Size = new System.Drawing.Size(74, 13);
         this.label1.TabIndex = 14;
         this.label1.Text = "תיק השקעות:";
         // 
         // buyBondButton
         // 
         this.buyBondButton.Dock = System.Windows.Forms.DockStyle.Top;
         this.buyBondButton.Enabled = false;
         this.buyBondButton.Location = new System.Drawing.Point(3, 16);
         this.buyBondButton.Name = "buyBondButton";
         this.buyBondButton.Size = new System.Drawing.Size(129, 23);
         this.buyBondButton.TabIndex = 7;
         this.buyBondButton.Text = "קנה אג\"ח";
         this.buyBondButton.UseVisualStyleBackColor = true;
         this.buyBondButton.Click += new System.EventHandler(this.buyBondButton_Click);
         // 
         // sellBondButton
         // 
         this.sellBondButton.Dock = System.Windows.Forms.DockStyle.Top;
         this.sellBondButton.Enabled = false;
         this.sellBondButton.Location = new System.Drawing.Point(3, 39);
         this.sellBondButton.Name = "sellBondButton";
         this.sellBondButton.Size = new System.Drawing.Size(129, 23);
         this.sellBondButton.TabIndex = 8;
         this.sellBondButton.Text = "מכור אג\"ח";
         this.sellBondButton.UseVisualStyleBackColor = true;
         this.sellBondButton.Click += new System.EventHandler(this.sellBondButton_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.sellBondButton);
         this.groupBox1.Controls.Add(this.buyBondButton);
         this.groupBox1.Location = new System.Drawing.Point(487, 60);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.groupBox1.Size = new System.Drawing.Size(135, 68);
         this.groupBox1.TabIndex = 15;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "פעולות";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1029, 531);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.portflioComboBox);
         this.Controls.Add(this.tabControl1);
         this.Controls.Add(this.curBondLabel);
         this.Controls.Add(this.downloadProgressBar);
         this.Controls.Add(this.UpdateBondsButton);
         this.Controls.Add(this.StatusLabel);
         this.Controls.Add(this.menuStrip1);
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "Form1";
         this.Text = "שמנדוזה המלצות";
         this.Load += new System.EventHandler(this.Form1_Load);
         ((System.ComponentModel.ISupportInitialize)(this.ResultsGridView)).EndInit();
         this.tabControl1.ResumeLayout(false);
         this.tabPage1.ResumeLayout(false);
         this.tabPage2.ResumeLayout(false);
         this.tabPage2.PerformLayout();
         this.panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.holdingsDataGridView)).EndInit();
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button UpdateBondsButton;
        private System.Windows.Forms.ProgressBar downloadProgressBar;
        private System.Windows.Forms.Label curBondLabel;
        private System.Windows.Forms.DataGridView ResultsGridView;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem עדכןנתוניםToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem אפשרויותהורדתנתוניםToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ComboBox portflioComboBox;
        private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.DataGridView holdingsDataGridView;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Label cashLabel;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Button sellBondButton;
      private System.Windows.Forms.Button buyBondButton;
      private System.Windows.Forms.GroupBox groupBox1;
   }
}

