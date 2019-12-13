namespace PostCard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confirmPassword : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Nick", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Password", c => c.String());
            AlterColumn("dbo.User", "Email", c => c.String());
            AlterColumn("dbo.User", "Nick", c => c.String());
        }
    }
}
