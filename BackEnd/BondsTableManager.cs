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
            while ((singleLine = dbFile.ReadLine()) != null)
            {
               string[] lineData = singleLine.Split('@');
               m_allRecords.Add(Convert.ToInt32(lineData[0]), new GeneralTypes.Bond(lineData[1], Convert.ToInt32(lineData[0]), Convert.ToDouble(lineData[2]),
                  lineData[3], Convert.ToDouble(lineData[4]), GeneralTypes.IndexConverter.StringToIndex(lineData[5]), Convert.ToDouble(lineData[6]), DateTime.ParseExact(lineData[7],"dd/MM/yy", null)));
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

      public void UpdateDBFile()
      {
         StreamWriter dbFile = new StreamWriter(BondsDBFile);
         foreach (GeneralTypes.Bond curBond in m_allRecords.Values)
         {
            dbFile.WriteLine("{0}@{1}@{2}@{3}@{4}@{5}@{6}@{7}", curBond.SerialNumber, curBond.Name, curBond.Value, curBond.QualityRating, curBond.Maham,
               GeneralTypes.IndexConverter.IndexToString(curBond.Index), curBond.NetYield, curBond.ExDate.ToString("dd/MM/yy"));
         }
         dbFile.Close();
      }
   }
}