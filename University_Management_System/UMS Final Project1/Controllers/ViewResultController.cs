using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using RazorPDF;
using UMS_Final_Project1.Models;
using UMS_Final_Project1.Models.DAL;
using EntityState = System.Data.Entity.EntityState;
using ViewResult = UMS_Final_Project1.Models.ViewResult;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser; 

namespace UMS_Final_Project1.Controllers
{
    public class ViewResultController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();
       public string courseCode;
       public string courseName;
       public string gradeName; 
        // GET: ViewResult
        public ActionResult Index(int?stdId)
        {
            var report = (from courseInfo in db.ResultEntries
                          where courseInfo.StudentRegistrationId == stdId
                          select courseInfo).ToList();

            foreach (var stdCourseInfo in report)
            {

                courseCode = stdCourseInfo.aCourse.Code;
                courseName = stdCourseInfo.aCourse.Name;
                gradeName = stdCourseInfo.aGradeLetter.GradeName;
            }
            Vvalue aV = new Vvalue();

            aV.t1 = courseCode;
            aV.t2 = courseName;
            aV.t3 = gradeName;

         
            FileStream fs = new FileStream("Chapter1_Example1.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new PdfPTable(3));   
            doc.Close();

            //var report = (from courseInfo in db.ResultEntries
            //              where courseInfo.StudentRegistrationId == stdId
            //              select courseInfo).ToList();       

            return new RazorPDF.PdfResult(aV, "Index");
            //var viewResults = db.ViewResults.Include(v => v.aSruStudentRegistration);
           // return View(viewResults.ToList());
        }

        // GET: ViewResult/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewResult viewResult = db.ViewResults.Find(id);
            if (viewResult == null)
            {
                return HttpNotFound();
            }
            return View(viewResult);
        }

        // GET: ViewResult/Create
        public ActionResult Create()
        {
            ViewBag.StudentRegistrationId = new SelectList(db.StudentRegistrations, "Id", "Id");
            return View();
        }

        // POST: ViewResult/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentRegistrationId,Name,Email,Department")] ViewResult viewResult)
        {
            if (ModelState.IsValid)
            {
                db.ViewResults.Add(viewResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentRegistrationId = new SelectList(db.StudentRegistrations, "Id", "Id", viewResult.StudentRegistrationId);
            return View(viewResult);
        }

        // GET: ViewResult/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewResult viewResult = db.ViewResults.Find(id);
            if (viewResult == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentRegistrationId = new SelectList(db.StudentRegistrations, "Id", "Id", viewResult.StudentRegistrationId);
            return View(viewResult);
        }

        // POST: ViewResult/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentRegistrationId,Name,Email,Department")] ViewResult viewResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentRegistrationId = new SelectList(db.StudentRegistrations, "Id", "Id", viewResult.StudentRegistrationId);
            return View(viewResult);
        }

        // GET: ViewResult/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewResult viewResult = db.ViewResults.Find(id);
            if (viewResult == null)
            {
                return HttpNotFound();
            }
            return View(viewResult);
        }

        // POST: ViewResult/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewResult viewResult = db.ViewResults.Find(id);
            db.ViewResults.Remove(viewResult);
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

   

        //public ActionResult Report(int? stdId)   //DepartmentId1
        //{
        //    var report = (from courseInfo in db.ResultEntries 
        //        where courseInfo.StudentRegistrationId == stdId
        //        select courseInfo).ToList();

        //    foreach (var stdCourseInfo in report)
        //    {
        //        courseCode = stdCourseInfo.aCourse.Code;
        //        courseName = stdCourseInfo.aCourse.Name;
        //        gradeName = stdCourseInfo.aGradeLetter.GradeName;
        //    }


        //    Vvalue aV = new Vvalue();

        //    aV.t1 = courseCode;
        //    aV.t2 = courseName;
        //    aV.t3 = gradeName;

      
        //    return new RazorPDF.PdfResult(aV, "Report");
          


        //}

  
    }
}
