using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Name_Game
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Start Screen
            routes.MapRoute(
                name: "Start",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "StartScreen" }
                );

            // Game
            routes.MapRoute(
                name: "Play",
                url: "{controller}/{action}",
                defaults: new { controller = "Play", action = "PlayGameScreen" }
                );

            // End Game
            routes.MapRoute(
                name: "EndGame",
                url: "EndGame/{action}",
                defaults: new { controller = "EndGame", action = "EndGameScreen" }
                );

            // Default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "StartScreen", id = UrlParameter.Optional }
            );
        }
    }
}
