using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace UMS_Final_Project1.Models
{
    public class ViewResult
    {
        public int Id { get; set; }
        public int StudentRegistrationId { get; set; }

        public string Name { get; set; }
        public string  Email { get; set; }
        public string Department { get; set; }
      
        //public Button MakePdf { get; set; }

        //public string  CourseCode { get; set; }
        //public string CourseName { get; set; }
        //public char  Grade { get; set; }

        public virtual StudentRegistration aSruStudentRegistration { get; set; }
        public virtual Department aDepartment { get; set; } 
        public virtual Course aCourse { get; set; }
        public virtual GradeLetter aGradeLetter { get; set; } 

    }
}