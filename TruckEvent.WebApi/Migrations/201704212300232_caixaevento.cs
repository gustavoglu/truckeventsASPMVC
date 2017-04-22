namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class caixaevento : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.usuario", "Id_usuario_tipo", "dbo.usuario_tipo");
            DropIndex("dbo.usuario", new[] { "Id_usuario_tipo" });
            AddColumn("dbo.usuario", "CaixaEvento", c => c.Boolean());
            AddColumn("dbo.usuario", "id_usuario_organizador", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.usuario", "Usuario_Tipo_Id", c => c.Guid());
            CreateIndex("dbo.usuario", "id_usuario_organizador");
            CreateIndex("dbo.usuario", "Usuario_Tipo_Id");
            AddForeignKey("dbo.usuario", "id_usuario_organizador", "dbo.usuario", "id");
            AddForeignKey("dbo.usuario", "Usuario_Tipo_Id", "dbo.usuario_tipo", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.usuario", "Usuario_Tipo_Id", "dbo.usuario_tipo");
            DropForeignKey("dbo.usuario", "id_usuario_organizador", "dbo.usuario");
            DropIndex("dbo.usuario", new[] { "Usuario_Tipo_Id" });
            DropIndex("dbo.usuario", new[] { "id_usuario_organizador" });
            DropColumn("dbo.usuario", "Usuario_Tipo_Id");
            DropColumn("dbo.usuario", "id_usuario_organizador");
            DropColumn("dbo.usuario", "CaixaEvento");
            CreateIndex("dbo.usuario", "Id_usuario_tipo");
            AddForeignKey("dbo.usuario", "Id_usuario_tipo", "dbo.usuario_tipo", "Id");
        }
    }
}
