namespace PostCard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confirmPass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "Hash");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Hash", c => c.String());
        }
    }
}
