﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Capstone.Web.Crypto;

namespace Capstone.Web.Controllers
{
    public class UsersController : HomeController
    {
        private readonly IUserDAL userDal;

        private readonly ITournamentDAL tour;
        
        public UsersController(IUserDAL userDal, ITournamentDAL tour)
            : base(userDal, tour)
        {
            this.userDal = userDal;
            this.tour = tour;
        }

        [HttpGet]
        [Route("users/register")]
        public ActionResult RegisterNewUser()
        {
            if (base.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { username = base.CurrentUser });
            }
            else
            {
                var model = new NewUserViewModel();
                return View("Register", model);
            }
        }

        [HttpPost]
        [Route("users/register")]
        public ActionResult RegisterNewUser(NewUserViewModel model)
        {
           
            if (base.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { username = base.CurrentUser });
            }

            if (ModelState.IsValid)
            {
                var currentUser = userDal.GetUser(model.DisplayName);

                if (currentUser != null)
                {
                    return View("Register", model);
                }
                HashProvider hashProvider = new HashProvider();
                string hashedPassword = hashProvider.HashPassword(model.Password); //<-- password they provided during registration
                string salt = hashProvider.SaltValue;


                var newUser = new User
                {
                    Email = Request.Params["EmailAddress"],
                    Password = Request.Params["Password"],
                    Role = Request.Params["accounttype"],
                    DisplayName = Request.Params["DisplayName"]

                    //Salt = salt
                };

                
                // Add the user to the database
                userDal.CreateUser(newUser);

                // Log the user in and redirect to the dashboard
                base.LogUserIn(model.EmailAddress, model.SelectedAccountType, model.DisplayName, newUser.UserId);
                return RedirectToAction("Index", "Home", new { email = model.EmailAddress });
            }
            return View("Register", model);
        }
        
        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginViewModel();
            return View("Login", model);
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var user = userDal.GetUser(model.Email);

            base.LogUserIn(user.Email, user.Role, user.DisplayName, user.UserId);

            model.Email = Request.Params["Email"];

            if (base.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", null);
            }
            
            return View("Login", model);

        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));

            return RedirectToAction("Index","Home",null);
        }
    }
}