namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormatDescriptionToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activities", "Description", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Activities", "Description", c => c.String());
        }
    }
}
