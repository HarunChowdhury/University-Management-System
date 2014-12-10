using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UMS_Final_Project1.Models
{
    public class StudentRegistration
    {
        //public StudentRegistration()
        //{
        //    Departments = new Collection<Department>();
        //}Default1

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }

        [DisplayName("Registration Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateTime { get; set; }
        public string Address { get; set; }

        [Display(Name = "Code")]
        public int DepartmentId { get; set; }
        public virtual Department Departments { get; set; }  //ICollection<Department> 
    
    }
}