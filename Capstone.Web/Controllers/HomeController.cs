using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            List<Tournament> tournamentList = new List<Tournament>();
            //return View("Index", tournamentList);
            return View("Index");
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
            return View("CreateTournament", model);
        }
    }
}