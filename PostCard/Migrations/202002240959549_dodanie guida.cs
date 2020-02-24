namespace PostCard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodanieguida : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Guide", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Guide");
        }
    }
}
