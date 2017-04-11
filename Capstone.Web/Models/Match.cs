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
        public int PlayerA { get; set; }
        public int PlayerB { get; set; }
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }

    }
}