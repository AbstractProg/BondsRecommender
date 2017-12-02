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
   public partial class DownloadSettingsDlg : Form
   {
      public DownloadSettingsDlg()
      {
         InitializeComponent();
      }

      public List<string> SelectedQualities
      {
         get
         {
            List<CheckBox> qualityCheckboxes = new List<CheckBox>() { qualityCheckBox1, qualityCheckBox2, qualityCheckBox3,
               qualityCheckBox4, qualityCheckBox5, qualityCheckBox6, qualityCheckBox7, qualityCheckBox8, qualityCheckBox9, qualityCheckBox10,
               qualityCheckBox11, qualityCheckBox12, qualityCheckBox13, qualityCheckBox14, qualityCheckBox15, qualityCheckBox16, qualityCheckBox17,
               qualityCheckBox18, qualityCheckBox19, qualityCheckBox20, qualityCheckBox21, qualityCheckBox22, qualityCheckBox23, qualityCheckBox24 };

            return qualityCheckboxes.Where(q => q.Checked).Select(q => q.Text).ToList();
         }
      }

      public double MinMaham => (double)MinMahamNumericUpDown.Value;
      public double MaxMaham => (double)MaxMahamNumericUpDown.Value;

      List<GeneralTypes.IndexType> SelectedIndexes
      {
         get
         {
            List<GeneralTypes.IndexType> retVal = new List<GeneralTypes.IndexType>();

            if (ShekelCheckBox.Checked)
               retVal.Add(GeneralTypes.IndexType.Shekel);
            if (VaryingInterestCheckBox.Checked)
               retVal.Add(GeneralTypes.IndexType.VaryingInterest);
            if (MadadCheckBox.Checked)
               retVal.Add(GeneralTypes.IndexType.Madad);
            if (FixedInterestCheckBox.Checked)
               retVal.Add(GeneralTypes.IndexType.Fixed);
            if (DollarCheckBox.Checked)
               retVal.Add(GeneralTypes.IndexType.Dollar);

            return retVal;
         }
      }

      private void ApplyButton_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.OK;
      }

      private void CancelButton_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
      }
   }
}