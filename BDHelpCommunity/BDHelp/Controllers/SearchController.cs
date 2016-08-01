using BDHelp.Models;
using FInal_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDHelp.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        public  PartialViewResult MatchAny(string message)
        {
            CommunityDbContext context = new CommunityDbContext();
            List<UserQuestion> model = context.UserQuestions
                .Where(s => s.QuestionHeader.Contains(message))
                .Select(s => s).ToList();
            return PartialView("_Search", model);
        }
    }
}