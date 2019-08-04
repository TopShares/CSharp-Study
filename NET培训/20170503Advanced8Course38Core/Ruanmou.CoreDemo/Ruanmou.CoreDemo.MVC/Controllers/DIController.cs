using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ruanmou.CoreDemo.Framework.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace Ruanmou.CoreDemo.MVC.Controllers
{
    public class DIController : Controller
    {
        private IPhone _Phone = null;

        public DIController(IPhone phone)
        {
            this._Phone = phone;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}