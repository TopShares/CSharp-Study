using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ruanmou.Web.Core.PipeLine
{
    /// <summary>
    /// 直接扩展route，拒绝浏览器
    /// </summary>
    public class MyRoute : RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            if (httpContext.Request.UserAgent.IndexOf("Chrome/55.0.2883.75") >= 0)
            {
                RouteData rd = new RouteData(this, new MvcRouteHandler());
                rd.Values.Add("controller", "Pipe");
                rd.Values.Add("action", "Refuse");
                return rd;
            }
            return null;
        }
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return null;
        }
    }
}
