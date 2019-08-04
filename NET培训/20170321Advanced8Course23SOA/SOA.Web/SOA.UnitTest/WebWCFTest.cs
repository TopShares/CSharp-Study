using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SOA.UnitTest
{
    [TestClass]
    public class WebWCFTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (WebWCF.MathServiceClient client = new WebWCF.MathServiceClient())
            {
                int iResult = client.PlusInt(7, 5);
                WebWCF.WCFUser userResult = client.GetUser(3, 4);
                List<WebWCF.WCFUser> userListResult = client.UserList();//配置服务=>集合类型=>List
            }

        }
    }
}
