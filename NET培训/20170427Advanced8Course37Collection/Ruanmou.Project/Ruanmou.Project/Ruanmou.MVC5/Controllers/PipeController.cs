using Ruanmou.Framework.Extension;
using Ruanmou.Web.Core.Extension;
using Ruanmou.Web.Core.IOC;
using Ruanmou.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;

namespace Ruanmou.MVC5.Advanced7.Controllers
{
    /// <summary>
    /// 1 Http请求处理流程
    /// 2 HttpApplication的事件
    /// 3 HttpModule
    /// 4 Global事件
    /// 
    /// 1 HttpHandler及扩展，自定义后缀，图片防盗链等
    /// 2 MVC的RoutingModule,IRouteHandler、IHttpHandler
    /// 3 MVC扩展路由，扩展httphandler
    /// 
    /// 1 MVC的Controller激活、Action调用
    /// 2 View的激活使用
    /// 3 理解各种ActionResult  扩展XmlResult  JsonResult JavaScriptResult  EmptyResult
    /// 4 HttpContext Response，Request，Application，Server，Session
    /// </summary>
    [AllowAnonymous]
    public class PipeController : Controller
    {
        // GET: Pipe
        public ActionResult Index()
        {

            HttpRuntime.ProcessRequest(null);
            //HttpApplicationFactory

            return View();
        }

        #region Module

        /// <summary>
        /// 展示HttpApplication的全部事件
        /// </summary>
        /// <returns></returns>
        public ViewResult Events()
        {
            //base.ProcessRequest()

            //HttpRuntime
            //获取当前上下文的HttpApplication实例
            HttpApplication app = base.HttpContext.ApplicationInstance;

            List<SysEvent> sysEventsList = new List<SysEvent>();
            int i = 1;
            foreach (EventInfo e in app.GetType().GetEvents())
            {
                sysEventsList.Add(new SysEvent()
                {
                    Id = i++,
                    Name = e.Name,
                    TypeName = e.GetType().Name
                });
            }
            return View(sysEventsList);
            /*
             BeginRequest	Asp.net处理的第一个事件，表示处理的开始
             AuthenticateRequest	验证请求，一般用来取得请求用户的信息
             PostAuthenticateRequest	已经获取请求用户的信息
             AuthorizeRequest	授权，一般用来检查用户的请求是否获得权限
             PostAuthorizeRequest	用户请求已经得到授权
             ResolveRequestCache	获取以前处理缓存的处理结果，如果以前缓存过，那么，不必再进行请求的处 理工    作，  直接    返回缓存结果
             PostResolveRequestCache	已经完成缓存的获取操作
             PostMapRequestHandler	已经根据用户的请求，创建了处理请求的处理器对象
             AcquireRequestState	取得请求的状态，一般用于Session
             PostAcquireRequestState	已经取得了Session
             PreRequestHandlerExecute	准备执行处理程序
             PostRequestHandlerExecute	已经执行了处理程序
             ReleaseRequestState	释放请求的状态
             PostReleaseRequestState	已经释放了请求的状态
             UpdateRequestCache	更新缓存
             PostUpdateRequestCache	已经更新了缓存
             LogRequest	请求的日志操作
             PostLogRequest	已经完成了请求的日志操作
             EndRequest	本次请求处理完成
             */
        }
        /// <summary>
        /// 当前HttpApplication的modules
        /// </summary>
        /// <returns></returns>
        public ViewResult Modules()
        {
            HttpApplication app = base.HttpContext.ApplicationInstance; //获取当前上下文的HttpApplication实例
            List<SysModules> sysModulesList = new List<SysModules>();
            int i = 1;
            foreach (string name in app.Modules.AllKeys)
            {
                sysModulesList.Add(new SysModules()
                {
                    Id = i++,
                    Name = name,
                    TypeName = app.Modules[name].ToString()
                });
            }

            return View(sysModulesList);

            #region
            // 1、OutputCacheModule完成Asp.net的输出缓存管理工作：

            //  OutputCacheModule的配置参数通过system.web配置元素的caching子元素的outputCache元素进行定义。当启用输出缓存之后(启用还是通过配置文件，下同)，OutputCacheModule将注册HttpApplication的ResolveRequestCache和UpdateRequestCache两个事件完成输出缓存的管理。

            //  2、SessionStateModule完成Session的管理工作：

            //  这个Module的配置参数通过配置文件中的system.web配置元素的sessionState子元素进行配置。当启用Session状态管理之后，SessionStateModule将注册HttpApplication的AcquireRequestState、ReleaseRequestState、EndRequest三个事件完成Session状态的管理工作。

            //  3、ProfileModule提供个性化数据管理：
            //  这是一个自定义的类似于Session的会话状态管理，但是，个性化数据的读取和保存可以由程序员完全控制，并且提供了强类型的数据访问方式。这个Module的配置参数在system.web的子元素profile中进行说明。当启用了个性化数据管理之后，Module将注册HttpApplication的AcquireRequestState和EndRequest事件处理。

            //  4、AnonymousIdentificationModule提供匿名用户的标志：
            //  是否启用匿名用户标志在配置文件的system.web配置元素的子元素anonymousIdentification中定义，还可以配置匿名标识的管理方式。由于在AuthenticateRequest事件中将验证用户，获取用户名，所以这个Module注册了PostAuthenticateRequest的事件处理，当用户没有经过验证的时候，为用户分配一个唯一的匿名标识。

            //  5、WindowsAuthenticationModule、FormsAuthenticationModule和PassportAuthenticationModule用来完成用户的验证工作。
            //它们通过配置文件中system.web的子元素authentication子元素定义，mode属性用来指定网站当前使用的验证方式，也就是哪一个Module将被用来完成验证工作。在启用验证的情况下，FormsAuthenticationModule和PassportAuthenticationModule将注册HttpApplication的AuthenticateRequest和EndRequest事件进行用户的验证处理。WindowsAuthenticationModule将注册AuthenticateRequest的事件处理。

            //  6、RoleManagerModule、UrlAuthorizationModule、FileAuthorizationModule用来完成用户的授权管理：

            //  授权管理的配置参数来自system.web的authorization子元素。UrlAuthorizationModule和FileAuthorizationModule注册了HttpApplication的AuthorizeRequest事件处理，用来检查Url和文件的访问授权。RoleManagerModule在Url和文件访问授权检查通过之后，通过用户的标识和角色来完成用户的授权检查，RoleManagerModule注册了HttpApplication的PostAuthenticateRequest和EndRequest事件处理。
            #endregion
        }

