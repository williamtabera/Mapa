namespace Location.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreaciontblLocalizacion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Localizacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocalDateTime = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        Altitude = c.String(),
                        AltitudeAccuracy = c.String(),
                        Accuracy = c.String(),
                        Heading = c.String(),
                        Speed = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Localizacion");
        }
    }
}
