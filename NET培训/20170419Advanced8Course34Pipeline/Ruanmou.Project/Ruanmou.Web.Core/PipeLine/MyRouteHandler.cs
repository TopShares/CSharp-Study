using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace Ruanmou.MVC5.Utility.Pipeline
{
    public class ElevenRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new ElevenHandler(requestContext);
        }
    }

    /// <summary>
    /// 还是我们熟悉的handler
    /// </summary>
    public class ElevenHandler : IHttpHandler
    {
        public ElevenHandler(RequestContext requestContext)
        {
            Console.WriteLine("构造ElevenHandler");
        }

        public virtual void ProcessRequest(HttpContext context)
        {
            string url = context.Request.Url.AbsoluteUri;
            context.Response.Write(string.Format("这里是：{0}", this.GetType().Name));
            context.Response.Write((string.Format("当前地址为：{0}", url)));
            context.Response.End();
        }

        public virtual bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
    public static class RouteCustomConfig
    {
        public static void RegisterCustomRoutes(this RouteCollection routes)
        {
            Route route = new Route("Eleven/{other}", new ElevenRouteHandler());
            RouteTable.Routes.Add(route);
        }
    }
}