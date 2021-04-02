namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixBackPayments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "PaymentType", c => c.Boolean());
            DropColumn("dbo.Payments", "CreditCard");
            DropColumn("dbo.Payments", "DebitCard");
            DropColumn("dbo.Payments", "PayPal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "PayPal", c => c.Boolean());
            AddColumn("dbo.Payments", "DebitCard", c => c.Boolean());
            AddColumn("dbo.Payments", "CreditCard", c => c.Boolean());
            DropColumn("dbo.Payments", "PaymentType");
        }
    }
}