        #endregion

        #region Handler
        /// <summary>
        /// 当前请求处理的handler
        /// </summary>
        /// <returns></returns>
        public ViewResult Handler()
        {
            IHttpHandler handler = base.HttpContext.Handler;
            //IHttpHandlerFactory

            //MvcHandler
            //MvcRouteHandler
            ViewBag.HandlerName = handler.GetType().ToString();
            ViewBag.Url = Request.Url.AbsoluteUri;
            return View();
        }


        public ViewResult MVCHandler()
        {
            //System.Web.Routing.UrlRoutingModule
            List<string> processList = new List<string>();
            processList.Add(string.Format("1 请求已经生成HttpApplication，经过一系列的Module处理后"));

            RouteData routeData = base.RouteData;
            processList.Add(string.Format("2 请求到达Module:{0},该模块会解析当前的请求，找到当前请求的{1}", typeof(UrlRoutingModule), routeData.GetType().Name));
            processList.Add(string.Format("3 该RouteData的内容为{0}，", JsonHelper.ToJson<RouteData>(routeData)));
            //IHttpHandler handler = routeData.RouteHandler.GetHttpHandler(base.Request.RequestContext);//当前请求信息为参数  
            //这里会抛异常  Additional information: 只能在引发“HttpApplication.AcquireRequestState”之前调用“HttpContext.SetSessionStateBehavior”。
            //这个时候handler已经明确了，不能再次获取了
            IHttpHandler handler = base.HttpContext.Handler;
            processList.Add(string.Format("4 然后调用该RouteData.RouteHandler.GetHttpHandler去获取该请求的处理handler：{0}", handler.GetType().FullName));
            processList.Add(string.Format("5 该handler默认是{0}，这个IHttpHandler会根据this.RequestContext.RouteData的控制器信息去找控制器的工厂，也就是我们扩展的{1},通过反射来完成控制器的激活 ",
                handler.GetType().FullName, typeof(UnityControllerFactory)));

            /*
             public class MvcHandler : IHttpHandler
             {
                 public bool IsReusable
                 {
                     get { return false; }
                 }
                 public RequestContext RequestContext { get; private set; }
                 public MvcHandler(RequestContext requestContext)
                 {
                     this.RequestContext = requestContext;
                 }
                 public void ProcessRequest(HttpContext context)
                 {
                     string controllerName = this.RequestContext.RouteData.Controller;
                     IControllerFactory controllerFactory = ControllerBuilder.Current.GetControllerFactory();
                     IController controller = controllerFactory.CreateController(this.RequestContext, controllerName);
                     controller.Execute(this.RequestContext);
                 }
             }
             */

            //UrlRoutingModule
            //RouteHandler
            //System.Web.Mvc.MvcHandler
            return View(processList);
        }
        //Action方法的执行=〉根据执行结果生成ActionResult=〉执行ActionResult
        public ViewResult MVCController()
        {
            List<string> processList = new List<string>();

            Type type = this.GetType();

            processList.Add(string.Format("1 HttpHandler会根据this.RequestContext.RouteData的控制器信息去找控制器的工厂{0},完成了控制器{1}的激活,", typeof(UnityControllerFactory), type.FullName));
            processList.Add(("2 然后handler执行了controller.Execute(this.RequestContext)，a)完成当前控制前的ControllerContext的初始化"));
            processList.Add(("3 b) RequestContext+RouteData里面的actionName去调用该控制器里面base.ActionInvoker.InvokeAction,在这里通过反射完成对action的调用"));
            processList.Add(("4 反射调用action的过程中，可以根据routedata和action的参数筛选合适的方法，可以根据方法的attribute完成对filter的支撑，调用完成后生成ViewResult"));
            processList.Add(("5 c)得到的ViewResult对象里面，还有一个ExecuteResult(ControllerContext context)方法，该方法会完成最终对Response.Write的写入"));
            return View(processList);
        }

