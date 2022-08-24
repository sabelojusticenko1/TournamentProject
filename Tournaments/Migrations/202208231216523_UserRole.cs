namespace Tournaments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.EventID);
            
            DropTable("dbo.User");
        }
    }
}
