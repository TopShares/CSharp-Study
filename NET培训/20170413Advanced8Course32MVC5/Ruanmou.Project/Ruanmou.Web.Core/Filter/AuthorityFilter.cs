using Ruanmou.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ruanmou.MVC5.Utility
{
    /// <summary>
    /// 检验登陆和权限的filter
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = true)]
    public class AuthorityFilter : AuthorizeAttribute
    {
        /// <summary>
        /// 检查用户登录
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
            || filterContext.ActionDescriptor.ControllerDescriptor .IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;//表示支持控制器、action的AllowAnonymousAttribute
            }
            var sessionUser = HttpContext.Current.Session["CurrentUser"];

            //var memberValidation = HttpContext.Current.Request.Cookies.Get("CurrentUser");
            if (sessionUser == null || !(sessionUser is CurrentUser))
            {
                HttpContext.Current.Session["CurrentUrl"] = filterContext.RequestContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectResult("/Account/Login");
                //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Login" }));
                return;
            }
            else
            {
                CurrentUser currentUser = (CurrentUser)sessionUser;
                return;
            }
        }
    }
}