using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SOA.Web.Remote
{
    /// <summary>
    /// MyWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class MyWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Minus(int iValueOne, int iValueTwo)
        {
            return iValueOne - iValueTwo;
        }

        [WebMethod]
        public WebServiceUser GetUser(int id)
        {
            return new WebServiceUser()
            {
                Id = id,
                Name = "你猜",
                Sex = (int)WebServiceSex.Male,
                Age = 12,
                Description = "123456678990"
            };
        }

        [WebMethod]
        public List<WebServiceUser> UserList()
        {
            return new List<WebServiceUser>(){ 
                new WebServiceUser()
                {
                    Id = 1,
                    Name = "你猜",
                    Sex = (int)WebServiceSex.Male,
                    Age = 12,
                    Description = "123456678990"
                },
                 new WebServiceUser()
                {
                    Id = 2,
                    Name = "你猜2",
                    Sex = (int)WebServiceSex.Male,
                    Age = 12,
                    Description = "123456678990"
                },
                 new WebServiceUser()
                {
                    Id = 3,
                    Name = "你猜3",
                    Sex = (int)WebServiceSex.Famale,
                    Age = 112,
                    Description = "123456678990"
                }
            };
        }
    }
}
