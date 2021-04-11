namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDateInMetric : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Metrics", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Metrics", "Date");
        }
    }
}
