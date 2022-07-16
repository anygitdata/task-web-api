using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TaskWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы Web API

            // Маршруты Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "List_with_page_and_sortied",
               routeTemplate: "api/list/{controller}/{page}/{sort}",
               defaults: new { page = RouteParameter.Optional, sort = RouteParameter.Optional }
            );


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


           

        }
    }
}
