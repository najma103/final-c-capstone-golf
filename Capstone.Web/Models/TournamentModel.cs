using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class TournamentModel
    {
        [Required(ErrorMessage = "*")]
        public string GameType { get; set; }
        [Required(ErrorMessage = "*")]
        public string MaxPlayers { get; set; }

        [Required(ErrorMessage = "*")]
        public string GameStartDate { get; set; }
    }
}