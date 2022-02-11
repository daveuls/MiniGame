using Name_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Name_Game.Controllers
{
    public class EndGameController : Controller
    {
        // GET: EndGame
        public ActionResult EndGameScreen()
        {
            Selections selections = new Selections();
            int numOfCorrectResponses = Convert.ToInt32(System.Web.HttpContext.Current.Session["numOfCorrectSelections"]);
            int numOfIncorrectResponses = Convert.ToInt32(System.Web.HttpContext.Current.Session["numOfIncorrectSelections"]);

            selections.Correct = numOfCorrectResponses;
            selections.Incorrect = numOfIncorrectResponses;

            return View(selections);
        }
    }
}