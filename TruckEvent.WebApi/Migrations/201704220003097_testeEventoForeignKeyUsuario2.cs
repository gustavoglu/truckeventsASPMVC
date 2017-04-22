namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testeEventoForeignKeyUsuario2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.evento", new[] { "Usuario_Organizador_Id" });
            DropColumn("dbo.evento", "Id_usuario_organizador");
            RenameColumn(table: "dbo.evento", name: "Usuario_Organizador_Id", newName: "Id_usuario_organizador");
            AlterColumn("dbo.evento", "Id_usuario_organizador", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.evento", "Id_usuario_organizador", c => c.String(nullable: false, maxLength: 250, unicode: false));
            CreateIndex("dbo.evento", "Id_usuario_organizador");
        }
        
        public override void Down()
        {
            DropIndex("dbo.evento", new[] { "Id_usuario_organizador" });
            AlterColumn("dbo.evento", "Id_usuario_organizador", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.evento", "Id_usuario_organizador", c => c.String(maxLength: 250, unicode: false));
            RenameColumn(table: "dbo.evento", name: "Id_usuario_organizador", newName: "Usuario_Organizador_Id");
            AddColumn("dbo.evento", "Id_usuario_organizador", c => c.String(maxLength: 250, unicode: false));
            CreateIndex("dbo.evento", "Usuario_Organizador_Id");
        }
    }
}
