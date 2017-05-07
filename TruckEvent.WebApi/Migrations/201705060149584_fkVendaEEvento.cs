namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkVendaEEvento : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.venda", "Id_evento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.venda", "Id_evento", c => c.Guid());
        }
    }
}
