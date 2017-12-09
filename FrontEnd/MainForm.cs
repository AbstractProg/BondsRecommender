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

         ResultsGridView.ColumnCount = 7;
         ResultsGridView.Columns[NAME_COL].Name = "שם";
         ResultsGridView.Columns[SERIAL_COL].Name = "מספר";
         ResultsGridView.Columns[QUALITY_COL].Name = "דירוג";
         ResultsGridView.Columns[MAHAM_COL].Name = "מח\"מ";
         ResultsGridView.Columns[INDEX_COL].Name = "הצמדה";
         ResultsGridView.Columns[EXDATE_COL].Name = "תאריך אקס";
         ResultsGridView.Columns[NET_YIELD_COL].Name = "תשואה נטו";
      }

      /**********************************************************************/
      /*************************** UI utilities *****************************/
      /**********************************************************************/

      const int NAME_COL = 0;
      const int SERIAL_COL = 1;
      const int QUALITY_COL = 2;
      const int MAHAM_COL = 3;
      const int INDEX_COL = 4;
      const int EXDATE_COL = 5;
      const int NET_YIELD_COL = 6;

      private void UpdateDisplayedBonds()
      {
         List<GeneralTypes.Bond> bondList = m_Bridge.GetListOfBonds_BRDG();

         ResultsGridView.Rows.Clear();

         for(int i=0; i<bondList.Count; i++)
         //foreach (GeneralTypes.Bond curBond in bondList)
         {
            ResultsGridView.Rows.Add();
            ResultsGridView.Rows[i].Cells[NAME_COL].Value      = bondList[i].Name;
            ResultsGridView.Rows[i].Cells[SERIAL_COL].Value    = bondList[i].SerialNumber;
            ResultsGridView.Rows[i].Cells[QUALITY_COL].Value   = bondList[i].QualityRating;
            ResultsGridView.Rows[i].Cells[MAHAM_COL].Value     = bondList[i].Maham;
            ResultsGridView.Rows[i].Cells[INDEX_COL].Value     = GeneralTypes.IndexConverter.IndexToString(bondList[i].Index);
            ResultsGridView.Rows[i].Cells[EXDATE_COL].Value    = bondList[i].ExDate.ToString("yyyy/MM/dd", null);
            ResultsGridView.Rows[i].Cells[NET_YIELD_COL].Value = bondList[i].NetYield;
         }
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

            UpdateDisplayedBonds();
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

         m_Bridge.DownloadBonds_BRDG(m_Bridge.QualityToDownload_BRDG, m_Bridge.IndexesToDownload_BRDG, m_Bridge.MinMahamToDownload_BRDG, m_Bridge.MaxMahamToDownload_BRDG);
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         //add existing portfolios to drop down list
         portflioComboBox.Items.AddRange(m_Bridge.GetPortfolioNames_BRDG().ToArray());
         portflioComboBox.Items.Add(OPEN_NEW_PORTFOLIO_STR);

         UpdateDisplayedBonds();
      }

      private void DownloadSettingsStripMenuItem_Click(object sender, EventArgs e)
      {
         DownloadSettingsDlg downloadSettingsDlg = new DownloadSettingsDlg(m_Bridge);
         if (downloadSettingsDlg.ShowDialog(this) == DialogResult.OK)
         {
            m_Bridge.UpdateCfgFile_BRDG(downloadSettingsDlg.SelectedQualities, downloadSettingsDlg.SelectedIndexes, downloadSettingsDlg.MinMaham,
               downloadSettingsDlg.MaxMaham, m_Bridge.QualityToDisplay_BRDG, m_Bridge.IndexesToDisplay_BRDG, m_Bridge.MinMahamToDisplay_BRDG,
               m_Bridge.MaxMahamToDisplay_BRDG);
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
               portflioComboBox.Items.Remove(OPEN_NEW_PORTFOLIO_STR);
               portflioComboBox.Items.Add(openPFDlg.PortfolioName);
               portflioComboBox.SelectedItem = openPFDlg.PortfolioName;
               portflioComboBox.Items.Add(OPEN_NEW_PORTFOLIO_STR);
               buyBondButton.Enabled = true;
               sellBondButton.Enabled = true;
            }
         }
         else //selected an existing portfolio
         {
            DisplayPortfolio(portflioComboBox.Text);
            buyBondButton.Enabled = true;
            sellBondButton.Enabled = true;
         }
      }

      private void DisplayPortfolio(string portfolioName)
      {
         cashLabel.Text = string.Format("{0:0.##}", m_Bridge.GetPortfolioFreeMoney_BRDG(portfolioName));
         Dictionary<int, GeneralTypes.Position> portfolioHoldings = m_Bridge.GetPortfolioHoldings_BRDG(portflioComboBox.Text);

         holdingsDataGridView.ColumnCount = 10;
         holdingsDataGridView.Columns[0].Name = "שם";
         holdingsDataGridView.Columns[1].Name = "מספר";
         holdingsDataGridView.Columns[2].Name = "דירוג";
         holdingsDataGridView.Columns[3].Name = "מח\"מ";
         holdingsDataGridView.Columns[4].Name = "תשואה נטו";
         holdingsDataGridView.Columns[5].Name = "שער נוכחי";
         holdingsDataGridView.Columns[6].Name = "תאריך קנייה";
         holdingsDataGridView.Columns[7].Name = "שער קנייה";
         holdingsDataGridView.Columns[8].Name = "יחידות מוחזקות";
         holdingsDataGridView.Columns[9].Name = "שינוי באחוזים";

         holdingsDataGridView.Rows.Clear();
         //foreach (KeyValuePair<int, GeneralTypes.Position> holding in portfolioHoldings)
         for(int i=0; i<portfolioHoldings.Keys.Count; i++)
         {
            int bondID = portfolioHoldings.Keys.ElementAt(i);
            GeneralTypes.Bond bondData = m_Bridge.GetBondByID(bondID);
            GeneralTypes.Position curPosition = portfolioHoldings[bondID];

            holdingsDataGridView.Rows.Add();
            holdingsDataGridView.Rows[i].Cells[0].Value = bondData.Name;
            holdingsDataGridView.Rows[i].Cells[1].Value = bondID;
            holdingsDataGridView.Rows[i].Cells[2].Value = bondData.QualityRating;
            holdingsDataGridView.Rows[i].Cells[3].Value = bondData.Maham;
            holdingsDataGridView.Rows[i].Cells[4].Value = bondData.NetYield;
            holdingsDataGridView.Rows[i].Cells[5].Value = bondData.Value;
            holdingsDataGridView.Rows[i].Cells[6].Value = curPosition.BoughtDate.ToString("yyyy/MM/dd");
            holdingsDataGridView.Rows[i].Cells[7].Value = curPosition.ValueAtBuy;
            holdingsDataGridView.Rows[i].Cells[8].Value = curPosition.UnitsHeld;
            holdingsDataGridView.Rows[i].Cells[9].Value = (bondData.Value - curPosition.ValueAtBuy) / curPosition.ValueAtBuy;
         }
      }

      private void buyBondButton_Click(object sender, EventArgs e)
      {
         BuyBondDlg buyBondDlg = new BuyBondDlg(m_Bridge.GetListOfBonds_BRDG(), m_Bridge.GetComissionPct_BRDG(), portflioComboBox.Text);
         if (buyBondDlg.ShowDialog(this) == DialogResult.OK)
         {
            m_Bridge.BuyBondInPortfolio_BRDG(portflioComboBox.Text, buyBondDlg.BondIdToBuy, buyBondDlg.AmountToBuy, buyBondDlg.Comission);
            m_Bridge.SetComissionPct_BRDG(buyBondDlg.Comission);
            DisplayPortfolio(portflioComboBox.Text);
         }
      }

      private void sellBondButton_Click(object sender, EventArgs e)
      {
         Dictionary<int, GeneralTypes.Position> portfolioPositions = m_Bridge.GetPortfolioHoldings_BRDG(portflioComboBox.Text);
         List<GeneralTypes.Bond> portfolioBonds = new List<GeneralTypes.Bond>();
         foreach(int bondID in portfolioPositions.Keys)
         {
            portfolioBonds.Add(m_Bridge.GetBondByID(bondID));
         }
         SellBondDlg sellBondDlg = new SellBondDlg(portfolioBonds, m_Bridge.GetComissionPct_BRDG(), portflioComboBox.Text);
         if (sellBondDlg.ShowDialog(this) == DialogResult.OK)
         {
            m_Bridge.SellBondInPortfolio_BRDG(portflioComboBox.Text, sellBondDlg.BondIdToSell, sellBondDlg.Comission);
            m_Bridge.SetComissionPct_BRDG(sellBondDlg.Comission);
            DisplayPortfolio(portflioComboBox.Text);
         }
      }
   }
}