using Name_Game.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Name_Game.Controllers
{
    public class PlayController : Controller
    {
        public async Task<ActionResult> PlayGameScreen()
        {
            int gameRound = Convert.ToInt32(System.Web.HttpContext.Current.Session["gameRound"]);
            string baseUrl = "https://namegame.willowtreeapps.com/";
            List<Employees> employeeList = new List<Employees>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/v1.0/profiles");

                    if (response.IsSuccessStatusCode)
                    {
                        var employeeResponse = response.Content.ReadAsStringAsync().Result;
                        employeeList = JsonConvert.DeserializeObject<List<Employees>>(employeeResponse);
                    }

                    employeeList = GetRandomEmployees(employeeList);

                    return View(employeeList);
                }
            }
            catch (Exception e)
            {
                return View(e);
            }
        }
        public List<Employees> GetRandomEmployees(List<Employees> employeeList)
        {
            Random random = new Random();
            List<Employees> randomEmployees = new List<Employees>();
            //session list of names that were correc
            List<string> correctEmployeeSelections = (List<string>)System.Web.HttpContext.Current.Session["correctList"];
            string fullName = "";
            

            while (randomEmployees.Count < 6)
            {
                Employees employee = employeeList[random.Next(employeeList.Count)];
                fullName = employee.FirstName + employee.LastName;

                if (!randomEmployees.Contains(employee) && !correctEmployeeSelections.Contains(fullName))
                {
                    randomEmployees.Add(employee);
                }
            }

            return randomEmployees;
        }

        [HttpPost]
        public bool PictureSelection(string selectedEmployee, string employeeName)
        {
            bool correctSelection = false;
            int numOfCorrectSelections = Convert.ToInt32(System.Web.HttpContext.Current.Session["numOfCorrectSelections"]);
            int numOfIncorrectSelections = Convert.ToInt32(System.Web.HttpContext.Current.Session["numOfIncorrectSelections"]);
            int gameRound = Convert.ToInt32(System.Web.HttpContext.Current.Session["gameRound"]);

            List<string> correctNames = (List<string>)System.Web.HttpContext.Current.Session["correctList"];

            Employees correctEmployee = new Employees();

            if (!string.IsNullOrEmpty(selectedEmployee) && !string.IsNullOrEmpty(employeeName))
            {
                if (selectedEmployee == employeeName)
                {
                    correctSelection = true;
                    numOfCorrectSelections += 1;
                    System.Web.HttpContext.Current.Session["numOfCorrectSelections"] = numOfCorrectSelections;
                    correctNames.Add(employeeName);
                    System.Web.HttpContext.Current.Session["correctList"] = correctNames;
                }
                else
                {
                    numOfIncorrectSelections += 1;
                    System.Web.HttpContext.Current.Session["numOfIncorrectSelections"] = numOfIncorrectSelections;
                }

                gameRound += 1;
                System.Web.HttpContext.Current.Session["gameRound"] = gameRound;
            }

            return correctSelection;
        }
    }
}