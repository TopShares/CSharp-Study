//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Web;
//using System.Web.Mvc;
//using System.Xml.Serialization;

//namespace Ruanmou.Web.Core.Extension
//{
//    public class ElevenViewResult : ViewResult
//    {
//        public ViewResult _ViewResult = null;
//        public ElevenViewResult(ViewResult viewResult)
//        {
//            this._ViewResult = viewResult;
//        }

//        protected override ViewEngineResult FindView(ControllerContext context)
//        {
//            if (context.RequestContext.HttpContext.Request.IsMobile())
//            //{
//                base.ViewName = this._ViewResult.ViewName;
//                base.MasterName = this._ViewResult.MasterName;
//                base.ViewData = this._ViewResult.ViewData;
//                base.TempData = this._ViewResult.TempData;
//                base.ViewEngineCollection = this._ViewResult.ViewEngineCollection;
//            //}

//            return base.FindView(context);
//        }
//    }
//}