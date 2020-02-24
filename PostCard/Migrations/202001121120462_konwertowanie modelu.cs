namespace PostCard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class konwertowaniemodelu : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.User", newName: "UserDb");
            AddColumn("dbo.UserDb", "Password", c => c.String());
            AlterColumn("dbo.UserDb", "Nick", c => c.String());
            AlterColumn("dbo.UserDb", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserDb", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.UserDb", "Nick", c => c.String(nullable: false));
            DropColumn("dbo.UserDb", "Password");
            RenameTable(name: "dbo.UserDb", newName: "User");
        }
    }
}
