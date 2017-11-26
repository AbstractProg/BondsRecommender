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
        public double MinMahamToDownload { get { return m_MinMahamToDownload; } }
        public double MaxMahamToDownload { get { return m_MaxMahamToDownload; } }
        public List<string> QualityToDisplay { get { return m_QualityToDisplay; } }
        public double MinMahamToDisplay { get { return m_MinMahamToDisplay; } }
        public double MaxMahamToDisplay { get { return m_MaxMahamToDisplay; } }

        private List<string> m_QualityToDownload;
        private double m_MinMahamToDownload;
        private double m_MaxMahamToDownload;
        private List<string> m_QualityToDisplay;
        private double m_MinMahamToDisplay;
        private double m_MaxMahamToDisplay;

        private const string CFG_FILE_NAME = "recommender.cfg";
        private const string DELIMITER = "~~~";

        public ConfigurationManager()
        {
            FileStream cfgFile;
            try
            {
                cfgFile = File.Open(CFG_FILE_NAME, FileMode.Open, FileAccess.Read);
                ReadCfgFromFile(cfgFile);
            }
            catch (FileNotFoundException)
            {
                List<string> defaultQulity = new List<string>() { "Aaa", "Aa1", "Aa2", "Aa3", "A1", "A2", "AAA", "AA+", "AA", "AA-", "A+", "A" };
                UpdateCfgFile(defaultQulity, 0.5, 8, defaultQulity, 0.5, 6);
            }
        }

        public void UpdateCfgFile(List<string> qualityToDownload, double minMahamToDownload, double maxMahamToDownload,
            List<string> qualityToDisplay, double minMahamToDisplay, double maxMahamToDisplay)
        {
            m_QualityToDownload = qualityToDownload;
            m_MinMahamToDownload = minMahamToDownload;
            m_MaxMahamToDownload = maxMahamToDownload;
            m_QualityToDisplay = qualityToDisplay;
            m_MinMahamToDisplay = minMahamToDisplay;
            m_MaxMahamToDisplay = maxMahamToDisplay;

            FileStream f = new FileStream(CFG_FILE_NAME, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter cfgFile = new StreamWriter(f);
            cfgFile.Write("QualityToDownload"+DELIMITER);
            foreach(string curQuality in QualityToDownload)
                cfgFile.Write(curQuality+DELIMITER);
            cfgFile.WriteLine();
            cfgFile.WriteLine("minMahamToDownload" + DELIMITER + MinMahamToDownload);
            cfgFile.WriteLine("maxMahamToDownload" + DELIMITER + MaxMahamToDownload);
            cfgFile.Write("QualityToDisplay"+DELIMITER);
            foreach (string curQuality in QualityToDisplay)
                cfgFile.Write(curQuality + DELIMITER);
            cfgFile.WriteLine();
            cfgFile.WriteLine("minMahamToDisplay" + DELIMITER + MinMahamToDisplay);
            cfgFile.WriteLine("maxMahamToDisplay" + DELIMITER + MaxMahamToDisplay);

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
            for (int i = 1; i < curArr.Length-1; i++)
                m_QualityToDownload.Add(curArr[i]);
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
            for (int i = 1; i < curArr.Length-1; i++)
                m_QualityToDisplay.Add(curArr[i]);
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