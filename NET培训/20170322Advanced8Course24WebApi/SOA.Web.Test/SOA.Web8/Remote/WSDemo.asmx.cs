using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SOA.Web8.Remote
{
    /// <summary>
    /// WSDemo 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WSDemo : System.Web.Services.WebService
    {
        private int i = 0;

        [WebMethod]
        public string HelloWorld()
        {
            i++;
            return "Hello World1";
        }

        [WebMethod]
        public string HelloWorldInt(int i, int k)
        {
            return "Hello World" + i + k;
        }
    }
}
