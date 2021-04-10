namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoutine : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Routines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        BeginWeek = c.DateTime(nullable: false),
                        EndWeek = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Routines", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Routines", new[] { "ApplicationUserId" });
            DropTable("dbo.Routines");
        }
    }
}
