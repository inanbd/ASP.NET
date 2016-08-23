using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRoles.Security;

namespace UserRoles.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public void Index()
        {
            SessionPersister.Username = string.Empty;
            Response.Redirect("/Account/Index");
        }
    }
}