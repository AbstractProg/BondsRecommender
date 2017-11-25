using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeMsg
{
    public delegate void DataDownloadStartedDlgt();
    public class DataDownloadStartedMsg
    {
        public event DataDownloadStartedDlgt OnDownloadStarted;
        
        public void LaunchEvent()
        {
            OnDownloadStarted?.Invoke();
        }
    }

    public delegate void ListOfBondsDlgt(List<GeneralTypes.Bond> bondList);
    public class ListOfBondsMsg
    {
        public event ListOfBondsDlgt OnListOfBondsUpdated;
        
        public void LaunchEvent(List<GeneralTypes.Bond> listToPublish)
        {
            OnListOfBondsUpdated?.Invoke(listToPublish);
        }
    }

    public delegate void UpdateProgressDlgt(int percentage, string BondName);
    public class DownloadProgressMsg
    {
        public event UpdateProgressDlgt OnDownloadProgress;

        public void LaunchEvent(int percentage, string bondName)
        {
            OnDownloadProgress?.Invoke(percentage, bondName);
        }
    }
}
