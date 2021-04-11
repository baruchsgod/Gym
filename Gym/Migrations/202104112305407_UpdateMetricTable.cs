namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMetricTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Metrics", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Metrics", "ApplicationUserId");
            AddForeignKey("dbo.Metrics", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Metrics", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Metrics", new[] { "ApplicationUserId" });
            DropColumn("dbo.Metrics", "ApplicationUserId");
        }
    }
}
