namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkVendaEEvento2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.venda", "IX_Evento_Id");
            DropColumn("dbo.venda","Evento_Id");
        }
        
        public override void Down()
        {
        }
    }
}
