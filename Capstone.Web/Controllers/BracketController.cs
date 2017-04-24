using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Capstone.Web.DAL;
using Capstone.Web.Models;
    

namespace Capstone.Web.Controllers
{
    public class BracketController : ApiController
    {
        public IHttpActionResult GetBrackets(int id)
        {
            string[] tempTeams = new string[2];
            int tournamentId = Convert.ToInt32(id);
            BracketSqlDal DAL = new BracketSqlDal();
            List<Bracket> bracketList = DAL.GetBracketByTourId(tournamentId);
            Team t = new Team();
            TeamsModel model = new TeamsModel();
            List<string[]> listTeams = t.GetMatches(bracketList);
            model.teams = listTeams;

            return Json(model);
        }

    }
}
