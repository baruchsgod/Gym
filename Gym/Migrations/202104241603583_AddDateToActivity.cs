namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToActivity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "Date");
        }
    }
}
