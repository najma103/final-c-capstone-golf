using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Web.Models
{
    public class NewUserViewModel
    {
        [Required(ErrorMessage = "A username is required")]
        [Display(Name = "User Name:")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords do not match")]
        [Display(Name = "Confirm Password:")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Email Address:")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string EmailAddress { get; set; }
    }
}