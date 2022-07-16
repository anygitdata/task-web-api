using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TaskWebApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "DebugDocror",
                url: "debgdoctor",
                defaults: new { controller = "Home", action = "DebgDoctor" }
            );


            routes.MapRoute(
                name: "DebugPatient",
                url: "debgpatient",
                defaults: new { controller = "Home", action = "DebgPatient"}
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
