using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ruanmou.CoreDemo.Framework;
using Ruanmou.CoreDemo.DB;

namespace Ruanmou.CoreDemo.MVC.Controllers
{
    public class HomeController : Controller
    {
        private EFDbContext _EFDbContext;
        public HomeController(EFDbContext context)
        {
            this._EFDbContext = context;
        }



        public IActionResult Index()
        {
            base.ViewData["User1"] = new CurrentUser()
            {
                Id = 7,
                Name = "Y",
                Account = " ╰つ Ｈ ♥. 花心胡萝卜",
                Email = "莲花未开时",
                Password = "落单的候鸟",
                LoginTime = DateTime.Now
            };

            base.ViewData["Something"] = 12345;


            base.ViewBag.User = new CurrentUser()
            {
                Id = 7,
                Name = "IOC",
                Account = "限量版",
                Email = "莲花未开时",
                Password = "落单的候鸟",
                LoginTime = DateTime.Now
            };

            base.TempData["User"] = new CurrentUser()
            {
                Id = 7,
                Name = "CSS",
                Account = "季雨林",
                Email = "KOKE",
                Password = "落单的候鸟",
                LoginTime = DateTime.Now
            };//后台可以跨action   需要session才能实现

            return View("~/Views/Home/Index2.cshtml", new CurrentUser()
            {
                Id = 7,
                Name = "一点半",
                Account = "季雨林",
                Email = "KOKE",
                Password = "落单的候鸟",
                LoginTime = DateTime.Now
            });
        }

        public JsonResult DB(int index)
        {
            //Company company = new Company()
            //{
            //    Name = "软谋教育",
            //    CreateTime = DateTime.Now,
            //    CreatorId = 1,
            //    LastModifierId = 1,
            //    LastModifyTime = DateTime.Now
            //};


            //this._EFDbContext.Add(company);
            //this._EFDbContext.SaveChanges();
            //return Json(company);

            Users user = new Users()
            {
                Name = string.Format("Test{0}", index),
                Account = new Random().Next(10000, 99999).ToString(),
                Password = "448",
                Email = "25759541@qq.com",
                Mobile = "13111111111",
                CompanyId = 1,
                CompanyName = string.Format("软谋教育{0}", index.ToString("000")),
                State = 1,
                UserType = 2,
                LastLoginTime = DateTime.Now,
                CreateTime = DateTime.Now,
                CreatorId = 1,
                LastModifierId = 1,
                LastModifyTime = DateTime.Now
            };

            this._EFDbContext.Set<Ruanmou.CoreDemo.DB.Users>().Add(user);
            this._EFDbContext.SaveChanges();

            return Json(this._EFDbContext.Set<Users>().Find(user.Id));

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
