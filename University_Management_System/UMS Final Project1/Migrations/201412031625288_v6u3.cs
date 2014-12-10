namespace UMS_Final_Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6u3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.TeacherAssignments", "aDepartment_Id", "dbo.Departments");
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.TeacherAssignments", new[] { "aDepartment_Id" });
            CreateIndex("dbo.Teachers", "DepartmentId");
            CreateIndex("dbo.TeacherAssignments", "DapartmentId");
            AddForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.TeacherAssignments", "DapartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            DropColumn("dbo.TeacherAssignments", "aDepartment_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TeacherAssignments", "aDepartment_Id", c => c.Int());
            DropForeignKey("dbo.TeacherAssignments", "DapartmentId", "dbo.Departments");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.TeacherAssignments", new[] { "DapartmentId" });
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            CreateIndex("dbo.TeacherAssignments", "aDepartment_Id");
            CreateIndex("dbo.Teachers", "DepartmentId");
            AddForeignKey("dbo.TeacherAssignments", "aDepartment_Id", "dbo.Departments", "Id");
            AddForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
    }
}
