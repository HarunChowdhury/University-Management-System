namespace UMS_Final_Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeacherAssignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreditToBeTaken = c.Double(nullable: false),
                        RemainingCredit = c.Double(nullable: false),
                        Name = c.String(),
                        Credit = c.String(),
                        Department_Id = c.Int(),
                        Teacher_Id = c.Int(),
                        Course_CourseId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId)
                .Index(t => t.Department_Id)
                .Index(t => t.Teacher_Id)
                .Index(t => t.Course_CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherAssignments", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.TeacherAssignments", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.TeacherAssignments", "Department_Id", "dbo.Departments");
            DropIndex("dbo.TeacherAssignments", new[] { "Course_CourseId" });
            DropIndex("dbo.TeacherAssignments", new[] { "Teacher_Id" });
            DropIndex("dbo.TeacherAssignments", new[] { "Department_Id" });
            DropTable("dbo.TeacherAssignments");
        }
    }
}
