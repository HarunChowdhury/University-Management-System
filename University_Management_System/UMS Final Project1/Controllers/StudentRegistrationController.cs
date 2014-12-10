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
    public class StudentRegistrationController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: StudentRegistration
        public ActionResult Index()
        {
            var studentRegistrations = db.StudentRegistrations.Include(s => s.Departments);
            return View(studentRegistrations.ToList());
        }

        // GET: StudentRegistration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentRegistration studentRegistration = db.StudentRegistrations.Find(id);
            if (studentRegistration == null)
            {
                return HttpNotFound();
            }
            return View(studentRegistration);
        }

        // GET: StudentRegistration/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Department, "Id", "DepartmentCode");
            return View();
        }

        // POST: StudentRegistration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,ContactNumber,DateTime,Address,DepartmentId")] StudentRegistration studentRegistration)
        {
            if (ModelState.IsValid)
            {
                db.StudentRegistrations.Add(studentRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Department, "Id", "DepartmentCode", studentRegistration.DepartmentId);
            return View(studentRegistration);
        }

        // GET: StudentRegistration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentRegistration studentRegistration = db.StudentRegistrations.Find(id);
            if (studentRegistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "Id", "DepartmentCode", studentRegistration.DepartmentId);
            return View(studentRegistration);
        }

        // POST: StudentRegistration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,ContactNumber,DateTime,Address,DepartmentId")] StudentRegistration studentRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "Id", "DepartmentCode", studentRegistration.DepartmentId);
            return View(studentRegistration);
        }

        // GET: StudentRegistration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentRegistration studentRegistration = db.StudentRegistrations.Find(id);
            if (studentRegistration == null)
            {
                return HttpNotFound();
            }
            return View(studentRegistration);
        }

        // POST: StudentRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentRegistration studentRegistration = db.StudentRegistrations.Find(id);
            db.StudentRegistrations.Remove(studentRegistration);
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
