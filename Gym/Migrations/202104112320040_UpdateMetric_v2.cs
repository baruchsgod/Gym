namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMetric_v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Metrics", "Month", c => c.String(nullable: false));
            AddColumn("dbo.Metrics", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Metrics", "Year");
            DropColumn("dbo.Metrics", "Month");
        }
    }
}
