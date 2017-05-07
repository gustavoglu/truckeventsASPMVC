namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkVendaEEvento5 : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.venda", new[] { "Evento_Id" });
            //RenameColumn(table: "dbo.venda", name: "Evento_Id", newName: "Id_evento");
            //AlterColumn("dbo.venda", "Id_evento", c => c.Guid(nullable: false));
            //CreateIndex("dbo.venda", "Id_evento");

            AddForeignKey("venda", "id_evento", "evento");
        }
        
        public override void Down()
        {
            DropIndex("dbo.venda", new[] { "Id_evento" });
            AlterColumn("dbo.venda", "Id_evento", c => c.Guid());
            RenameColumn(table: "dbo.venda", name: "Id_evento", newName: "Evento_Id");
            CreateIndex("dbo.venda", "Evento_Id");
        }
    }
}
