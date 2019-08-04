using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ruanmou.Web.Core.Filter
{

    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        private Stopwatch timer=new Stopwatch();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer.Start();
            filterContext.HttpContext.Response.Write("<div>这里是OnActionExecuting</div>");
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            timer.Stop();
            string message = string.Format("<div>这里是OnActionExecuted: {0}</div>", timer.ElapsedMilliseconds);
            filterContext.HttpContext.Response.Write(message);
        }
    }

}