using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class BondsUpdater
    {
        const int NumDigitsInBondSerial = 7;
        const int NumOfRowsForBond = 11;

        const int NameIDInFile = 1;
        const int MahamIDInFile = 6;
        const int Quality1IDInFile = 8;
        const int Quality2IDInFile = 9;
        const int NumberIDInFile = 10;

        List<string> m_AllQualityValues;
        ConfigurationManager m_cfgMgr;


        class JsonItem
        {
            public string AggregateResults;
            public JsonDataItem Data;
            public string Errors;
            public string Total;
        }

        class JsonDataItem
        {
            public string ColumnData1;
            public string ColumnData2;
            public string ColumnData3;
            public string ColumnData4;
            public string ColumnData5;
            public string ColumnData6;
            public string ColumnData7;
            public string ColumnData8;
            public string ColumnData9;
            public string ColumnData10;
            public string ColumnData11;
            public string ColumnData12;
            public string ColumnData13;
            public string ColumnData14;
            public string ColumnData15;
            public string ColumnData16;
            public string ColumnData17;
            public string ColumnData18;
            public string ColumnData19;
            public string ColumnData20;
            public string ColumnData21;
            public string ColumnData22;
            public string ColumnData23;
            public string ColumnData24;
            public string ColumnData25;
            public string Link;
        }

        WebController m_WebController;
        BridgeMsg.DataDownloadStartedMsg m_dDownloadStartedPublisher;
        BridgeMsg.DownloadProgressMsg m_downloadProgressPublisher;
        BridgeMsg.ListOfBondsMsg m_listPublisher;

        public BondsUpdater(WebController WebControl,BridgeMsg.DataDownloadStartedMsg dDownloadStartedPublisher,
            BridgeMsg.DownloadProgressMsg downloadProgressPublisher, BridgeMsg.ListOfBondsMsg listPublisher, ConfigurationManager cfgMgr)
        {
            m_WebController = WebControl;
            m_dDownloadStartedPublisher = dDownloadStartedPublisher;
            m_downloadProgressPublisher = downloadProgressPublisher;
            m_listPublisher = listPublisher;
            m_cfgMgr = cfgMgr;

            m_AllQualityValues = new List<string> {
                "Aaa", "Aa1", "Aa2", "Aa3", "A1", "A2", "A3", "Ba1", "Baa1", "Baa2", "Baa3",
                "AAA", "AA+", "AA", "AA-", "A+", "A", "A-", "BBB+", "BBB", "BBB-", "CC", "CCC", "D"};
        }

        public void UpdateBondsData()
        {
            NameValueCollection NVCollection = new NameValueCollection()
                #region ALL_BONDS_POST_PARAMS
                {
                {"sort", "ColumnData1-asc" },
                { "page", "1" },
                {"pageSize", "700" },
                {"group", "" },
                {"filter", "" },
                {"initialBranch", "" },
                {"initialSector", "" },
                {"freetext", "" },
                {"Branch", "300" },
                { "Sector", "all" },
                {"byId", "" }
                };
            #endregion
            List<GeneralTypes.Bond> AllBonds = DownoladAndParseBondsData(NVCollection);

            Task.Run(()=>FindNetYieldForRankedBonds(AllBonds));
        }

        public List<GeneralTypes.Bond> DownoladAndParseBondsData(NameValueCollection PostRequestParams)
        {
            List<GeneralTypes.Bond> AllBonds = new List<GeneralTypes.Bond>();

            m_dDownloadStartedPublisher.LaunchEvent();
            string[] WebPageData = m_WebController.PerformPostRequest("http://www.bizportal.co.il/bonds/Search/SearchResults_AjaxBinding_Read", PostRequestParams);
            string[] AllBondNumbersAsStrings = WebPageData[0].Split(new string[] { "ColumnData25" }, StringSplitOptions.None);
            List<int> AllBondNumbers = new List<int>();
            for (int i = 0; i < AllBondNumbersAsStrings.Length - 1; i++)
            {
                string bondName, bondQuality;
                int bondSerialNum;
                double maham;

                //extract basic properties of the bond
                ExtractBondData(AllBondNumbersAsStrings[i], out bondName, out bondSerialNum, out maham, out bondQuality);

                AllBonds.Add(new GeneralTypes.Bond(bondName, bondSerialNum, bondQuality, maham));
            }

            return AllBonds;
        }

        private void ExtractBondData(string BondData, out string bondName, out int bondSerialNum, out double maham, out string bondQuality)
        {
            //extract name
            bondName = ExtractSpecificField(BondData, NameIDInFile);
            
            //extract serial number
            string serialNumberAsString = ExtractSpecificField(BondData, NumberIDInFile);
            bondSerialNum = Convert.ToInt32(serialNumberAsString);

            //extract quality type 1
            string quality1 = ExtractSpecificField(BondData, Quality1IDInFile);

            //extract quality type 2
            string quality2 = ExtractSpecificField(BondData, Quality2IDInFile);

            //extract maham
            string mahamAsString = ExtractSpecificField(BondData, MahamIDInFile);
            maham = Convert.ToDouble(mahamAsString);

            //select the correct quality
            if (m_AllQualityValues.Contains(quality1))
                bondQuality = quality1;
            else if (m_AllQualityValues.Contains(quality2))
                bondQuality = quality2;
            else
                bondQuality = "Unranked";
        }

        private string ExtractSpecificField(string bondData, int fieldNum)
        {
            int startIndex = bondData.IndexOf("ColumnData" + fieldNum) + ("ColumnData" + fieldNum).Length + "\":\"".Length;
            int endIndex = bondData.IndexOf("\",\"ColumnData" + (fieldNum + 1));
            return bondData.Substring(startIndex, endIndex - startIndex);
        }

        private double FindNetYieldOfBond(int bondSerialNum)
        {
            string curBondProps = m_WebController.PerformURLRequest("http://www.bizportal.co.il/bonds/quote/generalview/" + bondSerialNum);
            //find נטו להחזקה
            string[] netYieldStringWithTail = curBondProps.Split(new string[] { "×ª×©×•×\u0090×” × ×˜×•<span><strong>" }, StringSplitOptions.None);
            string[] netYieldStringString = netYieldStringWithTail[1].Split('<');
            return Convert.ToDouble(netYieldStringString[0]);
        }
        
        private void FindNetYieldForRankedBonds(List<GeneralTypes.Bond> AllBonds)
        {
            List<GeneralTypes.Bond> AllDownloadedBonds = new List<GeneralTypes.Bond>();

            for(int i=0; i<AllBonds.Count; i++)
            {
                GeneralTypes.Bond curBond = AllBonds[i];

                //For the bonds that are defined in the configuration file, download the net yield and add to list of downloaded bonds
                if (m_cfgMgr.QualityToDownload.Contains(curBond.QualityRating) &&
                    m_cfgMgr.MinMahamToDownload < curBond.Maham &&
                    m_cfgMgr.MaxMahamToDownload > curBond.Maham)
                {
                    double bondNetYield = FindNetYieldOfBond(curBond.SerialNumber);
                    AllDownloadedBonds.Add(new GeneralTypes.Bond(curBond, bondNetYield));
                }
                m_downloadProgressPublisher.LaunchEvent(i * 100 / AllBonds.Count, curBond.Name);
            }

            AllDownloadedBonds = AllDownloadedBonds.OrderByDescending(o => o.NetYield).ToList();
            m_listPublisher.LaunchEvent(AllDownloadedBonds);
        }

    }
}
