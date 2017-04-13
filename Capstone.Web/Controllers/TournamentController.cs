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

        // GET: Tournament
        public ActionResult Detail(int tournamentId)
        {
            return View();
        }
    }
}