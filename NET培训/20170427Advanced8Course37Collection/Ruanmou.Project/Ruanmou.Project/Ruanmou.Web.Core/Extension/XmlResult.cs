using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Ruanmou.Web.Core.Extension
{
    /// <summary>
    /// 自定义扩展XML格式result
    /// </summary>
    public class XmlResult : ActionResult
    {
        private object _data;

        public XmlResult(object data)
        {
            _data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var serializer = new XmlSerializer(_data.GetType());
            var response = context.HttpContext.Response;
            response.ContentType = "text/xml";
            serializer.Serialize(response.Output, _data);
        }
    }
}