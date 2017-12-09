using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeneralTypes
{
    public class GeneralConsts
    {
        public const string PORTFOLIO_FILE_EXTENSION = ".spf";
        public const string PORTFOLIO_HISTORY_FILE_EXTENSION = ".sph";
    }

    public enum IndexType
    {
        Shekel,
        VaryingInterest,
        Madad,
        Dollar,
        Fixed,
        IrrelevantSecurity
    }

   class IndexConverter
   {
      public static string IndexToString(GeneralTypes.IndexType indexType)
      {
         switch (indexType)
         {
            case GeneralTypes.IndexType.Dollar:
               return "דולר";
            case GeneralTypes.IndexType.Fixed:
               return "ריבית קבועה";
            case GeneralTypes.IndexType.Madad:
               return "מדד";
            case GeneralTypes.IndexType.Shekel:
               return "שקל";
            case GeneralTypes.IndexType.VaryingInterest:
               return "שקלי ריבית משתנה";
         }
         return "";
      }

      public static IndexType StringToIndex(string indexStr)
      {
         if (indexStr.Equals("דולר"))
            return IndexType.Dollar;
         else if (indexStr.Equals("ריבית קבועה"))
            return IndexType.Fixed;
         else if (indexStr.Equals("מדד"))
            return IndexType.Madad;
         else if (indexStr.Equals("שקל"))
            return IndexType.Shekel;
         else if (indexStr.Equals("שקלי ריבית משתנה"))
            return IndexType.VaryingInterest;
         else
            throw new Exception("Invalid index");
      }
   }

   public class Position
   {
      public Position(DateTime boughtDate, double valueAtBuy, int unitsBought)
      {
         BoughtDate = boughtDate;
         ValueAtBuy = valueAtBuy;
         UnitsHeld = unitsBought;
      }
      public DateTime BoughtDate { get; set; }
      public double ValueAtBuy { get; set; }
      public int UnitsHeld { get; set; }
   }

   public class Security
   {
      public Security(string NameOfSecurity, int NumberOfSecurity, double value)
      {
         Name = NameOfSecurity;
         SerialNumber = NumberOfSecurity;
         Value = value;
      }

      public string Name { get; }
      public int SerialNumber { get; }
      public double Value { get; }
   }

   public class Bond : Security
   {
      public Bond(string NameOfSecurity, int NumberOfSecurity, double curValue, string qualityRating, double maham, IndexType index, double netYield,
         DateTime exDate)
          : base(NameOfSecurity, NumberOfSecurity, curValue)
      {
         QualityRating = qualityRating;
         Maham = maham;
         Index = index;
         NetYield = netYield;
         ExDate = exDate;
      }

      public Bond(Bond copyFrom, double netYield, DateTime exDate)
          : base(copyFrom.Name, copyFrom.SerialNumber, copyFrom.Value)
      {
         QualityRating = copyFrom.QualityRating;
         Maham = copyFrom.Maham;
         Index = copyFrom.Index;
         NetYield = netYield;
         ExDate = exDate;
      }

      public string QualityRating { get; }
      public double NetYield { get; }
      public double Maham { get; }
      public IndexType Index { get; }
      public DateTime ExDate { get; }
   }

    class Fund : Security
    {
        public Fund(string NameOfSecurity, int NumberOfSecurity, double value)
            : base(NameOfSecurity, NumberOfSecurity, value)
        {

        }
    }
}
