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
            //return RedirectToAction("List", "Tournament");
            List<Tournament> model = tournamentDal.getAllTournaments();
            return View(model);
        }
        public ActionResult CreateTournamentForm()
        {
            //if(t.Name != "" && t.CompetitorLimit > 0 && t.CompetitorLimit <=16
            //    && t.StartDate >= DateTime.UtcNow && t.EndDate > t.StartDate)

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
