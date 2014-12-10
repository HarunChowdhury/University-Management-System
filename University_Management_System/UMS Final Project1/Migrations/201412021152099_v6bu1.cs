namespace UMS_Final_Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6bu1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TeacherAssignments", "DapartmentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TeacherAssignments", "DapartmentId", c => c.Int(nullable: false));
        }
    }
}
