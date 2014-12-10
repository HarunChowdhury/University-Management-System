using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace UMS_Final_Project1.Models
{
    public class CourseEnroll
    {
        public int  Id { get; set; }

       [Display(Name = "Registraion No")]
        public int StudentRegistrationId { get; set; } 
        public string  Name { get; set; }
        public string  Email { get; set; }
        public string  Department { get; set; }

        [Display(Name = "Selected Course")]
        public int CourseId { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime?  DateTime { get; set; } 

        public virtual StudentRegistration aStudentRegistration{ get; set; }  
        public virtual Course aCourse{ get; set; }
        public virtual Department aDepartment{ get; set; } 

    }
}