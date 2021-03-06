﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.Models
{
    public class Match
    {
        public List<User> MatchList { get; set; }
        public int MatchId { get; set; }
        public int CompetitorId { get; set; }
        public string competitorName { get; set; } // display name 
        public int TournamentId { get; set; }
        public int Tier { get; set; }
        public int Position { get; set; }
    }

}