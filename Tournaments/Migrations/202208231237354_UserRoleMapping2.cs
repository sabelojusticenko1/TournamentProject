namespace Tournaments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRoleMapping2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoleMappings",
                c => new
                    {
                        UserRoleMappingID = c.String(nullable: false, maxLength: 128),
                        UserID = c.Int(nullable: false),
                        FK_UserID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                        FK_RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserRoleMappingID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        FK_UserID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                        FK_RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserRoleID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserRoleMappings");
        }
    }
}
