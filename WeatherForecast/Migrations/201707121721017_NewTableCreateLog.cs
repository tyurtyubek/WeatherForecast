namespace WeatherForecast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTableCreateLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CityLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false),
                        RequestTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }        
        public override void Down()
        {
            CreateTable(
                "dbo.HistoryUserRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestedSity = c.String(),
                        LastRequestTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.CityLog");
        }
    }
}
