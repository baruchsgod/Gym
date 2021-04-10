namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReserveTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reserves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ActivityId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reserves", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reserves", "ActivityId", "dbo.Activities");
            DropIndex("dbo.Reserves", new[] { "ApplicationUserId" });
            DropIndex("dbo.Reserves", new[] { "ActivityId" });
            DropTable("dbo.Reserves");
        }
    }
}
