namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateToNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activities", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Activities", "Date", c => c.DateTime(nullable: false));
        }
    }
}
