using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMS_Final_Project1.Models
{
    public class Designation
    {
        public int Id { set; get; }
        public string DesignationVal { set; get; }


        public virtual ICollection<Teacher> Teachers { set; get; }
    }
}
