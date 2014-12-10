namespace UMS_Final_Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseEnrolls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentRegistrationId = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Department = c.String(),
                        CourseId = c.Int(nullable: false),
                        DateTime = c.DateTime(),
                        aDepartment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.aDepartment_Id)
                .ForeignKey("dbo.StudentRegistrations", t => t.StudentRegistrationId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.aDepartment_Id)
                .Index(t => t.StudentRegistrationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseEnrolls", "StudentRegistrationId", "dbo.StudentRegistrations");
            DropForeignKey("dbo.CourseEnrolls", "aDepartment_Id", "dbo.Departments");
            DropForeignKey("dbo.CourseEnrolls", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseEnrolls", new[] { "StudentRegistrationId" });
            DropIndex("dbo.CourseEnrolls", new[] { "aDepartment_Id" });
            DropIndex("dbo.CourseEnrolls", new[] { "CourseId" });
            DropTable("dbo.CourseEnrolls");
        }
    }
}
