using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Web.Models
{
    public class NewTournamentViewModel
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        public string TournamentName { get; set; }

        public int OrganizerId { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Tournament End date is required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int CompetitorLimit { get; set; }
    }
}