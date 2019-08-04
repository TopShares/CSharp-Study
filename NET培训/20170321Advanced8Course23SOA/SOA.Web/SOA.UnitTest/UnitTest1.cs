using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SOA.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Init()
        {
 
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(13, 13);
            //Assert.AreEqual(13, 12);
        }
        

        [TestMethod]
        public void TestMethod1()
        {

            ClientWCFtcpLuceneSearcher.SearcherClient client = new ClientWCFtcpLuceneSearcher.SearcherClient();
            string result= client.QueryCommodityPage(1, 20, "男士衬衣", null, "", "");

            try
            {
                client.Close();//会关闭链接，但是如果网络异常了，会抛出异常而且关闭不了
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                client.Abort();
            }
        }
    }
}
