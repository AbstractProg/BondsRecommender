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

    class SecurityProperties
    {
        public SecurityProperties(SecurityType TypeOfSecurity, string NameOfSecurity, int NumberOfSecurity)
        {
            Type = TypeOfSecurity;
            Name = NameOfSecurity;
            Number = NumberOfSecurity;
        }

        public SecurityType Type {get;}
        public string Name { get; }
        public int Number { get; }
        public double Grade { get; set; }
    }
}
