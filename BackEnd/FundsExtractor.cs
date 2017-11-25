using Bridge;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneralTypes;

namespace BackEnd
{
    //This class extracts a list of funds (קרנות) by parameters passed to it
    public class FundsExtractor
    {
        Action m_LaunchWebPageDownloadStartedMsg;
        WebController m_WebController;

        public FundsExtractor(WebController WebControl, Action LaunchWebPageDownloadStartedMsg)
        {
            m_LaunchWebPageDownloadStartedMsg = LaunchWebPageDownloadStartedMsg;
            m_WebController = WebControl;
        }

        public void FindFunds()
        {
            //let the frontside know that we are about to start downloading the funds data
            m_LaunchWebPageDownloadStartedMsg();

            NameValueCollection NVCollection = new NameValueCollection()
                #region Funds_10_percent_post_params
                {
                    { "Field1", "109" },
                    { "Field2", "134" },
                    { "Field3", "134" },
                    { "Field4", "הכל" },
                    { "Field5", "" },
                    { "Field6", "" },
                    { "Field7", "0" },
                    { "Field1Ind", "2" },
                    { "Field2Ind", "4" },
                    { "Field3Ind", "1" },
                    { "Field4Ind", "1" },
                    { "Field5Ind", "1" },
                    { "Field6Ind", "1" },
                    { "Field7Ind", "1" },
                    {"Freetext", "" },
                    {"from", "2017-10-07" },
                    {"to", "2017-10-07" }
                };
                #endregion

            //download funds data in a different thread
            Task.Run(() => AskForDataAndWait(NVCollection));
        }

        private void AskForDataAndWait(NameValueCollection PostRequestParams)
        {
            string[] WebPageData = m_WebController.PerformPostRequest("http://www.bizportal.co.il/mutualfunds/search", PostRequestParams);

            List<Fund> FundsList = new List<Fund>();

            foreach (string curLine in WebPageData)
            {
                if (curLine.Contains("\"<a href='/mutualfunds/quote/generalview/"))
                {
                    string DelimitedData = curLine.Split('/')[4];
                    string[] FundData = DelimitedData.Split('\'');
                    string NumberOfFund = FundData[0];
                    string NameOfFund = FundData[2];
                    FundsList.Add(new Fund(NameOfFund, Convert.ToInt32(NumberOfFund)));
                }
            }
        }
    }
}
