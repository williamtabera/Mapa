namespace Location.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioTabla : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Login", "Nombres", c => c.String(maxLength: 50));
            AlterColumn("dbo.Login", "Apellidos", c => c.String(maxLength: 50));
            AlterColumn("dbo.Login", "Celular", c => c.String(maxLength: 10));
            AlterColumn("dbo.Login", "Estrato", c => c.String(maxLength: 1));
            AlterColumn("dbo.Login", "Correo", c => c.String());
            AlterColumn("dbo.Login", "Contraseña", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Login", "Contraseña", c => c.String(nullable: false));
            AlterColumn("dbo.Login", "Correo", c => c.String(nullable: false));
            AlterColumn("dbo.Login", "Estrato", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.Login", "Celular", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Login", "Apellidos", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Login", "Nombres", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
