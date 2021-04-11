namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDateRoutine : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Routines", "BeginWeek", c => c.DateTime());
            AlterColumn("dbo.Routines", "EndWeek", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Routines", "EndWeek", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Routines", "BeginWeek", c => c.DateTime(nullable: false));
        }
    }
}
