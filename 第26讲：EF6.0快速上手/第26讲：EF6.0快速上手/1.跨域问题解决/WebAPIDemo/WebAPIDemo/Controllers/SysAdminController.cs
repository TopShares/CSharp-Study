using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace WebAPIDemo.Controllers
{
    [RoutePrefix("api/SysAdmin")]
    public class SysAdminController : ApiController
    {
        /// <summary>
        /// 用户登录方法
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        [AllowAnonymous]//可以不加
        [Route("AdminLogin")]
        [HttpPost]
        public string AdminLogin(Models.SysAdmin admin)
        {
            if (CheckLogin(admin))//如果登录成功，则保持登录信息到票据
            {
                //【1】创建身份认证票据
                #region 

                // 摘要:
                //     使用 cookie 名、版本、目录路径、发布日期、过期日期、持久性以及用户定义的数据初始化 System.Web.Security.FormsAuthenticationTicket
                //     类的新实例。
                //
                // 参数:
                //   version:
                //     票证的版本号。
                //
                //   name:
                //     与票证关联的用户名。
                //
                //   issueDate:
                //     票证发出时的本地日期和时间。
                //
                //   expiration:
                //     票证过期时的本地日期和时间。
                //
                //   isPersistent:
                //     如果票证将存储在持久性 Cookie 中（跨浏览器会话保存），则为 true；否则为 false。如果该票证存储在 URL 中，将忽略此值。
                //
                //   userData:
                //     存储在票证中的用户特定的数据。
                //
                //   cookiePath:
                //     票证存储在 Cookie 中时的路径。
                // public FormsAuthenticationTicket(int version, string name, DateTime issueDate, DateTime expiration, bool isPersistent, string userData, string cookiePath);
                #endregion
                FormsAuthenticationTicket userTicket = new FormsAuthenticationTicket
                    (0, admin.LoginId, DateTime.Now, DateTime.Now.AddHours(1), true,
                    $"{admin.LoginId}&{admin.LoginPwd}", FormsAuthentication.FormsCookiePath);

                //【2】将身份票据加密后封装
                var encryptTicket = new { Success = true, Ticket = FormsAuthentication.Encrypt(userTicket) };

                //【3】序列化身份票据为JSON形式返回
                return Newtonsoft.Json.JsonConvert.SerializeObject(encryptTicket);
            }
            else
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(new { Success = false });
            }
        }
        private bool CheckLogin(Models.SysAdmin admin)
        {
            //从数据库中验证登录信息...


            return true;//将来自己添加业务逻辑，登录账号不对，则返回false
        }
    }
}
