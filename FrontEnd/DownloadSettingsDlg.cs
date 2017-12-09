using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bridge;

namespace FrontEnd
{
   public partial class DownloadSettingsDlg : Form
   {
      BridgeToBackEnd m_Bridge;
      List<CheckBox> m_qualityCheckboxes;

      public DownloadSettingsDlg(BridgeToBackEnd Bridge)
      {
         InitializeComponent();
         m_Bridge = Bridge;

         m_qualityCheckboxes = new List<CheckBox>() { qualityCheckBox1, qualityCheckBox2, qualityCheckBox3,
               qualityCheckBox4, qualityCheckBox5, qualityCheckBox6, qualityCheckBox7, qualityCheckBox8, qualityCheckBox9, qualityCheckBox10,
               qualityCheckBox11, qualityCheckBox12, qualityCheckBox13, qualityCheckBox14, qualityCheckBox15, qualityCheckBox16, qualityCheckBox17,
               qualityCheckBox18, qualityCheckBox19, qualityCheckBox20, qualityCheckBox21, qualityCheckBox22, qualityCheckBox23, qualityCheckBox24 };
   }

      public List<string> SelectedQualities
      {
         get
         {
            return m_qualityCheckboxes.Where(q => q.Checked).Select(q => q.Text).ToList();
         }
      }

      public List<GeneralTypes.IndexType> SelectedIndexes
      {
         get
         {
            List<GeneralTypes.IndexType> retVal = new List<GeneralTypes.IndexType>();
            if (ShekelCheckBox.Checked)
               retVal.Add(GeneralTypes.IndexType.Shekel);
            if (VaryingInterestCheckBox.Checked)
               retVal.Add(GeneralTypes.IndexType.VaryingInterest);
            if (FixedInterestCheckBox.Checked)
               retVal.Add(GeneralTypes.IndexType.Fixed);
            if (MadadCheckBox.Checked)
               retVal.Add(GeneralTypes.IndexType.Madad);
            if (DollarCheckBox.Checked)
               retVal.Add(GeneralTypes.IndexType.Dollar);
            return retVal;
         }
      }

      public double MinMaham => (double)MinMahamNumericUpDown.Value;
      public double MaxMaham => (double)MaxMahamNumericUpDown.Value;

      private void DownloadSettingsDlg_Load(object sender, EventArgs e)
      {
         //check wanted qualities in config file and mark corresponding check boxes
         List<string> qualitiesToCheck = m_Bridge.QualityToDownload_BRDG;
         List<CheckBox> checkBoxesToCheck = m_qualityCheckboxes.Where(q => qualitiesToCheck.Contains(q.Text)).ToList();
         foreach (CheckBox cb in checkBoxesToCheck)
            cb.Checked = true;

         //check wanted indexes in config file and mark corresponding check boxes
         List<GeneralTypes.IndexType> indexesToCheck = m_Bridge.IndexesToDownload_BRDG;
         if (indexesToCheck.Contains(GeneralTypes.IndexType.Shekel))
            ShekelCheckBox.Checked = true;
         if (indexesToCheck.Contains(GeneralTypes.IndexType.Madad))
            MadadCheckBox.Checked = true;
         if (indexesToCheck.Contains(GeneralTypes.IndexType.VaryingInterest))
            VaryingInterestCheckBox.Checked = true;
         if (indexesToCheck.Contains(GeneralTypes.IndexType.Fixed))
            FixedInterestCheckBox.Checked = true;
         if (indexesToCheck.Contains(GeneralTypes.IndexType.Dollar))
            DollarCheckBox.Checked = true;

         //check wanted maham range in config file and set corresponding numericUpDowns accordingly
         MinMahamNumericUpDown.Value = (decimal)m_Bridge.MinMahamToDownload_BRDG;
         MaxMahamNumericUpDown.Value = (decimal)m_Bridge.MaxMahamToDownload_BRDG;
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