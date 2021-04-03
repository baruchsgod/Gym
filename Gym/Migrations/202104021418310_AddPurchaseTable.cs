namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPurchaseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        MyProperty = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        SupplementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Supplements", t => t.SupplementId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.SupplementId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "SupplementId", "dbo.Supplements");
            DropForeignKey("dbo.Purchases", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Purchases", new[] { "SupplementId" });
            DropIndex("dbo.Purchases", new[] { "ApplicationUserId" });
            DropTable("dbo.Purchases");
        }
    }
}
