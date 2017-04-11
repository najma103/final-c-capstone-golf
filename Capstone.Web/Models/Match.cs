using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.Models
{
    public class Match
    {
        public List<User> Participants { get; set; }

        public int tournamentID { get; set; }
    }
}