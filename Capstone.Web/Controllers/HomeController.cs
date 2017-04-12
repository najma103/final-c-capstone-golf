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
        private const string UsernameKey = "Bracket_Username";
        // GET: Home
        public ActionResult Index()
        {
            List<Tournament> tournamentList = new List<Tournament>();
            TournamentSqlDal DAL = new TournamentSqlDal();
            tournamentList = DAL.getAllTournaments();
            return View("Index", tournamentList);
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
        public bool IsAuthenticated
        {
            get
            {
                return Session[UsernameKey] != null;
            }
        }

        public string CurrentUser
        {
            get
            {
                string username = string.Empty;

                //Check to see if user cookie exists, if not create it
                if (Session[UsernameKey] != null)
                {
                    username = (string)Session[UsernameKey];
                }

                return username;
            }
        }
    }
}