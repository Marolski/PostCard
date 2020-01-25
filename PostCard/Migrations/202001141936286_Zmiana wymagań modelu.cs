namespace PostCard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Zmianawymagańmodelu : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserDb", "Nick", c => c.String(nullable: false));
            AlterColumn("dbo.UserDb", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.UserDb", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserDb", "Password", c => c.String());
            AlterColumn("dbo.UserDb", "Email", c => c.String());
            AlterColumn("dbo.UserDb", "Nick", c => c.String());
        }
    }
}
