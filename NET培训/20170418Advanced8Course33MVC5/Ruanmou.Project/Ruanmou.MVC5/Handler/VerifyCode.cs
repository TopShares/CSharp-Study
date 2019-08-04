using Ruanmou.Framework.ImageHelper;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;

namespace Ruanmou.MVC5.Handler
{
    /// <summary>
    /// 一般处理形式
    /// </summary>
    public class VerifyCode : IHttpHandler
    {
        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此处理程序 
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参阅以下链接: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // 如果无法为其他请求重用托管处理程序，则返回 false。
            // 如果按请求保留某些状态信息，则通常这将为 false。
            get { return true; }
        }
        /// <summary>
        /// httphandler
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            //在此处写入您的处理程序实现。
            string code = "";
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            context.Session["CheckCode"] = code;
            bitmap.Save(context.Response.OutputStream, ImageFormat.Gif);
            context.Response.ContentType = "image/gif";
        }

        #endregion
    }
}
