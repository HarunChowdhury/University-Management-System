using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS_Final_Project1.Models
{
    public class RoomAllocation
    {
        public int Id { get; set; }
        public int  DepartmentId { get; set; }
        public int CourseId { get; set; }
        public string  RoomNo { get; set; }
        public string DayOfWeek { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Course> Courses { get; set; }  
     
    }
}