using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FInal_Project.Models;
using BDHelp.Security;
using BDHelp.Models;

namespace BDHelp.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Action");
            }
            //ViewBag.ReturnUrl = returnUrl;
            //ViewBag.CompanyTitle
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserModel model, string returnUrl = "")
        {
            //if (ModelState.IsValid)
            //{
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.RedirectFromLoginPage(model.UserName, model.RememberMe);
                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                var identity = System.Web.HttpContext.Current.User.ToCustomPrincipal().CustomIdentity;
                //var identity=System.Web.HttpContext.Current.
                //var identity = System.Web.HttpContext.Current.User.Identity;
                    
                   if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        identity = System.Web.HttpContext.Current.User.ToCustomPrincipal().CustomIdentity;
                        //if (identity.Name == "Admin")
                        //{
                            RedirectToAction("Index", "Action");
                        //}
                       //else
                      //  {
                           // RedirectToAction("Index", "Home");
                       //}

                    }
                }

                ModelState.AddModelError("", "Incorrect username and/or password");
            //}
            return View(model);
            //return RedirectToAction("Index","Home");

        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }
       public ActionResult Manage()
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(UserModel user)
        {
            CommunityDbContext context = new CommunityDbContext();
            user.RememberMe = false;
            user.UserRating = 0;
            user.UserType = "user";
            context.UserModels.Add(user);
            context.SaveChanges();
           

            return RedirectToAction("Index","Action");
        }


    }

}