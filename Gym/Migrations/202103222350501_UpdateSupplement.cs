namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSupplement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Supplements", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Supplements", "Description", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Supplements", "Description", c => c.String());
            DropColumn("dbo.Supplements", "Image");
        }
    }
}
