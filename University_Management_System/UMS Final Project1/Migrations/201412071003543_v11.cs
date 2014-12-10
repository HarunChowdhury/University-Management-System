namespace UMS_Final_Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResultEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentRegistrationId = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Department = c.String(),
                        CourseId = c.Int(nullable: false),
                        GradeLetterId = c.Int(nullable: false),
                        aDepartment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.aDepartment_Id)
                .ForeignKey("dbo.GradeLetters", t => t.GradeLetterId, cascadeDelete: true)
                .ForeignKey("dbo.StudentRegistrations", t => t.StudentRegistrationId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.aDepartment_Id)
                .Index(t => t.GradeLetterId)
                .Index(t => t.StudentRegistrationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResultEntries", "StudentRegistrationId", "dbo.StudentRegistrations");
            DropForeignKey("dbo.ResultEntries", "GradeLetterId", "dbo.GradeLetters");
            DropForeignKey("dbo.ResultEntries", "aDepartment_Id", "dbo.Departments");
            DropForeignKey("dbo.ResultEntries", "CourseId", "dbo.Courses");
            DropIndex("dbo.ResultEntries", new[] { "StudentRegistrationId" });
            DropIndex("dbo.ResultEntries", new[] { "GradeLetterId" });
            DropIndex("dbo.ResultEntries", new[] { "aDepartment_Id" });
            DropIndex("dbo.ResultEntries", new[] { "CourseId" });
            DropTable("dbo.ResultEntries");
        }
    }
}
