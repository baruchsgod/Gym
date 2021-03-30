namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCedulaForName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCarts", "Name", c => c.String(nullable: false));
            DropColumn("dbo.ShoppingCarts", "Cedula");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShoppingCarts", "Cedula", c => c.String(nullable: false, maxLength: 9));
            DropColumn("dbo.ShoppingCarts", "Name");
        }
    }
}
