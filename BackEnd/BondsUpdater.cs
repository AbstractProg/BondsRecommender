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
            BridgeMsg.DownloadProgressMsg downloadProgressPublisher, BridgeMsg.ListOfBondsMsg listPublisher)
        {
            m_WebController = WebControl;
            m_dDownloadStartedPublisher = dDownloadStartedPublisher;
            m_downloadProgressPublisher = downloadProgressPublisher;
            m_listPublisher = listPublisher;
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
            string[] AllBondNumbersAsStrings = WebPageData[0].Split(new string[] { "ColumnData10" }, StringSplitOptions.None);
            List<int> AllBondNumbers = new List<int>();
            for (int i = 1; i < AllBondNumbersAsStrings.Length; i++)
            {
                string bondName, bondQuality;
                int bondSerialNum;

                //extract basic properties of the bond
                ExtractBondData(AllBondNumbersAsStrings[i], out bondName, out bondSerialNum, out bondQuality);

                AllBonds.Add(new GeneralTypes.Bond(bondName, bondSerialNum, bondQuality));
            }

            return AllBonds;
        }

        private void ExtractBondData(string BondData, out string bondName, out int bondSerialNum, out string bondQuality)
        {
            string[] AllBondData = BondData.Split(new string[] { "\":\"" }, StringSplitOptions.None);

            //extract serial number
            string bondNum = AllBondData[1].Substring(0, NumDigitsInBondSerial);
            bondSerialNum = Convert.ToInt32(bondNum);

            //extract name
            string[] bondNameArray = AllBondData[2].Split('"');
            bondName = bondNameArray[0];
            if(bondName.Contains("אול"))
            {
                int x = 7;
            }

            //extract quality
            if (AllBondData.Length >= 20)
            {
                string[] bondQualityArr = AllBondData[18].Split('"');
                bondQuality = bondQualityArr[0];
                if(bondQuality=="")
                {
                    bondQualityArr = AllBondData[19].Split('"');
                    bondQuality = bondQualityArr[0];
                    if (bondQuality == "")
                        bondQuality = "Unranked";
                }
            }
            else
                bondQuality = "Unranked";
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
            List<GeneralTypes.Bond> AllRankedBonds = new List<GeneralTypes.Bond>();

            for(int i=0; i<AllBonds.Count; i++)
            {
                GeneralTypes.Bond curBond = AllBonds[i];
                if(curBond.Name.Contains("אול"))
                {
                    int x = 7;
                }
                //if (curBond.QualityRating == "AAA" || curBond.QualityRating == "AA+" || curBond.QualityRating == "AA" ||
                //    curBond.QualityRating == "AA-" || curBond.QualityRating == "A+" || curBond.QualityRating == "A" ||
                //    curBond.QualityRating == "Aaa" || curBond.QualityRating == "Aa2" || curBond.QualityRating == "Aa3" ||
                //    curBond.QualityRating == "A1" || curBond.QualityRating == "A2")
                    if (curBond.QualityRating == "A2")
                {
                        double bondNetYield = FindNetYieldOfBond(curBond.SerialNumber);
                    AllRankedBonds.Add(new GeneralTypes.Bond(curBond, bondNetYield));
                }
                m_downloadProgressPublisher.LaunchEvent(i * 100 / AllBonds.Count, curBond.Name);
            }

            AllRankedBonds = AllRankedBonds.OrderByDescending(o => o.NetYield).ToList();
            m_listPublisher.LaunchEvent(AllRankedBonds);
        }

    }
}
