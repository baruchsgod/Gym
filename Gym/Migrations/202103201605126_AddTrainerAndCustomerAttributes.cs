namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrainerAndCustomerAttributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "cedula", c => c.String(nullable: false, maxLength: 9));
            AddColumn("dbo.AspNetUsers", "fName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "lName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.AspNetUsers", "Telefono", c => c.String(nullable: false, maxLength: 12));
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "BeginDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "BeginDate");
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropColumn("dbo.AspNetUsers", "Telefono");
            DropColumn("dbo.AspNetUsers", "lName");
            DropColumn("dbo.AspNetUsers", "fName");
            DropColumn("dbo.AspNetUsers", "cedula");
        }
    }
}
