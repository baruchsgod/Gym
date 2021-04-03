namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReserveAndMonthNum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "Reserve", c => c.Int());
            AddColumn("dbo.Activities", "MonthNum", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "MonthNum");
            DropColumn("dbo.Activities", "Reserve");
        }
    }
}
