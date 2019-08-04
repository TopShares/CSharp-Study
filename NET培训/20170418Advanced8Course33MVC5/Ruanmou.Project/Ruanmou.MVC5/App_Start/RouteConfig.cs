using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ruanmou.MVC5
{
    /// <summary>
    /// 路由注册
    /// </summary>
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           // routes.MapRoute(
           //  name: "About",
           //  url: "about",
           //  defaults: new { controller = "First", action = "String", id = UrlParameter.Optional }
           // );//静态路由

           // routes.MapRoute("TestStatic", "Test/Static", new { controller = "First", action = "Index" });//静态路由

           // routes.MapRoute("TestStatic2", "Test/{action}", new { controller = "First" });//替换控制器

           // routes.MapRoute(
           //         "Regex",
           //          "{controller}/{action}_{Year}_{Month}_{Day}",
           //          new { controller = "First", id = UrlParameter.Optional },
           //          new { Year = @"^\d{4}", Month = @"\d{2}", Day = @"\d{2}" }
           //            );//正则路由


           // routes.MapRoute(
           //    name: "Next",
           //    url: "Next/{controller}/{action}/{id}",
           //    defaults: new { controller = "Home", action = "Next", id = UrlParameter.Optional },
           //    namespaces: new string[] { "Ruanmou.MVC5.Controllers" }
           //);//命名空间路由


            //默认路由
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
