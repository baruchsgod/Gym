namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataBaseForActivity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activities", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Activities", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Activities", "Month", c => c.String(nullable: false));
            AlterColumn("dbo.Activities", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Activities", "ApplicationUserId");
            AddForeignKey("dbo.Activities", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Activities", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Activities", "ApplicationUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Activities", "Month", c => c.String());
            CreateIndex("dbo.Activities", "ApplicationUserId");
            AddForeignKey("dbo.Activities", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
