namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionAndImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCarts", "Description", c => c.String());
            AddColumn("dbo.ShoppingCarts", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShoppingCarts", "Image");
            DropColumn("dbo.ShoppingCarts", "Description");
        }
    }
}
