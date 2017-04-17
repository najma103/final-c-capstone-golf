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
            return View("Index",model);
        }
	
	/// <summary>
        /// "Logs" the current user in
        /// </summary>
        public void LogUserIn(string email, string accountType, string displayName, int userId)
        {
            //Session.Abandon();
            //Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Session[SessionKeys.UsernameKey] = email;
            Session[SessionKeys.AccountType] = accountType;
            Session[SessionKeys.DisplayName] = displayName;
            Session[SessionKeys.UserId] = userId;

        }

        public bool IsAuthenticated
        {
            get
            {
                return Session[SessionKeys.UsernameKey] != null;
            }
        }

        public string CurrentUser
        {
            get
            {
                string username = string.Empty;

                //Check to see if user cookie exists, if not create it
                if (Session[SessionKeys.UsernameKey] != null)
                {
                    username = (string)Session[SessionKeys.UsernameKey];
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
