using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Name_Game.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GameStart()
        {
            return View();
        }
    }
}