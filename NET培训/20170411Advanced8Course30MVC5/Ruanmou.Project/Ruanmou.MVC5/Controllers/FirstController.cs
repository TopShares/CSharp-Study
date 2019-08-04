using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ruanmou.MVC5.Controllers
{
    public class FirstController : Controller
    {
        // GET: First
        public ActionResult Index()
        {
            return View();
        }

        public string String()
        {
            return "曾经沧海";
        }

        public string Id(string id)
        {
            return id;
        }

        public void ResponseWrite()
        {
            this.Response.Write("一点半");
            this.Response.End();
            //HttpContext.Response.Write("一点半");
            //HttpContext.Response.End();
        }

        public string Time(int year, int month, int day)
        {
            return string.Format("{0}年{1}月{2}日", year, month, day);
        }
    }
}