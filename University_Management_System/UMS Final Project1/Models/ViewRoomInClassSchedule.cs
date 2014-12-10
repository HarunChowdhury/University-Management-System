using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS_Final_Project1.Models
{
    public class ViewRoomInClassSchedule
    {
        public int Id { get; set; }

        public int  DepartmentId { get; set; }
        public string CourseCode { get; set; }
        public string  Name { get; set; }
        public string ScheduleInformation { get; set; }



    }
}