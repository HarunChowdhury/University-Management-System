namespace UMS_Final_Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentRegistrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        ContactNumber = c.String(),
                        DateTime = c.DateTime(),
                        Address = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentRegistrations", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.StudentRegistrations", new[] { "DepartmentId" });
            DropTable("dbo.StudentRegistrations");
        }
    }
}
