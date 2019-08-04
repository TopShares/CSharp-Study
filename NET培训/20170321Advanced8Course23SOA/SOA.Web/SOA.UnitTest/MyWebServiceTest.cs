using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Reflection;

namespace SOA.UnitTest
{
    [TestClass]
    public class WebServiceTest
    {
        [TestMethod]
        public void TestMethod()
        {
            using (MyWebService.MyWebServiceSoapClient client = new MyWebService.MyWebServiceSoapClient())
            {
                int iResult = client.Minus(7, 5);
                Assert.Equals(iResult, 12);

                MyWebService.WebServiceUser userResult = client.GetUser(3);
                List<MyWebService.WebServiceUser> userListResult = client.UserList();//配置服务=>集合类型=>List

                User user = userResult.ToLocal<User, MyWebService.WebServiceUser>();
                
            }
        }

        private class User
        {
            public int Id { get; set; }
            public int Age { get; set; }
            public int Sex { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }


    }
    public static class ReflectExtend
    {
        public static T ToLocal<T, S>(this S s) where S : class
        {
            if (s == null) return default(T);

            T t = (T)Activator.CreateInstance(typeof(T));

            var sPropertyInfoArray = typeof(S).GetProperties();
            foreach (PropertyInfo tProp in typeof(T).GetProperties())
            {
                foreach (PropertyInfo sProp in sPropertyInfoArray)
                {
                    if (tProp.Name.Equals(sProp.Name))
                    {
                        tProp.SetValue(t, sProp.GetValue(s));
                        break;
                    }
                }
            }
            return t;
        }
    }
}
