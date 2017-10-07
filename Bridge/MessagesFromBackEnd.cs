using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public class DataDownloadStartedMsg
    {
        public delegate void EventRaiser();
        public event EventRaiser OnDownloadStarted;
        
        public void LaunchEvent()
        {
            OnDownloadStarted?.Invoke();
        }
    }

    /*public class ListOfFundsMsg
    {
        public delegate void EventRaiser(String WebPageData);
        public event EventRaiser onDownoladFinished;

        public void LaunchEvent(string WebPageData)
        {
            onDownoladFinished?.Invoke(WebPageData);
        }
    }*/
}
