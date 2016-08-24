using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AuthenticationAndAuthorization.Models;
using AuthenticationAndAuthorization.Security;

namespace AuthenticationAndAuthorization.Controllers
{
    [Authorize(Roles ="admin,customer")]
    public class DeptsController : Controller
    {
        private EDBContext db = new EDBContext();

        // GET: Depts
       
        [Authorize(Roles ="admin,customer")]
        public ActionResult Index()
        {
            return View(db.Departments.Take(50).ToList());
        }

        
        // GET: Depts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dept dept = db.Departments.Find(id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }


        [CustomAuthorize(Roles ="admin")]
        // GET: Depts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Depts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentId,DepartmentName,Username")] Dept dept)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(dept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dept);
        }

        
        // GET: Depts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dept dept = db.Departments.Find(id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }

        // POST: Depts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentId,DepartmentName,Username")] Dept dept)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dept).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dept);
        }

        
        // GET: Depts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dept dept = db.Departments.Find(id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }

       
        // POST: Depts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dept dept = db.Departments.Find(id);
            db.Departments.Remove(dept);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
