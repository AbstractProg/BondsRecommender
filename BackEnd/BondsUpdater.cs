using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class BondsUpdater
    {
        public void UpdateBondsData()
        {
            Task.Run(() => AskForDataAndWait());
        }

        public void AskForDataAndWait()
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Only a test!");

            //TODO: move NameValueCollections of post requests to general types
            byte[] RawResponse =
                webClient.DownloadData("http://www.bizportal.co.il/bonds/search?Branch=300&BranchInd=1&Sector=all&SectorInd=1&Freetext=");

            string responseInOneLine = System.Text.Encoding.UTF8.GetString(RawResponse);
            string[] response = responseInOneLine.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            int x = 3 + 5;
        }
    }
}
