using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Bracket
    {
        public int bracketId { get; set; }
        public string playerName { get; set; }
        public int Score { get; set; }
        public string playerEmail { get; set; }
        public int tournamentId { get; set; }
        public int seedNumber { get; set; }
        public int gameNumber { get; set; }

        
    }
}