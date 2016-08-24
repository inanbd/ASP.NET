using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthenticationAndAuthorization.Models;
using System.Web.Security;

namespace AuthenticationAndAuthorization.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {

            using(EDBContext db = new EDBContext())
            {
                var count = db.Users.Where(x => x.Username == user.Username && x.Password == user.Password).Count();
                if (count == 1)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);//false for remembering
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Invalid User";
                }
            }
            
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        public ActionResult AccessDenied()
        {
            Response.StatusCode = 403;
            return View();
        }

    }

}

/*
           using(EDBContext db = new EDBContext())
           {
                   User user = new User()
                   {
                       Username = "admin",
                       Password="admin",
                       Role="admin"

                   };
                   User user2 = new User()
                   {
                       Username = "customer",
                       Password = "customer",
                       Role = "customer"
                   };
                   db.Users.Add(user);
                   db.Users.Add(user2);

                   Dept dept = new Dept()
                   {
                       DepartmentName="hr",
                       Username="admin"
                   };
                   db.Departments.Add(dept);
               db.SaveChanges();

           }*/
