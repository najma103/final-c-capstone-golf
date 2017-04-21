using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using System.Net.Mail;
using System.Net;

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
        public ActionResult Detail(string id)
        {
            int tournamentId = Convert.ToInt32(id);
            Tournament model = tournamentDal.getATournament(tournamentId);
            


            return View("Detail", model);
        }
        public ActionResult CreateTournament(Tournament model)
        {
            // If the user has not logged in yet, make them log in
            if (Session[SessionKeys.UsernameKey] == null)
            {
                return RedirectToAction("Login", "User");
            }

            if (!ModelState.IsValid)
            {
                return View("CreateTournamentForm", model);
            }

            int organizerId = Convert.ToInt32(Session[SessionKeys.UserId]);
            model.OrganizerId = organizerId;
            model.StartDate = Convert.ToDateTime(model.StartDate);
            model.EndDate = Convert.ToDateTime(model.EndDate);
            model.GameStatus = "Open";
            var newModel = tournamentDal.addNewTournament(model);
          
            if (newModel)
            {
                return RedirectToAction("Browse", "Tournament");
            }
            else
            {
                return View("CreateTournamentForm", model);
            }
        }

        public ActionResult Brackets(string id)
        {
            MatchSqlDal dal = new MatchSqlDal();
            int tournamentId = Convert.ToInt32(2);
            var listOfMatches = dal.getTournamentMatches(tournamentId);

            return View("Brackets",listOfMatches);
        }

        [HttpGet]
        public ActionResult Invite()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Invite(InviteViewModel invite)
        {
            string fullBody = invite.MessageBody + "\n\n http://localhost:55601/Tournament/Register/?id=" + invite.TournamentId;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("tournamentinvitenoreply", "manydegreesofentropy"),
                EnableSsl = true
            };

            client.Send("tournamentinvitenoreply@gmail.com", invite.EmailAddress, invite.MessageHead, fullBody);

            return View();
        }
        //public ActionResult Join()
        //{

        //    int userid = (int)Session["currentUser"];
        //    int tournamentId = Convert.ToInt32(Request.Params["tournamentId"]);
        //}
    }
}