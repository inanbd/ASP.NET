using BDHelp.Models;
using FInal_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDHelp.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        int id=0;
        public ActionResult ViewQuestion(int  id)
        {
            this.id = id;
            CommunityDbContext context = new CommunityDbContext();
            ViewBag.Answers = context.Answers.ToList();
            UserQuestion question = context.UserQuestions.SingleOrDefault(d=>d.QuestionId==id);
            return View(question);
        }
        [HttpGet]
        public ActionResult Answer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Answer(Answer ans,int id)
        {
            CommunityDbContext context = new CommunityDbContext();
            ans.AnswerDate = DateTime.Now;
            //Question iD
            //User Id  
            ans.QuestionNo = id;      
            context.Answers.Add(ans);
            context.SaveChanges();
            return RedirectToAction("Index","Action");
        }
        public ActionResult Satisfy(int ? value)
        {
            CommunityDbContext context = new CommunityDbContext();
            var question = (from u in context.UserQuestions where u.QuestionId == value select u).FirstOrDefault();
            //Problem
            question.IsSatisfied = 1;
            context.SaveChanges();
            //return RedirectToAction("ViewQuestion", id);
            return RedirectToAction("ViewQuestion",value);
        }
    }
}