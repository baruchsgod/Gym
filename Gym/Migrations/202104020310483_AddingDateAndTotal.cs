namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDateAndTotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "DatePurchase", c => c.DateTime(nullable: false));
            AddColumn("dbo.Payments", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "Total");
            DropColumn("dbo.Payments", "DatePurchase");
        }
    }
}
