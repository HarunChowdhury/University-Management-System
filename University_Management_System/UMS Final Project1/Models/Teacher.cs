using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS_Final_Project1.Models
{
    public class Teacher
    {

        public int Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string ContactNo { set; get; }



        public int DesignationId { set; get; }
        public virtual Designation aDesignation { set; get; }


        public int DepartmentId { set; get; }
        public virtual Department aDepartment { set; get; }
        public double CreditToBTaken { set; get; }


        public virtual ICollection<TeacherAssignment> TeacherAssignemts { set; get; }

    }
}