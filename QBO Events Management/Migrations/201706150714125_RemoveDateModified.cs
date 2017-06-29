namespace QBO_Events_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDateModified : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "DateModified");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "DateModified", c => c.DateTime(nullable: false));
        }
    }
}
