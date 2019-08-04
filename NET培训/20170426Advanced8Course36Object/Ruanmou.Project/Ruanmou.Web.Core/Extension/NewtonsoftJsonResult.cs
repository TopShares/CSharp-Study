using Ruanmou.Framework.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Ruanmou.Web.Core.Extension
{
    /// <summary>
    /// 自定义扩展json格式result
    /// </summary>
    public class NewtonsoftJsonResult : ActionResult
    {
        private object _Data = null;

        public NewtonsoftJsonResult(object data)
        {
            _Data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            response.Write(JsonHelper.ToJson(this._Data));
        }
    }
}