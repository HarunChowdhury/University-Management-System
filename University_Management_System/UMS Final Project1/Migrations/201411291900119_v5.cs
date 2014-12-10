namespace UMS_Final_Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "aDepartment_Id", "dbo.Departments");
            DropForeignKey("dbo.Teachers", "aDesignation_Id", "dbo.Designations");
            DropIndex("dbo.Teachers", new[] { "aDepartment_Id" });
            DropIndex("dbo.Teachers", new[] { "aDesignation_Id" });
            RenameColumn(table: "dbo.Teachers", name: "aDepartment_Id", newName: "DepartmentId");
            RenameColumn(table: "dbo.Teachers", name: "aDesignation_Id", newName: "DesignationId");
            AlterColumn("dbo.Teachers", "DepartmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Teachers", "DesignationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "DepartmentId");
            CreateIndex("dbo.Teachers", "DesignationId");
            AddForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Teachers", new[] { "DesignationId" });
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            AlterColumn("dbo.Teachers", "DesignationId", c => c.Int());
            AlterColumn("dbo.Teachers", "DepartmentId", c => c.Int());
            RenameColumn(table: "dbo.Teachers", name: "DesignationId", newName: "aDesignation_Id");
            RenameColumn(table: "dbo.Teachers", name: "DepartmentId", newName: "aDepartment_Id");
            CreateIndex("dbo.Teachers", "aDesignation_Id");
            CreateIndex("dbo.Teachers", "aDepartment_Id");
            AddForeignKey("dbo.Teachers", "aDesignation_Id", "dbo.Designations", "Id");
            AddForeignKey("dbo.Teachers", "aDepartment_Id", "dbo.Departments", "Id");
        }
    }
}
