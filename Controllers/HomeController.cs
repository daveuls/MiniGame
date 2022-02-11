using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Name_Game.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult StartScreen()
        {
            System.Web.HttpContext.Current.Session["numOfCorrectSelections"] = 0;
            System.Web.HttpContext.Current.Session["numOfIncorrectSelections"] = 0;
            System.Web.HttpContext.Current.Session["gameRound"] = 1;
            System.Web.HttpContext.Current.Session["correctList"] = null;
            return View();
        }
    }
}