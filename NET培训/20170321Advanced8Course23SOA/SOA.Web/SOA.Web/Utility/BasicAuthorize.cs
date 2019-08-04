using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SOA.Web.Utility
{
    /// <summary>
    /// API权限验证
    /// </summary>
    public class BasicAuthorize : System.Web.Http.AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization != null)
            {
                string userInfo = Encoding.Default.GetString(Convert.FromBase64String(actionContext.Request.Headers.Authorization.Parameter));
                //用户验证逻辑
                if (string.Equals(userInfo, string.Format("{0}:{1}", "Parry", "123456")))
                {
                    IsAuthorized(actionContext);
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            else
            {
                HandleUnauthorizedRequest(actionContext);
            }
        }

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var challengeMessage = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);//告诉浏览器要验证
            challengeMessage.Headers.Add("WWW-Authenticate", "Basic");//权限信息放在basic
            throw new System.Web.Http.HttpResponseException(challengeMessage);
        }
    }
}