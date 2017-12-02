using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackEnd;
using Bridge;
using FrontEnd;

namespace BondsRecommendor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //initialize the messages from backend
            BridgeMsg.DataDownloadStartedMsg DDLStartMsg = new BridgeMsg.DataDownloadStartedMsg();
            BridgeMsg.DownloadProgressMsg DownloadProgMsg = new BridgeMsg.DownloadProgressMsg();
            BridgeMsg.ListOfBondsMsg BondsListMsg = new BridgeMsg.ListOfBondsMsg();

            //initialize back end components
            ConfigurationManager ConfigurationMgr = new ConfigurationManager();
            WebController WebControl = new WebController();
            FundsExtractor FundsExtract = new FundsExtractor(WebControl, DDLStartMsg.LaunchEvent);
            BondsTableManager BondsTableMgr = new BondsTableManager();
            BondsUpdater BondsUpdate = new BondsUpdater(WebControl, BondsTableMgr, DDLStartMsg, DownloadProgMsg, BondsListMsg, ConfigurationMgr);
            PortfoliosManager PFMgr = new PortfoliosManager(BondsTableMgr);

            //initialize the frontend to backend bridge
            BridgeToBackEnd Bridge = new BridgeToBackEnd(FundsExtract, BondsUpdate, ConfigurationMgr, BondsTableMgr, PFMgr);

            //initialize and start the front end
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(Bridge, DDLStartMsg, DownloadProgMsg, BondsListMsg));
        }
    }
}
