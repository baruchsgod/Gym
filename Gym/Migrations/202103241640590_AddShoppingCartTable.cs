namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShoppingCartTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cedula = c.String(nullable: false, maxLength: 9),
                        ApplicationUserId = c.String(maxLength: 128),
                        SupplementId = c.Byte(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Supplement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Supplements", t => t.Supplement_Id)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.Supplement_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "Supplement_Id", "dbo.Supplements");
            DropForeignKey("dbo.ShoppingCarts", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.ShoppingCarts", new[] { "Supplement_Id" });
            DropIndex("dbo.ShoppingCarts", new[] { "ApplicationUserId" });
            DropTable("dbo.ShoppingCarts");
        }
    }
}
