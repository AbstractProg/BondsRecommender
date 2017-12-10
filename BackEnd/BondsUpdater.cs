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

      const int NameIDInFile = 1;
      const int CurValueIDInFile = 2;
      const int MahamIDInFile = 6;
      const int Quality1IDInFile = 8;
      const int Quality2IDInFile = 9;
      const int NumberIDInFile = 10;
      const int IndexedByIDInFile = 13;

      WebController m_WebController;
      BondsTableManager m_BondsTableManager;
      BridgeMsg.DataDownloadStartedMsg m_dDownloadStartedPublisher;
      BridgeMsg.DownloadProgressMsg m_downloadProgressPublisher;
      BridgeMsg.ListOfBondsMsg m_listPublisher;

      public BondsUpdater(WebController WebControl, BondsTableManager BondsTableManager, BridgeMsg.DataDownloadStartedMsg dDownloadStartedPublisher,
          BridgeMsg.DownloadProgressMsg downloadProgressPublisher, BridgeMsg.ListOfBondsMsg listPublisher, ConfigurationManager cfgMgr)
      {
         m_WebController = WebControl;
         m_BondsTableManager = BondsTableManager;
         m_dDownloadStartedPublisher = dDownloadStartedPublisher;
         m_downloadProgressPublisher = downloadProgressPublisher;
         m_listPublisher = listPublisher;
      }

      public void DownloadBondsData(List<string> qualitiesToDownload, List<GeneralTypes.IndexType> indexesToDownload, double minMahamToDownload,
         double maxMahamToDownload)
      {
         NameValueCollection NVCollection = new NameValueCollection()
                #region ALL_BONDS_POST_PARAMS
                {
                {"sort", "ColumnData1-asc" },
                { "page", "1" },
                {"pageSize", "700" },
                {"group", "" },
                {"filter", "" },
                {"initialBranch", "3_7" },
                {"initialSector", "" },
                {"freetext", "" },
                {"Branch", "300" },
                { "Sector", "all" },
                {"byId", "" }
                };
         #endregion
         List<GeneralTypes.Bond> AllBonds = DownoladAndParseBondsData(NVCollection, qualitiesToDownload);

         Task.Run(() => FindAdvancedDataForWantedBonds(AllBonds, qualitiesToDownload, indexesToDownload, minMahamToDownload, maxMahamToDownload));
      }

      public List<GeneralTypes.Bond> DownoladAndParseBondsData(NameValueCollection PostRequestParams, List<string> qualitiesToDownload)
      {
         List<GeneralTypes.Bond> AllBonds = new List<GeneralTypes.Bond>();

         m_dDownloadStartedPublisher.LaunchEvent();
         string[] WebPageData = m_WebController.PerformPostRequest("http://www.bizportal.co.il/bonds/Search/SearchResults_AjaxBinding_Read", PostRequestParams);
         string[] AllBondsDataAsStrings = WebPageData[0].Split(new string[] { "ColumnData25" }, StringSplitOptions.None);
         for (int i = 0; i < AllBondsDataAsStrings.Length - 1; i++)
         {
            //extract basic properties of the bond
            ExtractBondBasicData(qualitiesToDownload, AllBondsDataAsStrings[i], out string bondName, out double curValue, out int bondSerialNum, out double maham, out string bondQuality, out GeneralTypes.IndexType index);

            AllBonds.Add(new GeneralTypes.Bond(bondName, bondSerialNum, curValue, bondQuality, maham, index, 0, new DateTime()));
         }

         return AllBonds;
      }

      private void ExtractBondBasicData(List<string> qualitiesToDownload, string BondData, out string bondName, out double curValue, out int bondSerialNum,
         out double maham, out string bondQuality, out GeneralTypes.IndexType index)
      {
         //extract name
         bondName = ExtractSpecificField(BondData, NameIDInFile);

         //extract current value
         string curValueAsString = ExtractSpecificField(BondData, CurValueIDInFile);
         curValue = Convert.ToDouble(curValueAsString);

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

         //extract index
         string indexedBy = ExtractSpecificField(BondData, IndexedByIDInFile);
         if (indexedBy == "קונצרני צמוד מט\\\"ח" ||
             indexedBy == "צמוד מט\\\"ח")
            index = GeneralTypes.IndexType.Dollar;
         else if (indexedBy == "קונצרני שקלי")
            index = GeneralTypes.IndexType.Shekel;
         else if (indexedBy == "לא צמוד")
            index = GeneralTypes.IndexType.Fixed;
         else if (indexedBy == "לא צמוד" ||
             indexedBy == "קונצרני שקלי ריבית משתנה")
            index = GeneralTypes.IndexType.VaryingInterest;
         else if (indexedBy == "קונצרני צמוד מדד" ||
             indexedBy == "צמוד מדד")
            index = GeneralTypes.IndexType.Madad;
         else if (indexedBy.Contains("ממשלתי") || indexedBy == "null")
            index = GeneralTypes.IndexType.IrrelevantSecurity;

         else
            throw new Exception("Index type not found");

         //select the correct quality
         if (qualitiesToDownload.Contains(quality1))
            bondQuality = quality1;
         else if (qualitiesToDownload.Contains(quality2))
            bondQuality = quality2;
         else
            bondQuality = "Unranked";
      }

      private string ExtractSpecificField(string bondData, int fieldNum)
      {
         int startIndex = bondData.IndexOf("ColumnData" + fieldNum) + ("ColumnData" + fieldNum).Length + "\":\"".Length;
         int endIndex = bondData.IndexOf("\",\"ColumnData" + (fieldNum + 1));
         if (endIndex == -1)
         {
            startIndex = bondData.IndexOf("ColumnData" + fieldNum) + ("ColumnData" + fieldNum).Length + "\":".Length;
            endIndex = bondData.IndexOf(",\"ColumnData" + (fieldNum + 1));
         }
         return bondData.Substring(startIndex, endIndex - startIndex);
      }

      private void ExtractBondAdvancedData(int bondSerialNum, out double netYield, out DateTime exDate)
      {
         string curBondProps = m_WebController.PerformURLRequest("http://www.bizportal.co.il/bonds/quote/generalview/" + bondSerialNum);
         //find נטו להחזקה
         string[] netYieldStringWithTail = curBondProps.Split(new string[] { "×ª×©×•×\u0090×” × ×˜×•<span><strong>" }, StringSplitOptions.None);
         string[] netYieldString = netYieldStringWithTail[1].Split('<');
         try
         {
            netYield = Convert.ToDouble(netYieldString[0]);
         }
         catch { netYield = 0; }
         string[] exDateStringWithTail = curBondProps.Split(new string[] {
         "<span class=\"FontBlueHeader\">×ª×\u0090×¨×™×š ×\u0090×§×¡</span>\r\n                        </td>\r\n                        <td>\r\n                            <span class=\"\">" },
         StringSplitOptions.None);
         string[] exDateString = exDateStringWithTail[1].Split('<');
         exDate = DateTime.ParseExact(exDateString[0], "dd/MM/yy", null);
      }

      private void FindAdvancedDataForWantedBonds(List<GeneralTypes.Bond> AllBonds, List<string> qualitiesToDownload, List<GeneralTypes.IndexType> indexesToDownload,
         double minMahamToDownload, double maxMahamToDownload)
      {
         List<GeneralTypes.Bond> AllDownloadedBonds = new List<GeneralTypes.Bond>();

         for (int i = 0; i < AllBonds.Count; i++)
         {
            GeneralTypes.Bond curBond = AllBonds[i];

            //For the bonds that are defined in the configuration file, download the net yield and add to list of downloaded bonds
            if (qualitiesToDownload.Contains(curBond.QualityRating) &&
               indexesToDownload.Contains(curBond.Index) &&
                minMahamToDownload < curBond.Maham &&
                maxMahamToDownload > curBond.Maham)
            {
               try
               {
                  ExtractBondAdvancedData(curBond.SerialNumber, out double bondNetYield, out DateTime bondExDate);
                  GeneralTypes.Bond newBond = new GeneralTypes.Bond(curBond, bondNetYield, bondExDate);
                  AllDownloadedBonds.Add(newBond);
                  m_BondsTableManager.UpdateBond(newBond);
               }
               catch
               {
                  //if any error occured continue to the next bond
               }
            }
            m_downloadProgressPublisher.LaunchEvent(i * 100 / AllBonds.Count, curBond.Name);
         }

         m_listPublisher.LaunchEvent(AllDownloadedBonds);
         m_BondsTableManager.UpdateDBFile();
      }
   }
}
