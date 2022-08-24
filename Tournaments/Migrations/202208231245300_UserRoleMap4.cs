namespace Tournaments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRoleMap4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRoleMappings", "FK_RoleID_UserRoleID", c => c.Int());
            AddColumn("dbo.UserRoles", "FK_RoleID_UserRoleID", c => c.Int());
            CreateIndex("dbo.UserRoleMappings", "UserID");
            CreateIndex("dbo.UserRoleMappings", "FK_RoleID_UserRoleID");
            CreateIndex("dbo.UserRoles", "UserID");
            CreateIndex("dbo.UserRoles", "FK_RoleID_UserRoleID");
            AddForeignKey("dbo.UserRoles", "FK_RoleID_UserRoleID", "dbo.UserRoles", "UserRoleID");
            AddForeignKey("dbo.UserRoles", "UserID", "dbo.User", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.UserRoleMappings", "FK_RoleID_UserRoleID", "dbo.UserRoles", "UserRoleID");
            AddForeignKey("dbo.UserRoleMappings", "UserID", "dbo.User", "UserID", cascadeDelete: true);
            DropColumn("dbo.UserRoleMappings", "FK_UserID");
            DropColumn("dbo.UserRoleMappings", "FK_RoleID");
            DropColumn("dbo.UserRoles", "FK_UserID");
            DropColumn("dbo.UserRoles", "FK_RoleID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserRoles", "FK_RoleID", c => c.Int(nullable: false));
            AddColumn("dbo.UserRoles", "FK_UserID", c => c.Int(nullable: false));
            AddColumn("dbo.UserRoleMappings", "FK_RoleID", c => c.Int(nullable: false));
            AddColumn("dbo.UserRoleMappings", "FK_UserID", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserRoleMappings", "UserID", "dbo.User");
            DropForeignKey("dbo.UserRoleMappings", "FK_RoleID_UserRoleID", "dbo.UserRoles");
            DropForeignKey("dbo.UserRoles", "UserID", "dbo.User");
            DropForeignKey("dbo.UserRoles", "FK_RoleID_UserRoleID", "dbo.UserRoles");
            DropIndex("dbo.UserRoles", new[] { "FK_RoleID_UserRoleID" });
            DropIndex("dbo.UserRoles", new[] { "UserID" });
            DropIndex("dbo.UserRoleMappings", new[] { "FK_RoleID_UserRoleID" });
            DropIndex("dbo.UserRoleMappings", new[] { "UserID" });
            DropColumn("dbo.UserRoles", "FK_RoleID_UserRoleID");
            DropColumn("dbo.UserRoleMappings", "FK_RoleID_UserRoleID");
        }
    }
}
