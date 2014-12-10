namespace UMS_Final_Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6b : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeacherAssignments", "adepartment_Id", "dbo.Departments");
            DropIndex("dbo.TeacherAssignments", new[] { "adepartment_Id" });
            AlterColumn("dbo.TeacherAssignments", "dapartmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.TeacherAssignments", "aDepartment_Id", c => c.Int());
            CreateIndex("dbo.TeacherAssignments", "aDepartment_Id");
            AddForeignKey("dbo.TeacherAssignments", "aDepartment_Id", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherAssignments", "aDepartment_Id", "dbo.Departments");
            DropIndex("dbo.TeacherAssignments", new[] { "aDepartment_Id" });
            AlterColumn("dbo.TeacherAssignments", "aDepartment_Id", c => c.Int());
            AlterColumn("dbo.TeacherAssignments", "dapartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.TeacherAssignments", "adepartment_Id");
            AddForeignKey("dbo.TeacherAssignments", "adepartment_Id", "dbo.Departments", "Id");
        }
    }
}
