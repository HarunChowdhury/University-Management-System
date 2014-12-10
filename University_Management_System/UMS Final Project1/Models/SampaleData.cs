using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using UMS_Final_Project1.Models.DAL;
using UMS_Final_Project1.Models;


namespace UMS_Final_Project1
{
    public class SampaleData:DropCreateDatabaseIfModelChanges<UniversityDbContext>
    {
        protected override void Seed(UniversityDbContext context)
        {
            //context.Department.Add(new Department() { DepartmentName="Bangla",DepartmentCode="101A" });
            //context.Department.Add(new Department() { DepartmentName = "English", DepartmentCode = "101B" });


            //context.SaveChanges();

            //context.Courses.Add(new Course() { Code="101",Credit=4.0,Description="Hard Course",Name="Lit"});
            //context.SaveChanges();

            



            //base.Seed(context);
        }
    }
}
