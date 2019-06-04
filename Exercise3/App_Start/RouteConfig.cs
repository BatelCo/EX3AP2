using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

            // first route : display/127.0.0.1/5400
            routes.MapRoute(
            name: "Display",
            url: "display/{str}/{num}",
            defaults: new { controller = "First", action = "Display" },
            constraints: new {controller = new IsIP()}
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
            url: "save/{ip}/{port}/{freq}/{time}/{flight}",
            //, flight = UrlParameter.Optional
            defaults: new { controller = "Third", action = "Display3" }
         );
            //fourth route : display / flight1 / 4
            routes.MapRoute(
            name: "Display4",
            url: "display/{flight}/{freq}",
            defaults: new { controller = "Fourth", action = "Display4" }
         );
            // default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                // if you dont get enything go hear
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
         );
        }

        private class IsIP : IRouteConstraint
        {
            public IsIP() {}

            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                object f;
                foreach (KeyValuePair<string, object> item in values)
                {
                    f = item.Value;
                    if (Regex.IsMatch(f.ToString(), @"^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$"))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
