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
    public class CourseEnrollController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: CourseEnroll
        public ActionResult Index()
        {
            var courseEnrolls = db.CourseEnrolls.Include(c => c.aCourse).Include(c => c.aStudentRegistration);
            return View(courseEnrolls.ToList());
        }

        // GET: CourseEnroll/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseEnroll courseEnroll = db.CourseEnrolls.Find(id);
            if (courseEnroll == null)
            {
                return HttpNotFound();
            }
            return View(courseEnroll);
        }

        // GET: CourseEnroll/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code");
            ViewBag.StudentRegistrationId = new SelectList(db.StudentRegistrations, "Id", "Id");
            return View();
        }

        // POST: CourseEnroll/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentRegistrationId,Name,Email,Department,CourseId,DateTime")] CourseEnroll courseEnroll)
        {
            if (ModelState.IsValid)
            {
                db.CourseEnrolls.Add(courseEnroll);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", courseEnroll.CourseId);
            ViewBag.StudentRegistrationId = new SelectList(db.StudentRegistrations, "Id", "Id", courseEnroll.StudentRegistrationId);
            return View(courseEnroll);
        }

        // GET: CourseEnroll/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseEnroll courseEnroll = db.CourseEnrolls.Find(id);
            if (courseEnroll == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", courseEnroll.CourseId);
            ViewBag.StudentRegistrationId = new SelectList(db.StudentRegistrations, "Id", "Id", courseEnroll.StudentRegistrationId);
            return View(courseEnroll);
        }

        // POST: CourseEnroll/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentRegistrationId,Name,Email,Department,CourseId,DateTime")] CourseEnroll courseEnroll)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseEnroll).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", courseEnroll.CourseId);
            ViewBag.StudentRegistrationId = new SelectList(db.StudentRegistrations, "Id", "Id", courseEnroll.StudentRegistrationId);
            return View(courseEnroll);
        }

        // GET: CourseEnroll/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseEnroll courseEnroll = db.CourseEnrolls.Find(id);
            if (courseEnroll == null)
            {
                return HttpNotFound();
            }
            return View(courseEnroll);
        }

        // POST: CourseEnroll/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseEnroll courseEnroll = db.CourseEnrolls.Find(id);
            db.CourseEnrolls.Remove(courseEnroll);
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


        public JsonResult GetDropDownListSelectedData(int? id)
        {

            var aa = (from T in db.StudentRegistrations
                      where T.Id == id
                      select T).ToList();


            //string name;
            //string email;
            //int dept;



            foreach (var ele in aa)
            {

                name = ele.Name;
                email = ele.Email;
                dept = ele.Departments.DepartmentCode;
            }

            Vvalue aV = new Vvalue();

            aV.t1 = name;
            aV.t2 = email;
            aV.t3 = dept;

            return Json(aV, JsonRequestBehavior.AllowGet);
        }
        public string name;
        public string email;
        public string dept;
        public class Vvalue
        {
            public string t1 { set; get; }
            public string t2 { set; get; }
            public string t3 { set; get; }
        }
    }
}
