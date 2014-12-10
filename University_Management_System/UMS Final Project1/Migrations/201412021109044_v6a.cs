namespace UMS_Final_Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6a : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.TeacherAssignments", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.TeacherAssignments", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.TeacherAssignments", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropIndex("dbo.TeacherAssignments", new[] { "Teacher_Id" });
            DropIndex("dbo.TeacherAssignments", new[] { "Course_CourseId" });
            DropIndex("dbo.TeacherAssignments", new[] { "Department_Id" });
            RenameColumn(table: "dbo.TeacherAssignments", name: "Teacher_Id", newName: "TeacherId");
            AddColumn("dbo.TeacherAssignments", "dapartmentid", c => c.Int(nullable: false));
            AddColumn("dbo.TeacherAssignments", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.TeacherAssignments", "adepartment_Id", c => c.Int());
            AlterColumn("dbo.TeacherAssignments", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "DepartmentId");
            CreateIndex("dbo.TeacherAssignments", "TeacherId");
            CreateIndex("dbo.TeacherAssignments", "CourseId");
            CreateIndex("dbo.TeacherAssignments", "adepartment_Id");
            AddForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.TeacherAssignments", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TeacherAssignments", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
            AddForeignKey("dbo.TeacherAssignments", "adepartment_Id", "dbo.Departments", "Id");
            DropColumn("dbo.TeacherAssignments", "Department_Id");
            DropColumn("dbo.TeacherAssignments", "Course_CourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TeacherAssignments", "Course_CourseId", c => c.Int());
            AddColumn("dbo.TeacherAssignments", "Department_Id", c => c.Int());
            DropForeignKey("dbo.TeacherAssignments", "adepartment_Id", "dbo.Departments");
            DropForeignKey("dbo.TeacherAssignments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.TeacherAssignments", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.TeacherAssignments", new[] { "adepartment_Id" });
            DropIndex("dbo.TeacherAssignments", new[] { "CourseId" });
            DropIndex("dbo.TeacherAssignments", new[] { "TeacherId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            AlterColumn("dbo.TeacherAssignments", "TeacherId", c => c.Int());
            DropColumn("dbo.TeacherAssignments", "adepartment_Id");
            DropColumn("dbo.TeacherAssignments", "CourseId");
            DropColumn("dbo.TeacherAssignments", "dapartmentid");
            RenameColumn(table: "dbo.TeacherAssignments", name: "TeacherId", newName: "Teacher_Id");
            CreateIndex("dbo.TeacherAssignments", "Department_Id");
            CreateIndex("dbo.TeacherAssignments", "Course_CourseId");
            CreateIndex("dbo.TeacherAssignments", "Teacher_Id");
            CreateIndex("dbo.Courses", "DepartmentId");
            AddForeignKey("dbo.TeacherAssignments", "Department_Id", "dbo.Departments", "Id");
            AddForeignKey("dbo.TeacherAssignments", "Course_CourseId", "dbo.Courses", "CourseId");
            AddForeignKey("dbo.TeacherAssignments", "Teacher_Id", "dbo.Teachers", "Id");
            AddForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
    }
}
