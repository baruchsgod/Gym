namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaymentsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameCard = c.String(nullable: false),
                        CardNumber = c.Int(nullable: false),
                        PaymentType = c.String(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        Cvv = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(),
                        Province = c.String(nullable: false),
                        Zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Payments");
        }
    }
}
