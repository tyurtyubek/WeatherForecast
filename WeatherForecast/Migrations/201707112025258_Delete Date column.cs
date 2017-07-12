namespace WeatherForecast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDatecolumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cities", "DateOfCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cities", "DateOfCreated", c => c.DateTime(nullable: false));
        }
    }
}
