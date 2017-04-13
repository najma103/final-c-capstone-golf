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

        public HomeController(IUserDAL userDal)
        {
            this.userDal = userDal;
        }


        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("List", "Tournament");
        }
        public ActionResult CreateTournamentForm()
        {
            Tournament model = new Tournament();
            return View("CreateTournamentForm","Tournament", model);
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