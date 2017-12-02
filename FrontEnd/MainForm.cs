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
using System.IO;

namespace FrontEnd
{
   public partial class Form1 : Form
   {
      static string OPEN_NEW_PORTFOLIO_STR = "צור תיק חדש";
      BridgeToBackEnd m_Bridge;

      /**********************************************************************/
      /******************************** ctr *********************************/
      /**********************************************************************/

      public Form1(BridgeToBackEnd Bridge, BridgeMsg.DataDownloadStartedMsg DownloadStartedMsg, BridgeMsg.DownloadProgressMsg DownloadProgressMsg,
          BridgeMsg.ListOfBondsMsg BondsListUpdatedMsg)
      {
         InitializeComponent();
         m_Bridge = Bridge;

         DownloadStartedMsg.OnDownloadStarted += DownloadStartedHandler;
         DownloadProgressMsg.OnDownloadProgress += DownloadProgressHandler;
         BondsListUpdatedMsg.OnListOfBondsUpdated += ListOfBondsUpdatedHandler;
      }



      /**********************************************************************/
      /******************* Backend messages Event Handlers ******************/
      /**********************************************************************/


      private void DownloadStartedHandler()
      {
         StatusLabel.Invoke((MethodInvoker)delegate
         {
            StatusLabel.Text = "Downloading, please wait...";
         });
      }

      private void DownloadProgressHandler(int progressPercent, string bondName)
      {
         downloadProgressBar.Invoke((MethodInvoker)delegate
         {
            downloadProgressBar.Value = progressPercent;
            curBondLabel.Text = bondName;
         });
      }

      private void ListOfBondsUpdatedHandler(List<GeneralTypes.Bond> bondList)
      {
         ResultsGridView.Invoke((MethodInvoker)delegate
         {
            UpdateBondsButton.Enabled = true;
            downloadProgressBar.Visible = false;
            StatusLabel.Visible = false;
            curBondLabel.Visible = false;

            ResultsGridView.Visible = true;
            ResultsGridView.ColumnCount = 5;
            ResultsGridView.Columns[0].Name = "שם";
            ResultsGridView.Columns[1].Name = "מספר";
            ResultsGridView.Columns[2].Name = "דירוג";
            ResultsGridView.Columns[3].Name = "מח\"מ";
            ResultsGridView.Columns[4].Name = "תשואה נטו";

            foreach (GeneralTypes.Bond curBond in bondList)
            {
               string[] row = new string[] { curBond.Name, curBond.SerialNumber.ToString(), curBond.QualityRating, curBond.Maham.ToString(),
                        curBond.NetYield.ToString()};
               ResultsGridView.Rows.Add(row);
            }
         });
      }

      /**********************************************************************/
      /********************** UI controls Event Handlers ********************/
      /**********************************************************************/

      private void ExtractButton_Click(object sender, EventArgs e)
      {
         m_Bridge.ExtractFunds_BRDG();
      }

      private void UpdateBondsButton_Click(object sender, EventArgs e)
      {
         UpdateBondsButton.Enabled = false;
         downloadProgressBar.Visible = true;

         m_Bridge.UpdateBonds_BRDG(m_Bridge.QualityToDownload_BRDG, m_Bridge.MinMahamToDownload_BRDG, m_Bridge.MaxMahamToDownload_BRDG);
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         portflioComboBox.Items.AddRange(m_Bridge.GetPortfolioNames_BRDG().ToArray());

         portflioComboBox.Items.Add(OPEN_NEW_PORTFOLIO_STR);
      }

      private void DownloadSettingsStripMenuItem_Click(object sender, EventArgs e)
      {
         DownloadSettingsDlg downloadSettingsDlg = new DownloadSettingsDlg();
         if (downloadSettingsDlg.ShowDialog(this) == DialogResult.OK)
         {
            m_Bridge.UpdateCfgFile_BRDG(downloadSettingsDlg.SelectedQualities, downloadSettingsDlg.MinMaham, downloadSettingsDlg.MaxMaham,
               m_Bridge.QualityToDisplay_BRDG, m_Bridge.MinMahamToDisplay_BRDG, m_Bridge.MaxMahamToDisplay_BRDG);
         }
      }

      private void portflioComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         //create a new portfolio
         if (portflioComboBox.Text == OPEN_NEW_PORTFOLIO_STR)
         {
            List<string> portfolioNames = m_Bridge.GetPortfolioNames_BRDG();
            OpenNewPortfolio openPFDlg = new OpenNewPortfolio(portfolioNames);
            DialogResult dr = openPFDlg.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
               m_Bridge.CreateNewPortfolio_BRDG(openPFDlg.PortfolioName, openPFDlg.InitialMoney);
               portflioComboBox.Items.Add(openPFDlg.PortfolioName);
            }
         }
         else //selected an existing portfolio
         {
            cashLabel.Text = m_Bridge.GetPortfolioFreeMoney_BRDG(portflioComboBox.Text).ToString();
            Dictionary<GeneralTypes.Bond, string> portfolioHoldings = m_Bridge.GetPortfolioHoldings_BRDG(portflioComboBox.Text);

            holdingsDataGridView.ColumnCount = 7;
            holdingsDataGridView.Columns[0].Name = "שם";
            holdingsDataGridView.Columns[1].Name = "מספר";
            holdingsDataGridView.Columns[2].Name = "דירוג";
            holdingsDataGridView.Columns[3].Name = "מח\"מ";
            holdingsDataGridView.Columns[4].Name = "תשואה נטו";
            holdingsDataGridView.Columns[5].Name = "תאריך קנייה";
            holdingsDataGridView.Columns[6].Name = "שער קנייה";

            foreach (KeyValuePair<GeneralTypes.Bond, string> holding in portfolioHoldings)
            {
               string[] holdingData = holding.Value.Split('@');
               string[] row = new string[] { holding.Key.Name, holding.Key.SerialNumber.ToString(), holding.Key.QualityRating, holding.Key.Maham.ToString(),
                        holding.Key.NetYield.ToString(), holdingData[0], holdingData[1]};
               ResultsGridView.Rows.Add(row);
            }
         }
      }

      private void Form1_FormClosing(object sender, FormClosingEventArgs e)
      {
         m_Bridge.UpdateBondsFile_BRDG();
      }
   }
}