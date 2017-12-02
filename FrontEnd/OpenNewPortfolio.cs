using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FrontEnd
{
    public partial class OpenNewPortfolio : Form
    {
        public string PortfolioName { get { return portfolioNameTextBox.Text; } }
        public double InitialMoney { get { return (double)MoneyNumericUpDown.Value ; } }

        List<string> m_namesInUse;

        private void OpenNewPortfolio_Load(object sender, EventArgs e)
        {
            portfolioNameTextBox.Text = "";
            MoneyNumericUpDown.Value = 250000;
            createPortfolioButton.Enabled = false;
        }

        public OpenNewPortfolio(List<string> namesInUse)
        {
            InitializeComponent();
            m_namesInUse = namesInUse;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (m_namesInUse.Contains(portfolioNameTextBox.Text) || portfolioNameTextBox.Text.Equals(""))
                createPortfolioButton.Enabled = false;
            else
                createPortfolioButton.Enabled = true;
        }

        private void createPortfolioButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            //Close();
        }
    }
}
