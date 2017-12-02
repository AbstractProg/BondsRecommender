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
    

    public class Security
    {
        public Security(string NameOfSecurity, int NumberOfSecurity)
        {
            Name = NameOfSecurity;
            SerialNumber = NumberOfSecurity;
        }

        public string Name { get; }
        public int SerialNumber { get; }
    }

    public class Bond : Security
    {
        public Bond(string NameOfSecurity, int NumberOfSecurity, string qualityRating, double maham, IndexType index)
            : base(NameOfSecurity, NumberOfSecurity)
        {
            QualityRating = qualityRating;
            Maham = maham;
            Index = index;
        }

        public Bond(Bond copyFrom, double netYield)
            : base(copyFrom.Name, copyFrom.SerialNumber)
        {
            QualityRating = copyFrom.QualityRating;
            NetYield = netYield;
            Maham = copyFrom.Maham;
        }

        public string QualityRating { get; }
        public double NetYield { get;}
        public double Maham { get; }
        public IndexType Index { get; }
    }

    class Fund : Security
    {
        public Fund(string NameOfSecurity, int NumberOfSecurity)
            : base(NameOfSecurity, NumberOfSecurity)
        {

        }
    }
}
