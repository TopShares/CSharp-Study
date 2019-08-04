using System.Web.Mvc;

namespace Ruanmou.MVC5.Areas.JD
{
    public class JDAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "JD";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "JD_default",
                "JD/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "Ruanmou.MVC5.Areas.JD.Controllers" }
            );
        }
    }
}