using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
   public class PortfoliosManager
   {
      BondsTableManager m_bondsTableManager;
      Dictionary<string, Portfolio> m_portfolioList;

      public PortfoliosManager(BondsTableManager bondsTableManager)
      {
         m_bondsTableManager = bondsTableManager;
         m_portfolioList = new Dictionary<string, Portfolio>();
         foreach (string portfolioName in GetPortfolioNames())
         {
            m_portfolioList.Add(portfolioName, new Portfolio(portfolioName));
         }
      }

      public List<string> GetPortfolioNames()
      {
         string currentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

         string[] FilesInFolder = Directory.GetFiles(currentDirectory);

         List<string> portfolioNames = new List<string>();

         foreach (string file in FilesInFolder)
         {
            if (Path.GetExtension(file) == GeneralTypes.GeneralConsts.PORTFOLIO_FILE_EXTENSION)
               portfolioNames.Add(Path.GetFileNameWithoutExtension(file));
         }

         return portfolioNames;
      }

      public void CreateNewPortfolio(string portfolioName, double initialMoney)
      {
         m_portfolioList.Add(portfolioName, new Portfolio(portfolioName, initialMoney));
      }

      public double GetPortfolioUninvestedMoney(string portfolioName)
      {
         return m_portfolioList[portfolioName].GetPortfolioUninvestedAmount();
      }

      public Dictionary<int, GeneralTypes.Position> GetPortfolioHoldings(string portfolioName)
      {
         return m_portfolioList[portfolioName].GetPortfolioBonds();
      }

      public void BuyNewBond(string portfolioName, int bondID, int units, double comissionPercent)
      {
         GeneralTypes.Bond bondToBuy = m_bondsTableManager.GetBond(bondID);
         m_portfolioList[portfolioName].BuyBond(bondID, bondToBuy.Name, bondToBuy.Value, units, comissionPercent);
      }

      public void SellExistingBond(string portfolioName, int bondID, double comissionPercent)
      {
         GeneralTypes.Bond bondToSell = m_bondsTableManager.GetBond(bondID);
         m_portfolioList[portfolioName].SellBond(bondID, bondToSell.Name, bondToSell.Value, comissionPercent);
      }
   }
}