using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeneralTypes
{
    enum SecurityType
    {
        Fund,
        Bond
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
        public Bond(string NameOfSecurity, int NumberOfSecurity, string qualityRating)
            : base(NameOfSecurity, NumberOfSecurity)
        {
            QualityRating = qualityRating;
        }

        public Bond(Bond copyFrom, double netYield)
            : base(copyFrom.Name, copyFrom.SerialNumber)
        {
            QualityRating = copyFrom.QualityRating;
            NetYield = netYield;
        }

        public string QualityRating { get; }
        public double NetYield { get;}
    }

    class Fund : Security
    {
        public Fund(string NameOfSecurity, int NumberOfSecurity)
            : base(NameOfSecurity, NumberOfSecurity)
        {

        }
    }
}