        /// <summary>
        /// 拒绝浏览器
        /// </summary>
        /// <returns></returns>
        public ViewResult Refuse()
        {
            return View();
        }
        #endregion

        #region view

        public XmlResult XML()
        {
            return new XmlResult(
                new CurrentUser()
            {
                Id = 7,
                Name = "Y",
                Account = " ╰つ Ｈ ♥. 花心胡萝卜",
                Email = "莲花未开时",
                Password = "落单的候鸟",
                LoginTime = DateTime.Now
            });
        }
        public NewtonsoftJsonResult NewtonsoftJson()
        {
            return new NewtonsoftJsonResult(new { Id = 11, Name = "绚烂的夏" });
        }

        //View编译原理 
        public ViewResult ViewShow()
        {
            //
            Type type = BuildManager.GetCompiledType("~/Views/Pipe/ViewShow.cshtml");
            //它调用BuildManager的静态方法GetCompiledType根据指定的View文件虚拟路径得到编译后的WebPageView类型，
            //然后将该类型交给ViewPageActivator激活一个具体的WebPageView对象，并调用其Render方法完成对View的最终呈现
            ViewBag.ViewClass = type.FullName;
            return View("~/Views/Pipe/ViewShow.cshtml");

            //ASP.NET MVC对View文件进行动态编译生成的类型名称基于View文件的虚拟路径
            //（比如文件路径为“~/Views/Pipe/Action1.cshtml”的View对应的类型为“ASP._Page_Views_Pipe_Action1_cshtml”）。
            //ASP.NET MVC是按照目录进行编译的（“~/Views/Pipe/”下的View文件最终都被编译到一个程序集“App_Web_j04xtjsy”中）。
            //程序集按需加载，即第一次访问“~/View/Pipe/”目录下的View并不会加载针对“~/View/Home/”目录的程序集（实际上此时该程序集尚未生成）。

            //public override void Execute()
            //{
            //    this.WriteLiteral("<div>当前View类型：</div>\r\n<div>");
            //    this.Write(base.GetType().AssemblyQualifiedName);
            //    this.WriteLiteral("</div><br/>\r\n<div>当前加载的View程序集：</div>\r\n");
            //    this.Write(base.Html.ListViewAssemblies());
            //}
        }

        #endregion

        #region 自定义view
        public void ViewTest()
        {
            ViewData.Model = new CurrentUser
            {
                Id = 11,
                Name = "Eleven",
                Email = "57265177@qq.com"
            };
            SimpleRazorView view = new SimpleRazorView("~/Views/Pipe/ViewTest.cshtml");
            ViewContext viewContext = new ViewContext(ControllerContext, view, ViewData, TempData, Response.Output);
            view.Render(viewContext, viewContext.Writer);
        }

        public class SimpleRazorView : IView
        {
            public string ViewPath { get; private set; }

            public SimpleRazorView(string viewPath)
            {
                this.ViewPath = viewPath;
            }

            public void Render(ViewContext viewContext, TextWriter writer)
            {
                Type viewType = BuildManager.GetCompiledType(this.ViewPath);
                object instance = Activator.CreateInstance(viewType);
                WebViewPage page = (WebViewPage)instance as WebViewPage;

                page.VirtualPath = this.ViewPath;
                page.ViewContext = viewContext;
                page.ViewData = viewContext.ViewData;
                page.InitHelpers();

                WebPageContext pageContext = new WebPageContext(viewContext.HttpContext, null, null);
                WebPageRenderingBase startPage = StartPage.GetStartPage(page, "_ViewStart", new string[] { "cshtml" });
                page.ExecutePageHierarchy(pageContext, writer, startPage);
            }
        }
        #endregion 自定义view
    }
}