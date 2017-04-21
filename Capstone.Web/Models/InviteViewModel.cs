using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Web.Models
{
    public class InviteViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string EmailAddress { get; set; }

        public string MessageHead { get
            {
                return "You've been invited!";
            }
        }

        public string MessageBody { get; set; }
        public int TournamentId { get; set; }
    }
}