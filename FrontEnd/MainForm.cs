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
    public partial class Form1 : Form
    {
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

            m_Bridge.UpdateBonds_BRDG();
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
                ResultsGridView.ColumnCount = 4;
                ResultsGridView.Columns[0].Name = "שם";
                ResultsGridView.Columns[1].Name = "מספר";
                ResultsGridView.Columns[2].Name = "דירוג";
                ResultsGridView.Columns[3].Name = "תשואה נטו";

                foreach (GeneralTypes.Bond curBond in bondList)
                {
                    string[] row = new string[] { curBond.Name, curBond.SerialNumber.ToString(), curBond.QualityRating, curBond.NetYield.ToString()};
                    ResultsGridView.Rows.Add(row);
                }
            });
        }
    }
}
