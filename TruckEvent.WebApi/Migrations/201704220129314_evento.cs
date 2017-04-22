namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class evento : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.evento", "Id_usuario_organizador", c => c.String(nullable: false, maxLength: 250, unicode: false));
            CreateIndex("dbo.evento", "Id_usuario_organizador");
            AddForeignKey("dbo.evento", "Id_usuario_organizador", "dbo.usuario", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.evento", "Id_usuario_organizador", "dbo.usuario");
            DropIndex("dbo.evento", new[] { "Id_usuario_organizador" });
            AlterColumn("dbo.evento", "Id_usuario_organizador", c => c.String(maxLength: 250, unicode: false));
        }
    }
}
