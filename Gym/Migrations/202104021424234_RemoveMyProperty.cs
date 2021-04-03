namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMyProperty : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.Purchases DROP COLUMN MyProperty");
        }
        
        public override void Down()
        {
        }
    }
}
