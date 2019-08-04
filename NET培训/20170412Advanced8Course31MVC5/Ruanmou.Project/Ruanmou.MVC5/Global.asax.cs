using Ruanmou.Web.Core.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Ruanmou.MVC5
{
    /// <summary>
    /// 全局配置文件，
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 网站第一次启动的时候会率先执行，且只执行一次
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();//区域
            GlobalConfiguration.Configure(WebApiConfig.Register);//webapi 路由
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);//过滤器
            RouteConfig.RegisterRoutes(RouteTable.Routes);//常规路由
            BundleConfig.RegisterBundles(BundleTable.Bundles);//js包  css包  combres



            ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory());//控制器的实例化走UnityControllerFactory
       
        }
    }
}
