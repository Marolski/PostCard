namespace PostCard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodaniehaszuidaty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Hash", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Hash", c => c.String(nullable: false));
        }
    }
}
