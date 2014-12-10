namespace UMS_Final_Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1111 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ViewResults", "aCourse_CourseId", "dbo.Courses");
            DropForeignKey("dbo.ViewResults", "aDepartment_Id", "dbo.Departments");
            DropForeignKey("dbo.ViewResults", "aGradeLetter_Id", "dbo.GradeLetters");
            DropForeignKey("dbo.ViewResults", "StudentRegistrationId", "dbo.StudentRegistrations");
            DropIndex("dbo.ViewResults", new[] { "aCourse_CourseId" });
            DropIndex("dbo.ViewResults", new[] { "aDepartment_Id" });
            DropIndex("dbo.ViewResults", new[] { "aGradeLetter_Id" });
            DropIndex("dbo.ViewResults", new[] { "StudentRegistrationId" });
            DropTable("dbo.ViewResults");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ViewResults", "StudentRegistrationId");
            CreateIndex("dbo.ViewResults", "aGradeLetter_Id");
            CreateIndex("dbo.ViewResults", "aDepartment_Id");
            CreateIndex("dbo.ViewResults", "aCourse_CourseId");
            AddForeignKey("dbo.ViewResults", "StudentRegistrationId", "dbo.StudentRegistrations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ViewResults", "aGradeLetter_Id", "dbo.GradeLetters", "Id");
            AddForeignKey("dbo.ViewResults", "aDepartment_Id", "dbo.Departments", "Id");
            AddForeignKey("dbo.ViewResults", "aCourse_CourseId", "dbo.Courses", "CourseId");
        }
    }
}
