using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ITournamentDAL tournamentDal;

        public TournamentController(ITournamentDAL tournamentDal)
        {
            this.tournamentDal = tournamentDal;
        }

        // GET: Browse all tournaments 
        public ActionResult Browse()
        {
            List<Tournament> model = tournamentDal.getAllTournaments();
            return View("Browse", model);
        }

        public ActionResult Search(Tournament tournament)
        {
            if (tournament.SearchTerm != null)
            {
                var tournamentList = tournamentDal.GetTournamentByName(tournament.SearchTerm);

                return View("Browse", tournamentList);
            }
            return View("Search");
        }
        public ActionResult Detail()
        {
            int tournamentId = Convert.ToInt32(Request.Params["id"]);
            Tournament model = tournamentDal.getATournament(tournamentId);

            return View(model);
        }
        public ActionResult CreateTournament(Tournament model)
        {
            // If the user has not logged in yet, make them log in
            if (Session[SessionKeys.UsernameKey] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //if (ModelState.IsValid)
            //{
            //    return View("CreateTournamentForm", model);
            //}
            return View("CreateTournamentForm",model);
        }

        /*public ActionResult JoinTournament()
        {
            int userid = (int)Session["currentUser"];
            int tournamentId = Convert.ToInt32(Request.Params["tournamentId"]);
        }*/
    }
}