using Ruanmou.Web.Core.Filter;
using System.Web;
using System.Web.Mvc;

namespace Ruanmou.MVC5
{
    public class FilterConfig
    {
        /// <summary>
        /// 注册全局filter扩展
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            //filters.Add(new LogExceptionFilter());//升级成自定义的异常扩展
            filters.Add(new AuthorityFilter());//全局注册，全部要求登陆
        }
    }
}
