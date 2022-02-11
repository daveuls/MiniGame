using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Name_Game
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            HttpContext.Current.Session.Add("numOfCorrectSelections", 0);
            HttpContext.Current.Session.Add("numOfIncorrectSelections", 0);
            HttpContext.Current.Session.Add("gameRound", 1);
            HttpContext.Current.Session.Add("correctList", new List<string>());
        }
    }
}
