using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RSSClient.Interfaces;
using System.Collections.Generic;
using RSSClient.Exceptions;

namespace RSSClient.Test
{
    [TestClass]
    public class RSSClientTests
    {
        Mock<IRSSClient> mockClient;

        [TestInitialize]
        public void init()
        {
            mockClient = new Mock<IRSSClient>();
        }

        /// <summary>
        /// This methods test the sources and throws an exception if the sources url is invalid
        /// </summary>
        /// <author>
        /// Carlos A. Rivera M.
        /// </author>
        /// <date>
        /// 10 Jun 2016
        /// </date>
        [TestMethod]
        public void RSSClient_VerifySourcesURL_ReturnsException()
        {
            IRSSClient client = new RSSClient();
            Dictionary<int, string> sources = new Dictionary<int, string>();
            sources.Add(0, "www.diariolibre.com/rss/portada.xml");
            sources.Add(1, "http://hoy.com.do/feed/");

            bool exceptionThrown = false;

            try
            {
                var data = mockClient.Setup(x => x.GetData(sources));
            }
            catch (InvalidURLException ex)
            {
                exceptionThrown = true;
            }
            catch(Exception ex)
            {

            }

            Assert.IsTrue(exceptionThrown);
        }
    }
}
