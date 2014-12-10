namespace UMS_Final_Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        ContactNo = c.String(),
                        CreditToBTaken = c.Double(nullable: false),
                        aDepartment_Id = c.Int(),
                        aDesignation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.aDepartment_Id)
                .ForeignKey("dbo.Designations", t => t.aDesignation_Id)
                .Index(t => t.aDepartment_Id)
                .Index(t => t.aDesignation_Id);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignationVal = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "aDesignation_Id", "dbo.Designations");
            DropForeignKey("dbo.Teachers", "aDepartment_Id", "dbo.Departments");
            DropIndex("dbo.Teachers", new[] { "aDesignation_Id" });
            DropIndex("dbo.Teachers", new[] { "aDepartment_Id" });
            DropTable("dbo.Designations");
            DropTable("dbo.Teachers");
        }
    }
}
