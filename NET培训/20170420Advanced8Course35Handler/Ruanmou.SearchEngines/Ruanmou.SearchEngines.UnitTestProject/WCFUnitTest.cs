using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ruanmou.SearchEngines.UnitTestProject
{
    [TestClass]
    public class WCFUnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            WCFTest.SearcherClient client = null;
            try
            {
                client = new WCFTest.SearcherClient();
                string result = client.QueryCommodityPage(1, 30, "男装", null, null, null);
                client.Close();
            }
            catch (Exception ex)
            {
                if (client != null)
                    client.Abort();
            }
        }
    }
}
