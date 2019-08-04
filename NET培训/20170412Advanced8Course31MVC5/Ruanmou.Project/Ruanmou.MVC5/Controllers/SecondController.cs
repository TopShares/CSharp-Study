using Ruanmou.Bussiness.Interface;
//using Ruanmou.Bussiness.Service;
using Ruanmou.EF.Model;
using Ruanmou.Web.Core.IOC;
using Ruanmou.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace Ruanmou.MVC5.Controllers
{
    /// <summary>
    /// 1 多种传值方式，指定view路径
    /// 2 razor语法，html扩展控件，layout,partialView 
    /// 3 ioc和mvc的结合，工厂的创建和Bussiness初始化
    /// 4 WCF搜索引擎的封装调用
    /// </summary>
    public class SecondController : Controller
    {
        private IUserMenuService _iUserMenuService = null;
        public SecondController(IUserMenuService userMenuService)
        {
            this._iUserMenuService = userMenuService;
        }

        public SecondController()
        { 
        }

        public ActionResult Index()
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
            };//后台可以跨action

            //return this.RedirectToAction("TempDataPage");
            //return View(new CurrentUser()
            //{
            //    Id = 7,
            //    Name = "一点半",
            //    Account = "季雨林",
            //    Email = "KOKE",
            //    Password = "落单的候鸟",
            //    LoginTime = DateTime.Now
            //});
            return View("~/Views/Second/Index2.cshtml", new CurrentUser()
            {
                Id = 7,
                Name = "一点半",
                Account = "季雨林",
                Email = "KOKE",
                Password = "落单的候鸟",
                LoginTime = DateTime.Now
            });
        }

        /// <summary>
        /// TempData默认是使用Session来存储临时数据的，TempData中存放的数据只一次访问中有效，
        /// 一次访问完后就会删除了的。这个一次访问指的是一个请求到下一个请求
        /// </summary>
        /// <returns></returns>
        public ViewResult TempDataPage()
        {
            CurrentUser user = TempData["User"] as CurrentUser;
            CurrentUser user2 = base.HttpContext.Session["__ControllertempData"] as CurrentUser;
            return View();
        }

        /// <summary>
        /// 行内(Inline)标记  
        /// 单行(Single Line)标记   
        /// 多行(Multi-Line)标记
        /// 在遇到如if、for、while等具有"keyword(){}"形式的C#代码结构时，Razor标记可以写成"@keyword(){}"这样的特殊形式。
        /// 服务器代码里嵌入html代码
        /// 在Razor标记的代码中如果有成对的html标记，则这个标记及其内容会被当作普通文本输出。
        /// 在Razor标记的代码中如果有"@:"，则其后的一行代码会被当作普通文本输出。
        /// 在Razor标记的代码中如果有text  /text标记，则其内容会被当作普通文本输出
        /// </summary>
        /// <returns></returns>
        public ViewResult RazorShow()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [ChildActionOnly]//不能被单独请求
        public ViewResult Render(string name)
        {
            ViewBag.Name = name;
            return View();
            //return PartialView()  //指定分部视图，在_ViewStatrt.cshtml中指定的Layout会无效
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ViewResult DB()
        {
            //{
            //    DbContext dbContext = new JDContext();
            //    IUserMenuService service = new UserMenuService(dbContext);
            //    User user = service.Find<User>(2);
            //}

            //{
            //    IUserMenuService service = DIFactory.GetContainer().Resolve<IUserMenuService>();
            //    User user = service.Find<User>(2);
            //}
            {
                User user = this._iUserMenuService.Find<User>(2);
            }

            return View();
        }



    }
}