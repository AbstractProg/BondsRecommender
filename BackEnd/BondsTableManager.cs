using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class BondsTableManager
    {
        private Dictionary<int, GeneralTypes.Bond> m_allRecords;

        const string BondsDBFile = "BondsTable.sdb";
        public BondsTableManager()
        {
            m_allRecords = new Dictionary<int, GeneralTypes.Bond>();

            if (!File.Exists(BondsDBFile))
            {
                StreamWriter dbFile = new StreamWriter(BondsDBFile);
                dbFile.Close();
            }

            else
            {
                StreamReader dbFile = new StreamReader(BondsDBFile);
                string singleLine;
                while((singleLine=dbFile.ReadLine())!=null)
                {
                    string[] lineData = singleLine.Split('@');
                    m_allRecords.Add(Convert.ToInt32(lineData[0]), new GeneralTypes.Bond(lineData[1], Convert.ToInt32(lineData[0]), lineData[2],
                        Convert.ToDouble(lineData[3]), StrToIndexType(lineData[4])));
                }
                dbFile.Close();
            }
        }

        public void UpdateBond(GeneralTypes.Bond bondToUpdate)
        {
            int bondID = bondToUpdate.SerialNumber;
            if (m_allRecords.Keys.Contains(bondID))
                m_allRecords[bondID] = bondToUpdate;
            else
                m_allRecords.Add(bondID, bondToUpdate);
        }

        public GeneralTypes.Bond GetBond(int bondID)
        {
            return m_allRecords[bondID];
        }

      public List<GeneralTypes.Bond> GetAllBonds()
      {
         return m_allRecords.Values.ToList();
      }

        private GeneralTypes.IndexType StrToIndexType(string str)
        {
            return GeneralTypes.IndexType.Dollar;
        }

        public void UpdateDBFile()
        {
            StreamWriter dbFile = new StreamWriter(BondsDBFile);
            foreach(GeneralTypes.Bond curBond in m_allRecords.Values)
            {
                dbFile.WriteLine("{0}@{1}@{2}@{3}@{4}", curBond.SerialNumber, curBond.Name, curBond.QualityRating, curBond.Maham, curBond.Index);
            }
        }
    }
}
