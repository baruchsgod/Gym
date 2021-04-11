namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToRoutine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Routines", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Routines", "Date");
        }
    }
}
