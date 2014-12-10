using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UMS_Final_Project1.Models
{
    public class GradeLetter
    {
        public int Id { get; set; }

        [Display(Name = "Grade")]
        public string GradeName { get; set; }
    }
}