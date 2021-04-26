namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLongCreditCard : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "CardNumber", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "CardNumber", c => c.Int(nullable: false));
        }
    }
}
