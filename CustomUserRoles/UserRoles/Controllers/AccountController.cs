using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRoles.ViewModels;
using UserRoles.Models;
using UserRoles.Security;

namespace UserRoles.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountViewModel account)
        {
            AccountModel am = new AccountModel();

            if (string.IsNullOrEmpty(account.username)|| string.IsNullOrEmpty(account.password)
                ||am.login(account.username,account.password)==null)
            {
                ViewBag.Error = "Account's invalid";
                return View("Index");
            }
            SessionPersister.Username = account.username;
            return View("Success");
        }
    }
}