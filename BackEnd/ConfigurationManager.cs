using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
   public class ConfigurationManager
   {
      public List<string> QualityToDownload { get { return m_QualityToDownload; } }
      public List<GeneralTypes.IndexType> IndexesToDownload { get { return m_indexesToDownload; } }
      public double MinMahamToDownload { get { return m_MinMahamToDownload; } }
      public double MaxMahamToDownload { get { return m_MaxMahamToDownload; } }
      public List<string> QualityToDisplay { get { return m_QualityToDisplay; } }
      public List<GeneralTypes.IndexType> IndexesToDisplay { get { return m_indexesToDisplay; } }
      public double MinMahamToDisplay { get { return m_MinMahamToDisplay; } }
      public double MaxMahamToDisplay { get { return m_MaxMahamToDisplay; } }
      public double ComissionPercentage { get; set; }

      private List<string> m_QualityToDownload;
      private List<GeneralTypes.IndexType> m_indexesToDownload;
      private double m_MinMahamToDownload;
      private double m_MaxMahamToDownload;
      private List<string> m_QualityToDisplay;
      private List<GeneralTypes.IndexType> m_indexesToDisplay;
      private double m_MinMahamToDisplay;
      private double m_MaxMahamToDisplay;

      private const string CFG_FILE_NAME = "recommender.cfg";
      private const string DELIMITER = "~~~";

      public ConfigurationManager()
      {
         FileStream cfgFile;
         if(File.Exists(CFG_FILE_NAME))
         {
            cfgFile = File.Open(CFG_FILE_NAME, FileMode.Open, FileAccess.Read);
            ReadCfgFromFile(cfgFile);
         }
         else
         {
            List<string> defaultQulity = new List<string>() { "Aaa", "Aa1", "Aa2", "Aa3", "A1", "A2", "AAA", "AA+", "AA", "AA-", "A+", "A" };
            List<GeneralTypes.IndexType> defaultIndexTypes = new List<GeneralTypes.IndexType>() { GeneralTypes.IndexType.Dollar, GeneralTypes.IndexType.Fixed,
               GeneralTypes.IndexType.Madad, GeneralTypes.IndexType.Shekel, GeneralTypes.IndexType.VaryingInterest};
            UpdateCfgFile(defaultQulity, defaultIndexTypes, 0.5, 8, defaultQulity, defaultIndexTypes, 0.5, 6, 0.35);
         }
      }

      public void UpdateCfgFile(List<string> qualityToDownload, List<GeneralTypes.IndexType> indexesToDownload, double minMahamToDownload, double maxMahamToDownload,
          List<string> qualityToDisplay, List<GeneralTypes.IndexType> indexesToDisplay, double minMahamToDisplay, double maxMahamToDisplay, double comissionPercent)
      {
         m_QualityToDownload = qualityToDownload;
         m_indexesToDownload = indexesToDownload;
         m_MinMahamToDownload = minMahamToDownload;
         m_MaxMahamToDownload = maxMahamToDownload;
         m_QualityToDisplay = qualityToDisplay;
         m_indexesToDisplay = indexesToDownload;
         m_MinMahamToDisplay = minMahamToDisplay;
         m_MaxMahamToDisplay = maxMahamToDisplay;
         ComissionPercentage = comissionPercent;

         FileStream f = new FileStream(CFG_FILE_NAME, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
         StreamWriter cfgFile = new StreamWriter(f);

         cfgFile.Write("QualityToDownload" + DELIMITER);
         foreach (string curQuality in QualityToDownload)
            cfgFile.Write(curQuality + DELIMITER);
         cfgFile.WriteLine();

         cfgFile.Write("IndexesToDownload" + DELIMITER);
         foreach (GeneralTypes.IndexType curIndex in indexesToDownload)
            cfgFile.Write(GeneralTypes.IndexConverter.IndexToString(curIndex) + DELIMITER);
         cfgFile.WriteLine();

         cfgFile.WriteLine("minMahamToDownload" + DELIMITER + MinMahamToDownload);
         cfgFile.WriteLine("maxMahamToDownload" + DELIMITER + MaxMahamToDownload);

         cfgFile.Write("QualityToDisplay" + DELIMITER);
         foreach (string curQuality in QualityToDisplay)
            cfgFile.Write(curQuality + DELIMITER);
         cfgFile.WriteLine();

         cfgFile.Write("IndexesToDisplay" + DELIMITER);
         foreach (GeneralTypes.IndexType curIndex in indexesToDisplay)
            cfgFile.Write(GeneralTypes.IndexConverter.IndexToString(curIndex) + DELIMITER);
         cfgFile.WriteLine();

         cfgFile.WriteLine("minMahamToDisplay" + DELIMITER + MinMahamToDisplay);
         cfgFile.WriteLine("maxMahamToDisplay" + DELIMITER + MaxMahamToDisplay);

         cfgFile.WriteLine("comissionPercent" + DELIMITER + comissionPercent);

         cfgFile.Close();
         f.Close();
      }

      private void ReadCfgFromFile(FileStream f)
      {
         StreamReader cfgFile = new StreamReader(f);

         //read qualityToDownload line
         string curLine = cfgFile.ReadLine();
         string[] curArr = curLine.Split(new string[] { DELIMITER }, StringSplitOptions.None);
         m_QualityToDownload = new List<string>();
         for (int i = 1; i < curArr.Length - 1; i++)
            m_QualityToDownload.Add(curArr[i]);

         //read indexesToDownload line
         curLine = cfgFile.ReadLine();
         curArr = curLine.Split(new string[] { DELIMITER }, StringSplitOptions.None);
         m_indexesToDownload = new List<GeneralTypes.IndexType>();
         for (int i = 1; i < curArr.Length - 1; i++)
            m_indexesToDownload.Add(GeneralTypes.IndexConverter.StringToIndex(curArr[i]));

         //read min maham to download
         curLine = cfgFile.ReadLine();
         string minMahamToDownloadAsString = curLine.Substring(21);
         m_MinMahamToDownload = Convert.ToDouble(minMahamToDownloadAsString);

         //read max maham to download
         curLine = cfgFile.ReadLine();
         string maxMahamToDownloadAsString = curLine.Substring(21);
         m_MaxMahamToDownload = Convert.ToDouble(maxMahamToDownloadAsString);

         //read qualityToDisplay line
         curLine = cfgFile.ReadLine();
         curArr = curLine.Split(new string[] { DELIMITER }, StringSplitOptions.None);
         m_QualityToDisplay = new List<string>();
         for (int i = 1; i < curArr.Length - 1; i++)
            m_QualityToDisplay.Add(curArr[i]);

         //read indexesToDisplay line
         curLine = cfgFile.ReadLine();
         curArr = curLine.Split(new string[] { DELIMITER }, StringSplitOptions.None);
         m_indexesToDisplay = new List<GeneralTypes.IndexType>();
         for (int i = 1; i < curArr.Length - 1; i++)
            m_indexesToDisplay.Add(GeneralTypes.IndexConverter.StringToIndex(curArr[i]));

         //read min maham to display
         curLine = cfgFile.ReadLine();
         string minMahamToDisplayAsString = curLine.Substring(7);
         m_MinMahamToDisplay = Convert.ToDouble(minMahamToDownloadAsString);

         //read max maham to download
         curLine = cfgFile.ReadLine();
         string maxMahamToDisplayAsString = curLine.Substring(7);
         m_MaxMahamToDisplay = Convert.ToDouble(maxMahamToDownloadAsString);

         cfgFile.Close();
         f.Close();
      }
   }
}