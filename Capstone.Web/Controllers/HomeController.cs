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
        private readonly IUserDAL userDal;
        private readonly ITournamentDAL tournamentDal;

        public HomeController(IUserDAL userDal, ITournamentDAL tournamentDal)
        {
            this.userDal = userDal;
            this.tournamentDal = tournamentDal;
        }

        // GET: Home
        public ActionResult Index()
        {
<<<<<<< HEAD
            //return RedirectToAction("List", "Tournament");
            List<Tournament> list = new List<Tournament>();
            Tournament bracket = new Tournament();

            list = bracket.GetAllTournaments();
            return View("Index", list);
=======
            List<Tournament> model = tournamentDal.getAllTournaments();
            return View(model);
>>>>>>> 8dd9874c774926f1ee1a0363f644828655015107
        }
        public ActionResult CreateTournamentForm()
        {
<<<<<<< HEAD
            Tournament t = new Tournament();
            //if(t.Name != "" && t.CompetitorLimit > 0 && t.CompetitorLimit <=16
            //    && t.StartDate >= DateTime.UtcNow && t.EndDate > t.StartDate)
            if(model.CompetitorLimit > 0 && model.CompetitorLimit <= 16)
            {
                // add to the database
                Tournament t2 = new Tournament();
                int[] arr1 = new int[model.CompetitorLimit];
                arr1 = t2.GenerataFirstBracket(model.CompetitorLimit);


                t.Brackets = arr1;

            return View("Brackets", t);
            }
            return View("CreateTournament", model);
=======

	    Tournament model = new Tournament();
            
	    //If the user has not logged in yet, make them log in
            if (Session[SessionKeys.UserId] == null)
            {
                return RedirectToAction("Login", "User");
            }

            if (ModelState.IsValid)
            {
                return View("CreateTournamentForm","Tournament", model);
            }

            return RedirectToAction("Index", "Home", null);

>>>>>>> 8dd9874c774926f1ee1a0363f644828655015107
        }
	
	/// <summary>
        /// "Logs" the current user in
        /// </summary>
        public void LogUserIn(string username)
        {
            //Session.Abandon();
            //Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Session[UsernameKey] = username;
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
        public ActionResult Brackets(Tournament model)
        {
            return View("Brackets");
        }
    }
}
