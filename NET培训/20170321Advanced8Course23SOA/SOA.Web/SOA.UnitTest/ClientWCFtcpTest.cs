using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SOA.UnitTest
{
    [TestClass]
    public class ClientWCFtcpTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ClientWCFtcp.MathServiceClient client = new ClientWCFtcp.MathServiceClient();
            int iResult = client.PlusInt(4, 5);
            ClientWCFtcp.WCFUser user = client.GetUser(1, 4);
            ClientWCFtcp.WCFUser[] userList = client.UserList();
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
