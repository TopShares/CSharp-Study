using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ruanmou.MVC5.Utility;
using Ruanmou.Web.Core.Filter;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Ruanmou.Framework.Extension;
using Ruanmou.Framework.ImageHelper;

namespace Ruanmou.MVC5.Controllers
{
    /// <summary>
    /// 1 用户登陆和检验：AuthorizeAttribute
    /// 2 HttpGet HttpPost AllowAnonymous ChildActionOnly
    /// 3 全局异常处理：HandleErrorAttribute
    /// 4 IActionFilter IResultFilter
    /// 5 Unity的AOP
    /// 6 各种ActionResult
    /// </summary>
    [AllowAnonymous]
    public class FourthController : Controller
    {
        [HttpGet]//[AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string password, string verify)
        {
            //name = string.IsNullOrEmpty(name) ? context.Request.Params["Name"] : name;
            //pwd = string.IsNullOrEmpty(pwd) ? context.Request.Params["Password"] : pwd;
            //verify = string.IsNullOrEmpty(verify) ? context.Request.Params["Verify"] : verify;

            UserManage.LoginResult result = this.HttpContext.UserLogin(name, password, verify);

            if (result == UserManage.LoginResult.Success)
            {
                if (this.HttpContext.Session["CurrentUrl"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    string url = this.HttpContext.Session["CurrentUrl"].ToString();
                    this.HttpContext.Session["CurrentUrl"] = null;
                    return Redirect(url);
                }
            }
            else
            {
                ModelState.AddModelError("failed", result.GetRemark());
                return View();
            }
        }
        /// <summary>
        /// 验证码 FileContentResult
        /// </summary>
        /// <returns></returns>
        public ActionResult VerifyCode()
        {
            string code = "";
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            base.HttpContext.Session["CheckCode"] = code;
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Gif);
            return File(stream.ToArray(), "image/gif");//返回FileContentResult图片
        }
        /// <summary>
        /// 验证码  直接写入Response
        /// </summary>
        public void Verify()
        {
            string code = "";
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            base.HttpContext.Session["CheckCode"] = code;
            bitmap.Save(base.Response.OutputStream, ImageFormat.Gif);
            base.Response.ContentType = "image/gif";
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Logout()
        {
            this.HttpContext.UserLogout();
            return RedirectToAction("Index", "Home"); ;
        }


        [CacheFilter(60)]
        [CompressFilter]
        [RenderFilter]
        public ViewResult TestFilter()
        {
            return View();
        }

        public ViewResult TestFilterUnCompress()
        {
            return View();
        }

        public ViewResult TestFilterException()
        {
            throw new Exception("TestFilterException Exception");
            return View();
        }
    }
}