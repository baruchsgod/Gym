namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePayments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "CreditCard", c => c.Boolean());
            AddColumn("dbo.Payments", "DebitCard", c => c.Boolean());
            AddColumn("dbo.Payments", "PayPal", c => c.Boolean());
            DropColumn("dbo.Payments", "PaymentType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "PaymentType", c => c.String(nullable: false));
            DropColumn("dbo.Payments", "PayPal");
            DropColumn("dbo.Payments", "DebitCard");
            DropColumn("dbo.Payments", "CreditCard");
        }
    }
}
