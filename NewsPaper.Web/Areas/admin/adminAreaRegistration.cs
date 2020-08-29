using System.Web.Mvc;

namespace NewsPaper.Web.Areas.admin
{
    public class adminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "QuanLy_Tintuc",
                "quan-ly/tin-tuc",
                new {controller = "Articles", action = "Index", id = UrlParameter.Optional }
                );
            context.MapRoute(
                "admin_default",
                "admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}