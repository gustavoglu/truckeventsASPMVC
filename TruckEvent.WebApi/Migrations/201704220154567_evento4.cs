namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class evento4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.evento", new[] { "Id_usuario_organizador" });
            AlterColumn("dbo.evento", "Id_usuario_organizador", c => c.String(maxLength: 250, unicode: false));
            CreateIndex("dbo.evento", "Id_usuario_organizador");
        }
        
        public override void Down()
        {
            DropIndex("dbo.evento", new[] { "Id_usuario_organizador" });
            AlterColumn("dbo.evento", "Id_usuario_organizador", c => c.String(nullable: false, maxLength: 250, unicode: false));
            CreateIndex("dbo.evento", "Id_usuario_organizador");
        }
    }
}
