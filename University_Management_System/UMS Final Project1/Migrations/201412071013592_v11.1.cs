namespace UMS_Final_Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v111 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ResultEntries", "aDepartment_Id", "dbo.Departments");
            DropIndex("dbo.ResultEntries", new[] { "aDepartment_Id" });
            DropColumn("dbo.ResultEntries", "aDepartment_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ResultEntries", "aDepartment_Id", c => c.Int());
            CreateIndex("dbo.ResultEntries", "aDepartment_Id");
            AddForeignKey("dbo.ResultEntries", "aDepartment_Id", "dbo.Departments", "Id");
        }
    }
}
