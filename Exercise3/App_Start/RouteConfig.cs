using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Exercise3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // which routes I can get in my website
            routes.MapRoute(
                name: "Display",
                url: "display/{ip}/{port}",
                defaults: new { controller = "First", action = "Display" }

                );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                // if you dont get enything go hear
                defaults: new { controller = "First", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
