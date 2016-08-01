using BDHelp.Models;
using FInal_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDHelp.Controllers
{
    
    public class ActionController : Controller
    {
        // GET: Action
        public ActionResult Index()
        {                       
            CommunityDbContext context = new CommunityDbContext();
            UserModel model = new UserModel();
            
            ViewBag.Categories = context.Categories.Take(10).ToList();
            ViewBag.User = context.UserModels.Take(5).OrderByDescending(id => id.UserRating).ToList(); ;
            return View(context.UserQuestions.Take(20).OrderByDescending(id => id.QuestionRating).ToList());            
        }
       
        public ActionResult Like(int id)
        {

            //Problem
            if (ModelState.IsValid)
            {
                CommunityDbContext context = new CommunityDbContext();
                //UserQuestion question = new UserQuestion();

                var question = context.UserQuestions.SingleOrDefault(item => item.QuestionId == id);
                int value = Convert.ToInt32(question.QuestionRating) + 1;
                question.QuestionRating = value;
                //context.Entry(question).State = EntityState.Modified;
                context.SaveChanges();
                //onclick="location.href='@Url.Action("Like","Action", new { id=item.QuestionId})'"> @Html.DisplayFor(model => item.QuestionRating)       
                return Redirect(Request.UrlReferrer.AbsolutePath);
            }
            return Redirect(Request.UrlReferrer.AbsolutePath);
        }
        public ActionResult UnLike(int id)
        {
            CommunityDbContext context = new CommunityDbContext();
            var question = context.UserQuestions.SingleOrDefault(item => item.QuestionId == id);
            int value = (Convert.ToInt32(question.Unlike)) + 1;
            question.Unlike = value;
            context.SaveChanges();
            return Redirect(Request.UrlReferrer.AbsolutePath);  
        }
        [HttpGet]
        [ActionName("btnAsk")]
        public ActionResult BtnAsk()
        {
            return Redirect("~/Action/AskQuestion");
        }

        [HttpGet]
        [ActionName("btnSearch")]
        public ActionResult BtnSearch()
        {
            return Redirect("~/Action/Search");
        }

        [HttpGet]
        [ActionName("btnAddCategory")]
        public ActionResult BtnAddCategory()
        {
            return Redirect("~/Action/AddCategory");
        }
        [HttpGet]
       
        public ActionResult AskQuestion()
        {
            CommunityDbContext context = new CommunityDbContext();
            ViewBag.Categories = context.Categories.ToList();
            //ViewBag.Categories=
            return View();

        }
        
        [HttpPost]
        public ActionResult AskQuestion(UserQuestion question)
        {
            question.CategoryId = Convert.ToInt32(Request["Category"]);
            CommunityDbContext context = new CommunityDbContext();
            question.QuestionDate = DateTime.Now;
           // question.Users = Identity.Name;
            context.UserQuestions.Add(question);
            context.SaveChanges();
            return Redirect("Index");

        }

        public ActionResult Search()
        {
            UserQuestion question = new UserQuestion();

            return View();
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        public ActionResult AddCategory(Category cat)
        {
            CommunityDbContext context = new CommunityDbContext();
            context.Categories.Add(cat);
            context.SaveChanges();
            return Redirect("Index");
        }
       public ActionResult ViewProfile(int id)
        {
            CommunityDbContext context = new CommunityDbContext();
            return View(context.UserModels.Where(i=>i.UserId==id).ToList());
        }
        public ActionResult UnansweredQuestion()
        {
            CommunityDbContext context = new CommunityDbContext();
            var answer = context.Answers.Select(i => i.QuestionId).Distinct().ToList();
            var question = from c in context.UserQuestions
                           where !(from a in context.Answers select a.QuestionNo).Contains(c.QuestionId)
                           select c;
            return View(question);
        }
       public ActionResult TopUnliked()
        {
            CommunityDbContext context = new CommunityDbContext();
            var question = context.UserQuestions.Take(20).OrderByDescending(i => i.Unlike);
            return View(question);
        }
        public ActionResult SatisfiedQuestion()
        {
            CommunityDbContext context = new CommunityDbContext();
            var question = context.UserQuestions.Take(50).OrderByDescending(i=>i.QuestionDate).Where(i=>i.IsSatisfied==1);
            return View(question);
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        

    }
}
