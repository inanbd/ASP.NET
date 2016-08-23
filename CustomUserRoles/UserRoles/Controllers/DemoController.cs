using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRoles.Security;

namespace UserRoles.Controllers
{
    public class DemoController : Controller
    {
       
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();

        }
        [CustomAuthorize(Roles ="admin")]
        public ActionResult Admin()
        {
            return View();

        }
        [CustomAuthorize(Roles = "employee")]
        public ActionResult Employee()
        {
            return View();
        }




    }
}