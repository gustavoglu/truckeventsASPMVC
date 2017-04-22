namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeyUsuarioPrincipal : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.usuario", "Id_Usuario_Principal");
            AddForeignKey("dbo.usuario", "Id_Usuario_Principal", "dbo.usuario", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.usuario", "Id_Usuario_Principal", "dbo.usuario");
            DropIndex("dbo.usuario", new[] { "Id_Usuario_Principal" });
        }
    }
}
