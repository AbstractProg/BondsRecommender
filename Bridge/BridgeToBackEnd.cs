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

      public void UpdateBonds_BRDG(List<string> qualitiesToDownload, double minMahamToDownload, double maxMahamToDownload)
      {
         m_BondsUpdater.UpdateBondsData(qualitiesToDownload, minMahamToDownload, maxMahamToDownload);
      }

      public void UpdateBondsFile_BRDG()
      {
         m_BondsTableMgr.UpdateDBFile();
      }

      public List<string> GetPortfolioNames_BRDG()
      {
         return m_PortfoliosManager.GetPortfolioNames();
      }

      public double GetPortfolioFreeMoney_BRDG(string portfolioName)
      {
         return m_PortfoliosManager.GetPortfolioUninvestedMoney(portfolioName);
      }

      public Dictionary<GeneralTypes.Bond, string> GetPortfolioHoldings_BRDG(string portfolioName)
      {
         return m_PortfoliosManager.GetPortfolioHoldings(portfolioName);
      }

      public void CreateNewPortfolio_BRDG(string portfolioName, double initialMoney)
      {
         m_PortfoliosManager.CreateNewPortfolio(portfolioName, initialMoney);
      }

      public List<string> QualityToDownload_BRDG => m_ConfigurationManager.QualityToDownload;
      public double MinMahamToDownload_BRDG => m_ConfigurationManager.MinMahamToDownload;
      public double MaxMahamToDownload_BRDG => m_ConfigurationManager.MaxMahamToDownload;
      public List<string> QualityToDisplay_BRDG=> m_ConfigurationManager.QualityToDisplay;
      public double MinMahamToDisplay_BRDG => m_ConfigurationManager.MinMahamToDisplay;
      public double MaxMahamToDisplay_BRDG => m_ConfigurationManager.MaxMahamToDisplay;

      public void UpdateCfgFile_BRDG(List<string> qualityToDownload, double minMahamToDownload, double maxMahamToDownload,
         List<string> qualityToDisplay, double minMahamToDisplay, double maxMahamToDisplay)
      {
         m_ConfigurationManager.UpdateCfgFile(qualityToDownload, minMahamToDownload, maxMahamToDownload,
            qualityToDisplay, minMahamToDisplay, maxMahamToDisplay);
      }
   }
}