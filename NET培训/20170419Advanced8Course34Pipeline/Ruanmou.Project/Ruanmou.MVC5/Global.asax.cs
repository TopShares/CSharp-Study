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
            //HttpApplication
            AreaRegistration.RegisterAllAreas();//区域
            GlobalConfiguration.Configure(WebApiConfig.Register);//webapi 路由
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);//过滤器
            RouteConfig.RegisterRoutes(RouteTable.Routes);//常规路由
            BundleConfig.RegisterBundles(BundleTable.Bundles);//js包  css包  combres

            ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory());//控制器的实例化走UnityControllerFactory

        }

        protected void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        /// <summary>
        /// 请求出现异常，都可以处理
        /// 也可以完成全局异常处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码
            var error = Server.GetLastError();
            //var code = (error is HttpException) ? (error as HttpException).GetHttpCode() : 500;

            ////如果不是HttpException记录错误信息
            //if (code != 404)
            //{
            //    //此处邮件或日志记录错误信息
            //}

            Response.Write("出错");
            Server.ClearError();

            //string path = Request.Path;
            //Context.RewritePath(string.Format("~/Errors/Http{0}", code), false);
            //IHttpHandler httpHandler = new MvcHttpHandler();
            //httpHandler.ProcessRequest(Context);
            //Context.RewritePath(path, false);


        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码
            Console.WriteLine("Session_Start 啥也不干");
        }
        protected void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。

            Console.WriteLine("Session_End 啥也不干");
        }

        /// <summary>
        /// HttpModule注册名称_事件名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GlobalModule_GlobalModuleEvent(object sender, EventArgs e)
        {
            Response.Write("<h3 style='color:#800800'>来自 Global.asax 的文字</h2>");
        }



        /// <summary>
        /// 在global.asax中，针对HttpApplication的事件处理，可以通过定义特殊命名的方法来实现。
        /// 首先，这些方法必须符合System.EventHandler，因为所有的HttpApplication管道事件都使用这个委托定义。
        /// 第二，方法的作用域必须是public。
        /// 第三，方法的命名格式必须如下：Application_注册的事件名称。按照这种命名方法定义在global.asax中的方法将被自动注册到对应的事件中。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            Response.Write("验证通过事件PostAuthenticateRequest!");
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            Response.Write("验证通过事件BeginRequest!");
        }
    }
}
