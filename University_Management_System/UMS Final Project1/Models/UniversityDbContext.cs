using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;



namespace UMS_Final_Project1.Models.DAL
{
    public class UniversityDbContext:DbContext
    {
        public DbSet<Department> Department { set; get; }
        public DbSet<Semester> Semesters { set; get; }
        public DbSet<Course> Courses { set; get; }

        public DbSet<Teacher> Teachers { set; get; }
        public DbSet<Designation> Designations { set; get; }


        public DbSet<TeacherAssignment> TeacherAssignments { set; get; }
       public DbSet<StudentRegistration> StudentRegistrations { get; set; }
        public DbSet<CourseEnroll> CourseEnrolls { get; set; }
        public DbSet<GradeLetter> GradeLetters { get; set; }
        public DbSet<ResultEntry> ResultEntries { get; set; }
        public DbSet<ViewResult> ViewResults { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().
                HasRequired(d => d.aDepartment).
                WithMany(w => w.Courses).
                WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>().
                HasRequired(d => d.aDepartment).
                WithMany(w => w.Teachers)
                .WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }

        
    }
}