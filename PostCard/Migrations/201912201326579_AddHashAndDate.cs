namespace PostCard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHashAndDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.User", "Hash", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Hash");
            DropColumn("dbo.User", "Date");
        }
    }
}
