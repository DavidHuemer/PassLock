using FaviconFetcher;
using System;
using System.IO;
using System.Net;

namespace PassLock.Handler.IO.Web.Scrawler
{
    public class FavIconScrawler : BaseScrawler
    {
        public static byte[] GetFavicon(string url)
        {
            return GetFavicon(new Uri(url));
        }

        public static byte[] GetFavicon(Uri uri)
        {
            //1 Get the favicon url
            string favIconUrl = GetFaviconURL(uri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(favIconUrl);
            var response = (HttpWebResponse)request.GetResponse();
            if(response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            Stream receiveStream = response.GetResponseStream();
            var memoryStream = new MemoryStream();
            receiveStream.CopyTo(memoryStream);
            byte[] bytes = memoryStream.ToArray();
            return bytes;
        }

        /// <summary>
        /// Returns the URL of the favicon
        /// </summary>
        /// <param name="websiteURL">The website where the icon should be found</param>
        /// <returns>URL of the favicon</returns>
        public static string GetFaviconURL(Uri websiteURL)
        {
            var scanner = new Scanner();
            foreach (var result in scanner.Scan(websiteURL))
            {
                return result.Location.AbsoluteUri;
            }

            return null;
        }
    }
}
