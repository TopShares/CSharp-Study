using Ruanmou.Web.Core.Extension;
using Ruanmou.Web.Core.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ruanmou.MVC5.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
            //return new ElevenViewResult(View());
        }
    }
}
