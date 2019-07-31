using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Configuration;

//引入跨域的命名空间
using System.Web.Http.Cors;

namespace WebAPIDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            #region 浏览器跨域问题解决

            //方式一：全局开放
            //也就是说，我们允许所有的请求进来访问我的API，安全性非常低
            // config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            //方式二：独立开放（也就是对哪些域名开发，对哪些方法开发，可以单独设置）
            string origins = ConfigurationManager.AppSettings["cors:origins"];
            string headers = ConfigurationManager.AppSettings["cors:headers"];
            string methods = ConfigurationManager.AppSettings["cors:methods"];

            config.EnableCors(new EnableCorsAttribute(origins, headers, methods));


            #endregion


            // Web API 配置和服务

            // 扩展方法：启用WebAPI的特性路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //自定义路由：和MVC类似，增加action
            config.Routes.MapHttpRoute(
               name: "customRoute1",
               routeTemplate: "myapi/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );
        }
    }
}
