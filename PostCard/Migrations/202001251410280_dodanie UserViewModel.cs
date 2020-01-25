namespace PostCard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodanieUserViewModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserDb", newName: "User");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.User", newName: "UserDb");
        }
    }
}
