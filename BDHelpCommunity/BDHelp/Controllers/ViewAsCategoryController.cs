using BDHelp.Models;
using FInal_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDHelp.Controllers
{
    public class ViewAsCategoryController : Controller
    {
        // GET: ViewAsCategory
        public ActionResult view(int id)
        {
            CommunityDbContext context = new CommunityDbContext();
            Category category = new Category();
            ViewBag.CategoryName = context.Categories.Where(a => a.CategoryId == id).ToList();
            //= c_name;
            return View(context.UserQuestions.Where(i=>i.CategoryId== id));
        }
    }
}