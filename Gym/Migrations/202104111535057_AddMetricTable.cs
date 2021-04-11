namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMetricTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Metrics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MassIndex = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Chest = c.Double(nullable: false),
                        Waist = c.Double(nullable: false),
                        RightBicep = c.Double(nullable: false),
                        LeftBicep = c.Double(nullable: false),
                        RightCalf = c.Double(nullable: false),
                        LeftCalf = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Metrics");
        }
    }
}
