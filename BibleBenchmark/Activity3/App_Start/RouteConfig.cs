using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Activity3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Add",
                url: "{AddVerse}",
                defaults: new { controller = "Bible", action = "Add", id = UrlParameter.Optional }               
            );
            routes.MapRoute(
                name: "Search",
                url: "{SearchVerse}",
                defaults: new { controller = "Bible", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "HomePage",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Bible", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
