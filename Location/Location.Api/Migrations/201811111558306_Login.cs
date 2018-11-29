namespace Location.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Login : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 50),
                        Apellidos = c.String(nullable: false, maxLength: 50),
                        Direccion = c.String(maxLength: 20),
                        Celular = c.String(nullable: false, maxLength: 10),
                        Estrato = c.String(nullable: false, maxLength: 1),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Correo = c.String(nullable: false),
                        Contraseña = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Login");
        }
    }
}
