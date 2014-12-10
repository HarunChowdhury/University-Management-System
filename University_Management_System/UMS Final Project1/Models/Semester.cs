using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMS_Final_Project1.Models
{
    public class Semester
    {
        public int id { set; get; }
        public string Name { set; get; }


        //rel M to 1
        public virtual ICollection<Course> Courses { set; get; }



    }
}
