namespace PassLock.Handler.IO.Web.Scrawler
{
    public abstract class BaseScrawler
    {
        protected static string DownloadString(string url, int timeout = TimedWebClient.DEFAULT_TIMEOUT)
        {
            var client = new TimedWebClient(timeout);
            return client.DownloadString(url);
        }
    }
}
