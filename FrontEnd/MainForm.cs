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
        DataDownloadStartedMsg m_DownloadStarted;

        public Form1(BridgeToBackEnd Bridge, DataDownloadStartedMsg DownloadStartedMessage)
        {
            InitializeComponent();
            m_Bridge = Bridge;
            m_DownloadStarted = DownloadStartedMessage;
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            //subscribe to expected event - download start
            m_DownloadStarted.OnDownloadStarted += OnDownloadStarted;

            m_Bridge.ExtractFunds_BRDG();
        }

        private void OnDownloadStarted()
        {
            StatusLabel.Invoke((MethodInvoker)delegate
           {
               StatusLabel.Text = "Downloading, please wait...";
           });
        }

        private void UpdateBondsButton_Click(object sender, EventArgs e)
        {
            m_Bridge.UpdateBonds_BRDG();
        }
    }
}
