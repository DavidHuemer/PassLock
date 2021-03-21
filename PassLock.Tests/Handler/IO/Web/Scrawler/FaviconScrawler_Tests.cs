using PassLock.Handler.IO.Web.Scrawler;
using System;
using Xunit;

namespace PassLock.Tests.Handler.IO.Web.Scrawler
{
    public class FaviconScrawler_Tests
    {
        [Theory]
        [InlineData(@"https://www.feuerwehr-neumarkt.at/", @"https://static.wixstatic.com/media/1e9e20_9b108dc2272742a6a3254ec8d9b1c339~mv2.png/v1/fill/w_32%2Ch_32%2Clg_1%2Cusm_0.66_1.00_0.01/1e9e20_9b108dc2272742a6a3254ec8d9b1c339~mv2.png")]
        [InlineData(@"https://www.google.at/", @"https://www.google.at/favicon.ico")]
        [InlineData(@"https://www.ff-tolleterau.at/", @"https://www.ff-tolleterau.at/favicon.ico")]
        public void GetFaviconURL_Tests(string urlStr, string expectedSource)
        {
            var uri = new Uri(urlStr);
            string faviconSrc = FavIconScrawler.GetFaviconURL(uri);
            Assert.Equal(expectedSource, faviconSrc);
        }
    }
}
