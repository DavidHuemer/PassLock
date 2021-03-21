using System;
using System.Net;

namespace PassLock.Handler.IO.Web
{
    public class TimedWebClient : WebClient
    {
        public const int DEFAULT_TIMEOUT = 60000;

        public int Timeout { get; set; }
        public TimedWebClient(int timeout = DEFAULT_TIMEOUT)
        {
            Timeout = timeout;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var objWebRequest = base.GetWebRequest(address);
            objWebRequest.Timeout = this.Timeout;
            return objWebRequest;
        }
    }
}
