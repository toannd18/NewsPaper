using System.Web.Mvc;
using System.Web.Routing;

namespace NewsPaper.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

          //  routes.MapRoute(
          //    name: "Quanly_Tintucs",
          //    url: "quan-ly/tin-tuc.html",
          //    defaults: new { areas = "admin", controller = "slides", action = "Index" },
          //    namespaces: new[] { "NewsPaper.Web.Areas.admin.Controllers" }
          //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "NewsPaper.Web.Controllers" }
            );
        }
    }
}