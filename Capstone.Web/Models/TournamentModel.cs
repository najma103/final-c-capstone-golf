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
        [Display(Name = "Game Type", Prompt = "Checkers, Chess, etc.")]
        public string GameType { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Max # of Players")]
        public string MaxPlayers { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Start Date")]
        public DateTime GameStartDate { get; set; }
    }
}