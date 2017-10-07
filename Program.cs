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
            DataDownloadStartedMsg DDLStartMsg = new DataDownloadStartedMsg();

            //initialize back end components
            WebController WebControl = new WebController();
            FundsExtractor FundsExtract = new FundsExtractor(WebControl, DDLStartMsg.LaunchEvent);
            BondsUpdater BondsUpdate = new BondsUpdater();

            //initialize the frontend to backend bridge
            BridgeToBackEnd Bridge = new BridgeToBackEnd(FundsExtract, BondsUpdate);

            //initialize and start the front end
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(Bridge, DDLStartMsg));
        }
    }
}
