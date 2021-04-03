namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActivityToDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Month = c.String(),
                        day = c.Int(nullable: false),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        Hour = c.Int(nullable: false),
                        Minutes = c.String(nullable: false),
                        Shift = c.String(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            
        }
        
        public override void Down()
        {
            
            DropForeignKey("dbo.Activities", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Activities", new[] { "ApplicationUserId" });
            DropTable("dbo.Activities");
        }
    }
}
