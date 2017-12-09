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
   public partial class SellBondDlg : Form
   {
      public int BondIdToSell { get; private set; }
      public double Comission { get; private set; }
      private List<GeneralTypes.Bond> m_fullBondList;

      public SellBondDlg(List<GeneralTypes.Bond> bondList, double comission, string portfolioName)
      {
         InitializeComponent();

         comissionNumericUpDown.Value = (decimal)comission;
         Text = "קניית אג\"ח ל" + portfolioName;
         portfolioNameLabel.Text = portfolioName;
         m_fullBondList = bondList;
      }

      private void SellBondDlg_Load(object sender, EventArgs e)
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
            string[] row = new string[] { curBond.Name, curBond.SerialNumber.ToString(), curBond.Value.ToString() };
            bondsGridView.Rows.Add(row);
         }
      }

      private void sellButton_Click(object sender, EventArgs e)
      {
         Comission = (double)comissionNumericUpDown.Value;
         BondIdToSell = Convert.ToInt32(bondsGridView.Rows[bondsGridView.SelectedRows[0].Index].Cells[1].Value.ToString());
         DialogResult = DialogResult.OK;
      }
   }
}
