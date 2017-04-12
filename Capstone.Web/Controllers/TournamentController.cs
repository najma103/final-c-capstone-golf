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

        // GET: Tournament
        public ActionResult Detail(int tournamentId)
        {
            Tournament model = tournamentDal.getATournament(tournamentId);

            return View(model);
        }

        public ActionResult JoinTournament()
        {
            int userid = (int)Session["currentUser"];
            int tournamentId = Convert.ToInt32(Request.Params["tournamentId"]);
        }
    }
}