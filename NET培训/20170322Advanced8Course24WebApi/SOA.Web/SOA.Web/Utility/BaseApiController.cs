using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace SOA.Web.Utility
{
    public class BaseApiController : ApiController
    {
        public override Task<System.Net.Http.HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            //controllerContext.RouteData
            var content = controllerContext.Request.Content;
            string contentString = content.ReadAsStringAsync().Result;
            var headers = controllerContext.Request.Headers;
            var method = controllerContext.Request.Method;
            var prop = controllerContext.Request.Properties;
            var uri = controllerContext.Request.RequestUri;
            var version = controllerContext.Request.Version;
            #region 参数获取
            string name=  HttpContext.Current.Request.QueryString["userName"];



            //var keyvalue=  controllerContext.Request.Properties["MS_QueryNameValuePairs"];
            //foreach(var property in controllerContext.Request.Properties)
            //{
            //    var data=property.Value;
            //    if(data is System.Web.Http.ValueProviders.Providers.QueryStringValueProvider)
            //    {
            //        string name2=((System.Web.Http.ValueProviders.Providers.QueryStringValueProvider)data).GetValue("userName").RawValue.ToString();
            //    }
            //}

            #endregion 参数获取

            return base.ExecuteAsync(controllerContext, cancellationToken);
        }
    }
}