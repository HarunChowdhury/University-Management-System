using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace UMS_Final_Project1.Models
{
    public class ResultEntry
    {
        public int Id { get; set; }
        [Display(Name = "Registration N0")]
        public int StudentRegistrationId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }

        [Display(Name = "Selected Course")]
        public int  CourseId { get; set; }

          [Display(Name = "Selected Grade Letter")]
        public int GradeLetterId { get; set; }


        public virtual StudentRegistration aStudentRegistration { get; set; }
        public virtual Course aCourse { get; set; }
        //public virtual  Department aDepartment{ get; set; } 
        public virtual GradeLetter  aGradeLetter{ get; set; } 
     
    
    }
}