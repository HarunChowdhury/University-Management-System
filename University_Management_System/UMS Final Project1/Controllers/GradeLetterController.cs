using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UMS_Final_Project1.Models;
using UMS_Final_Project1.Models.DAL;
using EntityState = System.Data.Entity.EntityState;

namespace UMS_Final_Project1.Controllers
{
    public class GradeLetterController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: GradeLetter
        public ActionResult Index()
        {
            return View(db.GradeLetters.ToList());
        }

        // GET: GradeLetter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradeLetter gradeLetter = db.GradeLetters.Find(id);
            if (gradeLetter == null)
            {
                return HttpNotFound();
            }
            return View(gradeLetter);
        }

        // GET: GradeLetter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GradeLetter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GradeName")] GradeLetter gradeLetter)
        {
            if (ModelState.IsValid)
            {
                db.GradeLetters.Add(gradeLetter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gradeLetter);
        }

        // GET: GradeLetter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradeLetter gradeLetter = db.GradeLetters.Find(id);
            if (gradeLetter == null)
            {
                return HttpNotFound();
            }
            return View(gradeLetter);
        }

        // POST: GradeLetter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GradeName")] GradeLetter gradeLetter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gradeLetter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gradeLetter);
        }

        // GET: GradeLetter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradeLetter gradeLetter = db.GradeLetters.Find(id);
            if (gradeLetter == null)
            {
                return HttpNotFound();
            }
            return View(gradeLetter);
        }

        // POST: GradeLetter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GradeLetter gradeLetter = db.GradeLetters.Find(id);
            db.GradeLetters.Remove(gradeLetter);
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
