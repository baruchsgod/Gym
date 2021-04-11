namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRoutineTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Routines", "WarmUp", c => c.String(nullable: false));
            AddColumn("dbo.Routines", "CoreBody", c => c.String(nullable: false));
            AddColumn("dbo.Routines", "UpperBody", c => c.String(nullable: false));
            AddColumn("dbo.Routines", "LowerBody", c => c.String(nullable: false));
            AddColumn("dbo.Routines", "CoolDown", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Routines", "CoolDown");
            DropColumn("dbo.Routines", "LowerBody");
            DropColumn("dbo.Routines", "UpperBody");
            DropColumn("dbo.Routines", "CoreBody");
            DropColumn("dbo.Routines", "WarmUp");
        }
    }
}
