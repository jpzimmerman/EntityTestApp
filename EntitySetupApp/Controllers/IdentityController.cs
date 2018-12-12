using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EntitySetupApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;


namespace EntitySetupApp.Controllers
{
    public class IdentityController : Controller
    {
        // GET: Identity
        public ActionResult Login()
        {


            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel loginModel) {

            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
                var authManager = HttpContext.GetOwinContext().Authentication;

                var user = userManager.Find(loginModel.UserName, loginModel.Password);
                if (user != null)
                {
                    var ident = userManager.CreateIdentity(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    //use the instance that has been created. 
                    authManager.SignIn(
                        new AuthenticationProperties { IsPersistent = false }, ident);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpGet, AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        public async Task<ActionResult> Register(LoginModel loginModel)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            AppUser user = new AppUser();
            user.UserName = loginModel.UserName;
            user.Birthday = new DateTime(1986, 4, 2);
            var result = await userManager.CreateAsync(user, loginModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Contact", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return View();
            }
        }
    }
}