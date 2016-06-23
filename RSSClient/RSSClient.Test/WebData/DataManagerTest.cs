using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSSClient.Interfaces.WebData;
using RSSClient.WebData;
using System.Collections.Generic;

namespace RSSClient.Test.WebData
{
    [TestClass]
    public class DataManagerTest
    {
        IDataManager dataManager;

        /// <summary>
        /// Data Manager Initialization
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            dataManager = new DataManager();
        }

        /// <summary>
        /// Get RSS Valid String
        /// </summary>
        [TestMethod]
        public void DownloadRSSData_ValidsURL_GetRSSString()
        {
            List<string> rssFeeds = new List<string>();
            rssFeeds.Add(@"http://www.diariolibre.com/rss/portada.xml");
            rssFeeds.Add(@"http://www.diariolibre.com/rss/noticias.xml");
            rssFeeds.Add(@"http://elnacional.com.do/feed/");
            rssFeeds.Add(@"http://listindiario.com/rss/portada/");

            var result = dataManager.DownloadRSSData(rssFeeds.ToArray());

            Assert.AreEqual(rssFeeds.Count, result.Length);
        }

        /// <summary>
        /// Get All Valid RSS Strings
        /// </summary>
        [TestMethod]
        public void DownloadRSSData_OneInvalidURL_GetAllRSSButOne()
        {
            List<string> rssFeeds = new List<string>();
            rssFeeds.Add(@"http://www.diariolibre.com/rss/portada.xml");
            rssFeeds.Add(@"http://www.diariolibre.com/rss/noticias.xml");
            rssFeeds.Add(@"carlos@carlos.com");
            rssFeeds.Add(@"http://listindiario.com/rss/portada/");

            var result = dataManager.DownloadRSSData(rssFeeds.ToArray());

            Assert.AreEqual(rssFeeds.Count - 1, result.Length);
        }

        /// <summary>
        /// Get All Valid RSS Strings
        /// </summary>
        [TestMethod]
        public void DownloadRSSData_UnresponsiveURL_GetAllRSSButOne()
        {
            List<string> rssFeeds = new List<string>();
            rssFeeds.Add(@"http://www.diariolibre.com/rss/portada.xml");
            rssFeeds.Add(@"http://www.diariolibre.com/rss/noticias.xml");
            rssFeeds.Add(@"http://esd.com.do");
            rssFeeds.Add(@"http://listindiario.com/rss/portada/");

            var result = dataManager.DownloadRSSData(rssFeeds.ToArray());

            Assert.AreEqual(rssFeeds.Count - 1, result.Length);
        }
    }
}
