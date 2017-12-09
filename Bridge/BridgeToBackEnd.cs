using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd;
using System.Windows.Forms;

namespace Bridge
{
   public class BridgeToBackEnd
   {
      FundsExtractor m_FundsExtractor;
      BondsUpdater m_BondsUpdater;
      ConfigurationManager m_ConfigurationManager;
      BondsTableManager m_BondsTableMgr;
      PortfoliosManager m_PortfoliosManager;

      public BridgeToBackEnd(FundsExtractor FundsExtractor_, BondsUpdater BondsUpdater_, ConfigurationManager ConfigurationManager,
         BondsTableManager BondsTableManager_, PortfoliosManager PortfoliosManager_)
      {
         m_FundsExtractor = FundsExtractor_;
         m_BondsUpdater = BondsUpdater_;
         m_ConfigurationManager = ConfigurationManager;
         m_BondsTableMgr = BondsTableManager_;
         m_PortfoliosManager = PortfoliosManager_;
      }

      public void ExtractFunds_BRDG()
      {
         m_FundsExtractor.FindFunds();
      }

      //********************************
      //*** bonds updater
      //********************************
      public void DownloadBonds_BRDG(List<string> qualitiesToDownload, List<GeneralTypes.IndexType> indexesToDownload, double minMahamToDownload, double maxMahamToDownload)
      {
         m_BondsUpdater.DownloadBondsData(qualitiesToDownload, indexesToDownload, minMahamToDownload, maxMahamToDownload);
      }

      //********************************
      //*** Bonds table manager
      //********************************
      public void UpdateBondsFile_BRDG()
      {
         m_BondsTableMgr.UpdateDBFile();
      }

      public List<GeneralTypes.Bond> GetListOfBonds_BRDG()
      {
         return m_BondsTableMgr.GetAllBonds();
      }

      public GeneralTypes.Bond GetBondByID(int bondID)
      {
         return m_BondsTableMgr.GetBond(bondID);
      }

      //********************************
      //*** Portfolio manager
      //********************************
      public List<string> GetPortfolioNames_BRDG()
      {
         return m_PortfoliosManager.GetPortfolioNames();
      }

      public double GetPortfolioFreeMoney_BRDG(string portfolioName)
      {
         return m_PortfoliosManager.GetPortfolioUninvestedMoney(portfolioName);
      }

      public Dictionary<int, GeneralTypes.Position> GetPortfolioHoldings_BRDG(string portfolioName)
      {
         return m_PortfoliosManager.GetPortfolioHoldings(portfolioName);
      }

      public void CreateNewPortfolio_BRDG(string portfolioName, double initialMoney)
      {
         m_PortfoliosManager.CreateNewPortfolio(portfolioName, initialMoney);
      }

      public void BuyBondInPortfolio_BRDG(string portfolioName, int bondID, int amountToBuy, double comissionPercentage)
      {
         m_PortfoliosManager.BuyNewBond(portfolioName, bondID, amountToBuy, comissionPercentage);
      }

      public void SellBondInPortfolio_BRDG(string portfolioName, int bondID, double comissionPercentage)
      {
         m_PortfoliosManager.SellExistingBond(portfolioName, bondID, comissionPercentage);
      }

      //********************************
      //*** Configuration manager
      //********************************
      public List<string> QualityToDownload_BRDG => m_ConfigurationManager.QualityToDownload;
      public List<GeneralTypes.IndexType> IndexesToDownload_BRDG => m_ConfigurationManager.IndexesToDownload;
      public double MinMahamToDownload_BRDG => m_ConfigurationManager.MinMahamToDownload;
      public double MaxMahamToDownload_BRDG => m_ConfigurationManager.MaxMahamToDownload;
      public List<string> QualityToDisplay_BRDG=> m_ConfigurationManager.QualityToDisplay;
      public List<GeneralTypes.IndexType> IndexesToDisplay_BRDG => m_ConfigurationManager.IndexesToDisplay;
      public double MinMahamToDisplay_BRDG => m_ConfigurationManager.MinMahamToDisplay;
      public double MaxMahamToDisplay_BRDG => m_ConfigurationManager.MaxMahamToDisplay;

      public void UpdateCfgFile_BRDG(List<string> qualityToDownload, List<GeneralTypes.IndexType> indexesToDownload, double minMahamToDownload,
         double maxMahamToDownload, List<string> qualityToDisplay, List<GeneralTypes.IndexType> indexesToDisplay, double minMahamToDisplay,
         double maxMahamToDisplay)
      {
         m_ConfigurationManager.UpdateCfgFile(qualityToDownload, indexesToDownload, minMahamToDownload, maxMahamToDownload,
            qualityToDisplay, indexesToDisplay, minMahamToDisplay, maxMahamToDisplay, m_ConfigurationManager.ComissionPercentage);
      }
      public double GetComissionPct_BRDG()
      {
         return m_ConfigurationManager.ComissionPercentage;
      }
      public void SetComissionPct_BRDG(double newComission)
      {
         m_ConfigurationManager.ComissionPercentage = newComission;
      }
   }
}