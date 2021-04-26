namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePayment : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM dbo.Payments WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
