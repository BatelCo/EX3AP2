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

            // fourth route : display/flight1/4   
            routes.MapRoute(
            name: "Display4",
            url: "display/flight1/4",
            defaults: new { controller = "Fourth", action = "Display4" }
         );
            // first route : display/127.0.0.1/5400
            routes.MapRoute(
            name: "Display",
            url: "display/{ip}/{port}",
            defaults: new { controller = "First", action = "Display" }
         );
            // second route : display/127.0.0.1/5400/4 
            routes.MapRoute(
            name: "Display2",
            url: "display/{ip}/{port}/{freq}",
            defaults: new { controller = "Second", action = "Display2"}
         );
            // third route : save/127.0.0.1/5400/4/10/flight1
            routes.MapRoute(
            name: "Display3",
            url: "save/{ip}/{port}/{freq}/{time}/flight1",
            defaults: new { controller = "Third", action = "Display3" }
         );
            // default
          routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                // if you dont get enything go hear
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
         );
        }
    }
}
