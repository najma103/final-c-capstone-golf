using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class UsersController : HomeController
    {
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
                /*var currentUser = userDAL.GetUser(model.Username);

                if (currentUser != null)
                {
                    return View("Register", model);
                }*/
            }
            return View("Register", model);
        }
    }
}