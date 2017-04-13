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
            //return RedirectToAction("List", "Tournament");
            List<Tournament> list = new List<Tournament>();
            Tournament bracket = new Tournament();

            list = bracket.GetAllTournaments();
            return View("Index", list);
        }
        public ActionResult CreateTournament(Tournament model)
        {
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