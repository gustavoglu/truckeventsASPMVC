namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkVendaEEvento3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.venda", "Id_evento", c => c.Guid(nullable: false));
            CreateIndex("dbo.venda", "Id_evento");
        }
        
        public override void Down()
        {
            DropIndex("dbo.venda", new[] { "Id_evento" });
            DropColumn("dbo.venda", "Id_evento");
            //RenameColumn(table: "dbo.venda", name: "Id_evento", newName: "Evento_Id");
            //CreateIndex("dbo.venda", "Evento_Id");
        }
    }
}
