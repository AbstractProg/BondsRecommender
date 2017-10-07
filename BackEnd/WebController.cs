using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class WebController
    {
        private WebClient m_WebClient;

        public WebController()
        {
            m_WebClient = new WebClient();
        }

        public string[] PerformPostRequest(string Address, NameValueCollection NVCollection)
        {
            byte[] RawResponse = m_WebClient.UploadValues(Address, NVCollection);
            string responseInOneLine = System.Text.Encoding.UTF8.GetString(RawResponse);
            return responseInOneLine.Split(new string[] { "\r\n" }, StringSplitOptions.None);
        }
    }
}
