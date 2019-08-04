using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ruanmou.MVC5.Handler
{
    /// <summary>
    /// 高级班的说明
    /// </summary>
    public class MyHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("这里是.net高级班");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}