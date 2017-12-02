using GeneralTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BackEnd
{
   class Position
   {
      public Position(DateTime boughtDate, double valueAtBuy, double unitsBought)
      {
         BoughtDate = boughtDate;
         ValueAtBuy = valueAtBuy;
         UnitsHeld = unitsBought;
      }
      //public Bond BondHeld { get; }
      public DateTime BoughtDate { get; set; }
      public double ValueAtBuy { get; set; }
      public double UnitsHeld { get; set; }
      public override string ToString()
      {
         return BoughtDate + "@" + ValueAtBuy + "@" + UnitsHeld; ;
      }
   }

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
                Convert.ToDouble(positionData[3])));
         }
      }

      private Dictionary<int, Position> m_Positions;
      private string m_name;
      //private List<Position> m_ListOfPositions;
      private double m_uninvestedMoney;

      public void BuyBond(int bondID, double currentValue, double amountOfUnits)
      {
         if (m_uninvestedMoney < currentValue * amountOfUnits)
            throw new Exception("Not enough money!");
         if (m_Positions.Keys.Contains(bondID))
            throw new Exception("This version not supporting buying more of a security you already have");
         m_Positions.Add(bondID, new Position(DateTime.Today, currentValue, amountOfUnits));
         m_uninvestedMoney -= currentValue * amountOfUnits;
         UpdatePortfolioFile();
      }

      public void SellBond(int bondID, double currentValue)
      {
         Position positionToSell = m_Positions[bondID];
         m_uninvestedMoney += positionToSell.UnitsHeld * currentValue;
         m_Positions.Remove(bondID);
         UpdatePortfolioFile();
      }

      private void UpdatePortfolioFile()
      {
         StreamWriter file = new StreamWriter(m_name + GeneralConsts.PORTFOLIO_FILE_EXTENSION);
         file.WriteLine(m_uninvestedMoney);
         foreach (KeyValuePair<int, Position> position in m_Positions)
         {
            file.WriteLine(position.Key + "@" + position.ToString());
         }
         file.Close();
      }

      public double GetPortfolioUninvestedAmount()
      {
         return m_uninvestedMoney;
      }

      public Dictionary<int, string> GetPortfolioBonds()
      {
         Dictionary<int, string> bondsAsStrings = new Dictionary<int, string>();

         foreach (KeyValuePair<int, Position> position in m_Positions)
         {
            bondsAsStrings.Add(position.Key, position.ToString());
         }
         return bondsAsStrings;
      }
   }
}