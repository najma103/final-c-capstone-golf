using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }

        public List<User> UserList { get; set; }

        public string TournamentName { get; set; }

        public int OrganizerId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CompetitorLimit { get; set; }
    }
}