using GeneralTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BackEnd
{
   class Portfolio
   {
      public Portfolio(string name, double initialAmount)
      {
         m_name = name;
         m_uninvestedMoney = initialAmount;
         m_Positions = new Dictionary<int, Position>();
         UpdatePortfolioFile();
      }

      public Portfolio(string name)
      {
         m_name = name;
         StreamReader file = new StreamReader(name + GeneralConsts.PORTFOLIO_FILE_EXTENSION);
         string str = file.ReadLine();
         m_uninvestedMoney = Convert.ToDouble(str);
         m_Positions = new Dictionary<int, Position>();
         while ((str = file.ReadLine()) != null)
         {
            string[] positionData = str.Split('@');
            m_Positions.Add(Convert.ToInt32(positionData[0]), new Position(Convert.ToDateTime(positionData[1]), Convert.ToDouble(positionData[2]),
                Convert.ToInt32(positionData[3])));
         }
      }

      //key is the ID of the bond
      private Dictionary<int, Position> m_Positions;
      private string m_name;
      private double m_uninvestedMoney;

      public void BuyBond(int bondID, string bondName, double currentValue, int amountOfUnits, double comissionPercent)
      {
         double comissionValue = currentValue * amountOfUnits * comissionPercent / 100;
         if (m_uninvestedMoney < (currentValue * amountOfUnits) + comissionValue)
            throw new Exception("Not enough money!");
         if (m_Positions.Keys.Contains(bondID))
            throw new Exception("This version not supporting buying more of a security you already have");
         m_Positions.Add(bondID, new Position(DateTime.Today, currentValue, amountOfUnits));
         m_uninvestedMoney -= (currentValue * amountOfUnits + comissionValue);
         UpdatePortfolioFile();
         AddBuyToHistory(bondID, bondName, currentValue, amountOfUnits);
      }

      public void SellBond(int bondID, string bondName, double currentValue, double comissionPercent)
      {
         Position positionToSell = m_Positions[bondID];
         double comissionValue = currentValue * positionToSell.UnitsHeld * comissionPercent / 100;
         AddSellToHistory(bondID, bondName, currentValue, positionToSell.UnitsHeld);
         m_uninvestedMoney += positionToSell.UnitsHeld * currentValue;
         m_uninvestedMoney -= comissionValue;
         m_Positions.Remove(bondID);
         UpdatePortfolioFile();
      }

      private void UpdatePortfolioFile()
      {
         StreamWriter file = new StreamWriter(m_name + GeneralConsts.PORTFOLIO_FILE_EXTENSION);
         file.WriteLine(m_uninvestedMoney);
         foreach (KeyValuePair<int, Position> position in m_Positions)
         {
            file.WriteLine("{0}@{1}@{2}@{3}", position.Key, position.Value.BoughtDate.ToString("dd/MM/yy", null),position.Value.ValueAtBuy.ToString(),
               position.Value.UnitsHeld.ToString());
         }
         file.Close();
      }

      public double GetPortfolioUninvestedAmount()
      {
         return m_uninvestedMoney;
      }

      public Dictionary<int, Position> GetPortfolioBonds()
      {
         return m_Positions;
      }

      private void AddBuyToHistory(int bondID, string bondName, double currentValue, int amountOfUnits)
      {
         StreamWriter historyFile = new StreamWriter(m_name + GeneralConsts.PORTFOLIO_HISTORY_FILE_EXTENSION, true);
         historyFile.WriteLine("{0},{1},{2},{3}", bondID, bondName, currentValue, amountOfUnits);
         historyFile.Close();
      }

      private void AddSellToHistory(int bondID, string bondName, double currentValue, int amountOfUnits)
      {
         StreamWriter historyFile = new StreamWriter(m_name + GeneralConsts.PORTFOLIO_HISTORY_FILE_EXTENSION, true);
         historyFile.WriteLine("{0},{1},{2},{3}", bondID, bondName, -currentValue, amountOfUnits);
         historyFile.Close();
      }
   }
}