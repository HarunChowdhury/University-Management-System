using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace UMS_Final_Project1.Models
{
    public class Department
    {
        public int Id {set ; get;}

        [Display(Name="Code")]
        [Remote("IsThereSameDptCode" ,"Department" , ErrorMessage="Department Code Conflict!!")]

        public string DepartmentCode{set;  get;}
        [Display(Name = "Name")]
        [Remote("IsThereSameDptName" ,"Department" ,ErrorMessage="Department Name Exists!!")]
        public string DepartmentName { set; get; }


        public virtual ICollection<Semester> Semesters { set; get; }
        public virtual ICollection<Course> Courses { set; get; }

        public virtual ICollection<Teacher> Teachers { set; get; }

        public virtual ICollection<TeacherAssignment> TeacherAssignemtns { set; get; }

        public virtual ICollection<StudentRegistration> StudentRegistrations { get; set; }

        //public virtual ICollection<CourseEnroll>  EnrollmentCourses{ get; set; } 

    }
}