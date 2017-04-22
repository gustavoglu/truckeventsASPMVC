namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testeEventoForeignKeyUsuario : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.evento", "Id_usuario_organizador", "dbo.usuario");
            DropIndex("dbo.evento", new[] { "Id_usuario_organizador" });
            AddColumn("dbo.evento", "Usuario_Organizador_Id", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.evento", "Id_usuario_organizador", c => c.String(maxLength: 250, unicode: false));
            CreateIndex("dbo.evento", "Usuario_Organizador_Id");
            AddForeignKey("dbo.evento", "Usuario_Organizador_Id", "dbo.usuario", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.evento", "Usuario_Organizador_Id", "dbo.usuario");
            DropIndex("dbo.evento", new[] { "Usuario_Organizador_Id" });
            AlterColumn("dbo.evento", "Id_usuario_organizador", c => c.String(nullable: false, maxLength: 250, unicode: false));
            DropColumn("dbo.evento", "Usuario_Organizador_Id");
            CreateIndex("dbo.evento", "Id_usuario_organizador");
            AddForeignKey("dbo.evento", "Id_usuario_organizador", "dbo.usuario", "id");
        }
    }
}
