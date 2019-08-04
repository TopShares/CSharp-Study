using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SOA.UnitTest8
{
    [TestClass]
    public class UnitTest
    {
        [TestInitialize]
        public void Init123()
        {
            Console.WriteLine("这里是Init");
        }


        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("这里是test");
            string result = "";
            Assert.Equals("1123", result);
        }

        [TestMethod]
        public void TestWS()
        {
            Console.WriteLine("TestWS");
            using (advaned8.WS.WSDemoSoapClient client = new advaned8.WS.WSDemoSoapClient())
            {

                string result = client.HelloWorldInt(1, 2);
                Assert.AreEqual("Hello World12", result);
            }
        }

        [TestMethod]
        public void TestWCF()
        {
            Console.WriteLine("TestWCF");
            advanced8.WCF.Service1Client client = null;

            try
            {
                client = new advanced8.WCF.Service1Client();

                string result = client.GetData(123);
                client.Close();//
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (client != null)
                    client.Abort();
            }
        }

        [TestMethod]
        public void TestWCFTCPIP()
        {
            Console.WriteLine("TestWCF");
            advanced8.Console.TCPIP.MathServiceClient client = null;

            try
            {
                client = new advanced8.Console.TCPIP.MathServiceClient();

                var result1 = client.PlusInt(3, 4);
                var result2 = client.GetUser(5, 7);
                List<advanced8.Console.TCPIP.WCFUser> result3 = client.UserList();
                client.Close();//
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (client != null)
                    client.Abort();
            }
        }

    }
}
