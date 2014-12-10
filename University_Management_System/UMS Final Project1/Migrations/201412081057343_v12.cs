namespace UMS_Final_Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ViewResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentRegistrationId = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Department = c.String(),
                        aCourse_CourseId = c.Int(),
                        aDepartment_Id = c.Int(),
                        aGradeLetter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.aCourse_CourseId)
                .ForeignKey("dbo.Departments", t => t.aDepartment_Id)
                .ForeignKey("dbo.GradeLetters", t => t.aGradeLetter_Id)
                .ForeignKey("dbo.StudentRegistrations", t => t.StudentRegistrationId, cascadeDelete: true)
                .Index(t => t.aCourse_CourseId)
                .Index(t => t.aDepartment_Id)
                .Index(t => t.aGradeLetter_Id)
                .Index(t => t.StudentRegistrationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ViewResults", "StudentRegistrationId", "dbo.StudentRegistrations");
            DropForeignKey("dbo.ViewResults", "aGradeLetter_Id", "dbo.GradeLetters");
            DropForeignKey("dbo.ViewResults", "aDepartment_Id", "dbo.Departments");
            DropForeignKey("dbo.ViewResults", "aCourse_CourseId", "dbo.Courses");
            DropIndex("dbo.ViewResults", new[] { "StudentRegistrationId" });
            DropIndex("dbo.ViewResults", new[] { "aGradeLetter_Id" });
            DropIndex("dbo.ViewResults", new[] { "aDepartment_Id" });
            DropIndex("dbo.ViewResults", new[] { "aCourse_CourseId" });
            DropTable("dbo.ViewResults");
        }
    }
}
