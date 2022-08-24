namespace Tournaments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateHollywood : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventID = c.Long(nullable: false, identity: true),
                        TournamentID = c.Long(nullable: false),
                        EventName = c.String(nullable: false, maxLength: 100, unicode: false),
                        EventNumber = c.Short(),
                        EventDateTime = c.DateTime(),
                        EventEndDateTime = c.DateTime(),
                        AutoClose = c.Boolean(),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Tournament", t => t.TournamentID, cascadeDelete: true)
                .Index(t => t.TournamentID);
            
            CreateTable(
                "dbo.EventDetail",
                c => new
                    {
                        EventDetailID = c.Long(nullable: false, identity: true),
                        EventID = c.Long(nullable: false),
                        EventDetailStatusID = c.Short(nullable: false),
                        EventDetailName = c.String(nullable: false, maxLength: 50, unicode: false),
                        EventDetailNumber = c.Short(),
                        EventDetailOdd = c.Decimal(precision: 18, scale: 7),
                        FinishingPosition = c.Short(),
                        FirstTimer = c.Boolean(),
                    })
                .PrimaryKey(t => t.EventDetailID)
                .ForeignKey("dbo.EventDetailStatus", t => t.EventDetailStatusID, cascadeDelete: true)
                .ForeignKey("dbo.Event", t => t.EventID, cascadeDelete: true)
                .Index(t => t.EventID)
                .Index(t => t.EventDetailStatusID);
            
            CreateTable(
                "dbo.EventDetailStatus",
                c => new
                    {
                        EventDetailStatusID = c.Short(nullable: false, identity: true),
                        EventDetailStatusName = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.EventDetailStatusID);
            
            CreateTable(
                "dbo.Tournament",
                c => new
                    {
                        TournamentID = c.Long(nullable: false, identity: true),
                        TournamentName = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.TournamentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "TournamentID", "dbo.Tournament");
            DropForeignKey("dbo.EventDetail", "EventID", "dbo.Event");
            DropForeignKey("dbo.EventDetail", "EventDetailStatusID", "dbo.EventDetailStatus");
            DropIndex("dbo.EventDetail", new[] { "EventDetailStatusID" });
            DropIndex("dbo.EventDetail", new[] { "EventID" });
            DropIndex("dbo.Event", new[] { "TournamentID" });
            DropTable("dbo.Tournament");
            DropTable("dbo.EventDetailStatus");
            DropTable("dbo.EventDetail");
            DropTable("dbo.Event");
        }
    }
}
