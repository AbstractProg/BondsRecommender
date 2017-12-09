using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd
{
   public partial class BuyBondDlg : Form
   {
      public int BondIdToBuy { get; private set; }
      public int AmountToBuy { get; private set; }
      public double Comission { get; private set; }
      private List<GeneralTypes.Bond> m_fullBondList;

      public BuyBondDlg(List<GeneralTypes.Bond> bondList, double comission, string portfolioName)
      {
         InitializeComponent();

         comissionNumericUpDown.Value = (decimal)comission;
         Text = "קניית אג\"ח ל" + portfolioName;
         portfolioNameLabel.Text = portfolioName;
         m_fullBondList = bondList;
      }

      private void BuyBondDlg_Load(object sender, EventArgs e)
      {
         bondsGridView.ColumnCount = 3;
         bondsGridView.Columns[0].Name = "שם";
         bondsGridView.Columns[1].Name = "מספר";
         bondsGridView.Columns[2].Name = "מחיר";

         UpdateDisplayedBonds();
      }

      private void UpdateDisplayedBonds()
      {
         bondsGridView.Rows.Clear();
         foreach (GeneralTypes.Bond curBond in m_fullBondList)
         {
            if (curBond.Name.Contains(partialNameTextBox.Text))
            {
               string[] row = new string[] { curBond.Name, curBond.SerialNumber.ToString(), curBond.Value.ToString() };
               bondsGridView.Rows.Add(row);
            }
         }
      }

      private void textBox1_TextChanged(object sender, EventArgs e)
      {
         UpdateDisplayedBonds();
      }

      private void MoneyNumericUpDown_Leave(object sender, EventArgs e)
      {
         double unitCost = Convert.ToDouble(bondsGridView.Rows[bondsGridView.SelectedRows[0].Index].Cells[2].Value.ToString());
         UnitsNumericUpDown.Value = (int)((double)MoneyNumericUpDown.Value / unitCost);
         MoneyNumericUpDown.Value = UnitsNumericUpDown.Value * (decimal)unitCost;
         if (UnitsNumericUpDown.Value == 0)
            buyButton.Enabled = false;
         else
            buyButton.Enabled = true;
      }

      private void buyButton_Click(object sender, EventArgs e)
      {
         Comission = (double)comissionNumericUpDown.Value;
         BondIdToBuy = Convert.ToInt32(bondsGridView.Rows[bondsGridView.SelectedRows[0].Index].Cells[1].Value.ToString());
         AmountToBuy = (int)UnitsNumericUpDown.Value;
         DialogResult = DialogResult.OK;
      }

      private void cancelButton_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
      }

      
   }
}
