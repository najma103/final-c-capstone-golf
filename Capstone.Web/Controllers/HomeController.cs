using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            List<Tournament> list = new List<Tournament>();
            Tournament bracket = new Tournament();

            list = bracket.GetAllTournaments();
            return View("Index", list);
        }
        public ActionResult CreateTournament(Tournament model)
        {
            //// If the user has not logged in yet, make them log in
            //if (Session[SessionKeys.UserId] == null)
            //{
            //    return RedirectToAction("Login", "User");
            //}

            //if (ModelState.IsValid)
            //{
            //    return View("CreateTournament", model);
            //}
            //return View("Index");
            Tournament t = new Tournament();
            //if(t.Name != "" && t.CompetitorLimit > 0 && t.CompetitorLimit <=16
            //    && t.StartDate >= DateTime.UtcNow && t.EndDate > t.StartDate)
            if(model.CompetitorLimit > 0 && model.CompetitorLimit <= 16)
            {
                // add to the database
                int[] arr1 = new int[model.CompetitorLimit];
                arr1 = t.GenerataFirstBracket(model.CompetitorLimit);

                for (int i = 0; i < arr1.Length; i++)
                {
                    t.Brackets[i] = arr1[i];
                }

                return View("Brackets", model);
            }
            return View("CreateTournament", model);
        }

        public ActionResult Brackets(Tournament model)
        {
            return View("Brackets");
        }
    }
}