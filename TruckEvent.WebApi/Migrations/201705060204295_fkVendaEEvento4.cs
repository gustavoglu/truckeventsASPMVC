namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkVendaEEvento4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.venda", new[] { "Id_evento" });
            //RenameColumn(table: "dbo.venda", name: "Id_evento", newName: "Evento_Id");
            //AlterColumn("dbo.venda", "Evento_Id", c => c.Guid());
            //CreateIndex("dbo.venda", "Evento_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.venda", new[] { "Evento_Id" });
            AlterColumn("dbo.venda", "Evento_Id", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.venda", name: "Evento_Id", newName: "Id_evento");
            CreateIndex("dbo.venda", "Id_evento");
        }
    }
}
