using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UMS_Final_Project1.Models
{
    public class Course
    {
        
        public int CourseId { set; get; }


        //[Remote("IsCourseCodeExists", "Course", ErrorMessage = "Course Code Conflict!!.")]
        public string Code { set; get; }
        public double Credit { set; get; }

       // [Remote("IsThereSameDptName", "Department", ErrorMessage = "Department Name Exists!!")]
        public string Name { set; get; }
        public string Description { set; get; }

        //FK
        public int DepartmentId { set; get; }
        //1toM rel
        public virtual Department aDepartment { set; get; }

        //FK
        public int SemesterId { set; get; }
        //1 to M
        public virtual Semester Semesters { set; get; }
        public virtual ICollection<TeacherAssignment> TeacherAssignments { set; get; } 
        
    }
}