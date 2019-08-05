using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPIDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetRequest()
        {
            return View();
        }
        public ActionResult PostRequest()
        {
            return View();
        }
        public ActionResult OtherRequest()
        {
            return View();
        }
        public ActionResult ReturnResult()
        {
            return View();
        }

        public ActionResult FormAuthorize()
        {
            return View();
        }

    }
}