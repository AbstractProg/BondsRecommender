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

        public PortfoliosManager(BondsTableManager bondsTableManager)
        {
            m_bondsTableManager = bondsTableManager;
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
            Portfolio portfolio = new Portfolio(portfolioName, initialMoney);
        }

        public double GetPortfolioUninvestedMoney(string portfolioName)
        {
            Portfolio portfolio = new Portfolio(portfolioName);
            return portfolio.GetPortfolioUninvestedAmount();
        }

        public Dictionary<GeneralTypes.Bond, string> GetPortfolioHoldings(string portfolioName)
        {
            Portfolio portfolio = new Portfolio(portfolioName);
            Dictionary<int, string> activePositions = portfolio.GetPortfolioBonds();

            Dictionary<GeneralTypes.Bond, string> retVal = new Dictionary<GeneralTypes.Bond, string>();

            foreach(KeyValuePair<int, string> position in activePositions)
            {
                retVal.Add(m_bondsTableManager.GetBond(position.Key), position.Value);
            }
            return retVal;
        }
    }
}
