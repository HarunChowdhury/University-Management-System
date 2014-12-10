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

namespace UMS_Final_Project1.Controllers
{
    public class TeacherAssignmentController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: /TeacherAssignment/
        public ActionResult Index()
        {
            var teacherassignments = db.TeacherAssignments.Include(t => t.aCourse).Include(t => t.aTeacher).Include(t => t.Department);
            return View(teacherassignments.ToList());
        }

        // GET: /TeacherAssignment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherAssignment teacherassignment = db.TeacherAssignments.Find(id);
            if (teacherassignment == null)
            {
                return HttpNotFound();
            }
            return View(teacherassignment);
        }

        // GET: /TeacherAssignment/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code");
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name");
            ViewBag.DapartmentId = new SelectList(db.Department,"Id", "DepartmentName");
            return View();
        }

        // POST: /TeacherAssignment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,CreditToBeTaken,RemainingCredit,TeacherId,DapartmentId,CourseId,Name,Credit")] 
          TeacherAssignment teacherassignment)
        {
            if (ModelState.IsValid)
            {
                db.TeacherAssignments.Add(teacherassignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", teacherassignment.CourseId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", teacherassignment.TeacherId);
            ViewBag.DapartmentId = new SelectList(db.Department, "Id", "DepartmentName", teacherassignment.DapartmentId);
            

            return View(teacherassignment);
        }

        // GET: /TeacherAssignment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherAssignment teacherassignment = db.TeacherAssignments.Find(id);
            if (teacherassignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", teacherassignment.CourseId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", teacherassignment.TeacherId);
            ViewBag.DapartmentId = new SelectList(db.Department, "Id", "DepartmentName", teacherassignment.DapartmentId);
            return View(teacherassignment);
        }

        // POST: /TeacherAssignment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,CreditToBeTaken,RemainingCredit,TeacherId,DapartmentId,CourseId,Name,Credit")] TeacherAssignment teacherassignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherassignment).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", teacherassignment.CourseId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", teacherassignment.TeacherId);
            ViewBag.DapartmentId = new SelectList(db.Department, "Id", "DepartmentName", teacherassignment.DapartmentId);
            return View(teacherassignment);
        }

        // GET: /TeacherAssignment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherAssignment teacherassignment = db.TeacherAssignments.Find(id);
            if (teacherassignment == null)
            {
                return HttpNotFound();
            }
            return View(teacherassignment);
        }

        // POST: /TeacherAssignment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherAssignment teacherassignment = db.TeacherAssignments.Find(id);
            db.TeacherAssignments.Remove(teacherassignment);
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




        public ActionResult ViewCourseStatus(int? departmentId)
        {
            ViewBag.DepartmentId1 = new SelectList(db.Department, "Id", "DepartmentName");


            //     return View(db.TeacherAssignments.Include(s => s.Department).Where(s=> s.Department.Id == departmentId));

            if (departmentId != null)
            {


                return View(db.TeacherAssignments.Include(s => s.Department).Where(s => s.Department.Id == departmentId));
            }
            else
            {
                return View(db.TeacherAssignments.Include(s => s.Department));
            }
        }





        public PartialViewResult FilteredViewCourseStatus(int? departmentId)
        {

            if (departmentId != null)
            {

                var model = db.TeacherAssignments.Include(s => s.Department).Where(s => s.Department.Id == departmentId);
                return PartialView("~/Views/TeacherAssignPartial/_FilterCourseStatus.cshtml", model);
        


            }
            else
            {
                var model = db.TeacherAssignments.Include(s => s.Department);
                return PartialView("~/Views/TeacherAssignPartial/_FilterCourseStatus.cshtml", model);
        
            }
        
        }

       




        public JsonResult GetDropDownListSelectedData(string id)
        {



            var aa = from T in db.Teachers
                     where T.Name.Equals(id)
                     select T.CreditToBTaken;

            //aTeacher.CreditToBTaken = Convert.ToDouble(aa);
            var bb = from T2 in db.TeacherAssignments
                     where T2.aTeacher.Name.Equals(id)
                     select T2.Credit;

            double valaa = 0;
            foreach (var ele in aa)
            {
                valaa += Convert.ToDouble(ele);
            }

            double valbb = 0;
            foreach (var ele in bb)
            {
                valbb += Convert.ToDouble(ele);
            }

            Vvalue aVvalue = new Vvalue();


            double val = valaa - valbb;
            //double val = Convert.ToDouble(aa.ElementAt(0)) - Convert.ToDouble(bb.ElementAt(0));

            aVvalue.t1 = val;
            aVvalue.t2 = valaa;

            return Json(aVvalue, JsonRequestBehavior.AllowGet);
        }


        public string name1;
        public double credit1;

        //custom code
        public JsonResult GetDropDownListSelectedData2(string id)
        {

            var aa = (from T in db.Teachers
                      where T.aDepartment.DepartmentName.Equals(id)
                      select T.Name);






            return Json(aa, JsonRequestBehavior.AllowGet);
        }

        //custom code
        public JsonResult GetDropDownListSelectedData4(string id)
        {
            
            var aa = (from T in db.TeacherAssignments
                      where (T.aTeacher.Name == id)
                      select  T.aCourse.Code).Distinct().ToArray();


            var tt = (from T in db.Courses select T.Code).ToArray();


            List<string> ttkk = new List<string>();

            string[] arr1 = new string[]{""}; 
            
            if (aa.Length == 0)
            {
                aa = arr1;
            }

           // foreach (var kk in tt)

            for (int i = 0; i < tt.Length; i++)
            {
                ttkk.Add(tt[i]);
            }

            for (int i = 0; i < tt.Length; i ++ )
            {
                //foreach (var kk2 in aa)

                for (int j = 0; j < aa.Length; j++ )
                {
                    if (tt[i] == aa[j])
                    {
                        ttkk.Remove(tt[i]);
                        break;
                    }
                }

            }



            




            //var cc= (from T1 in db.TeacherAssignments 
            //        join T2 in db.Courses
            //            on T1.aCourse.CourseId equals T2.CourseId
            //            where (T1.aCourse.Code != T2.Code)
            //            select T2.Code).Distinct();

            //var dd = from T2 in db.Courses
            //         join T1 in db.TeacherAssignments
            //             on T2.CourseId equals T1.aCourse.CourseId
            //          into T3
            //         from T4 in T3.DefaultIfEmpty()
                     
            //         select new {
            //            T2.Code
            //         };

            //var vv = dd.ToList();

            return Json(ttkk, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDropDownListSelectedData3(string id)
        {

            var aa = from T in db.Courses
                     where T.Code.Equals(id)
                     select new { T.Credit, T.Name };





            foreach (var ele in aa)
            {
                name1 = ele.Name;
                credit1 = ele.Credit;
            }

            Vvalue aV = new Vvalue();

            aV.t1 = credit1;
            aV.t3 = name1;

            return Json(aV, JsonRequestBehavior.AllowGet);
        }


    }
    public class Vvalue
    {
        public double t1 { set; get; }
        public double t2 { set; get; }
        public string t3 { set; get; }
    }

}
