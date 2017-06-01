namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCampoValorInformado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.venda_pagamento_ficha", "ValorInformado", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.venda_pagamento_ficha", "ValorInformado");
        }
    }
}
