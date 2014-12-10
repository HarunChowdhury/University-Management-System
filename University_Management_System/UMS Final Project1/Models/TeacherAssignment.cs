using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace UMS_Final_Project1.Models
{
    public class TeacherAssignment
    {

        public int Id { set; get; }


        public double CreditToBeTaken { set; get; }
        public double RemainingCredit { set; get; }





        public int TeacherId { set; get; }
        public virtual Teacher aTeacher { set; get; }


        [ForeignKey("Department")]
        public int DapartmentId { set; get; }
       public virtual Department Department { set; get; }



        public int CourseId { set; get; }
        public virtual Course aCourse { set; get; }


        public string Name { set; get; }
        public string Credit { set; get; }
    }
}
