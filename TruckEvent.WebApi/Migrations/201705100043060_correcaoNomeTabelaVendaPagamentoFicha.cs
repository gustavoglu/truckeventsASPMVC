namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcaoNomeTabelaVendaPagamentoFicha : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.venda_pagamento", "Id_pagamento_tipo", "dbo.pagamento_tipo");
            DropIndex("dbo.venda_pagamento", new[] { "Id_pagamento_tipo" });
            DropColumn("dbo.venda_pagamento", "Id_pagamento_tipo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.venda_pagamento", "Id_pagamento_tipo", c => c.Guid(nullable: false));
            CreateIndex("dbo.venda_pagamento", "Id_pagamento_tipo");
            AddForeignKey("dbo.venda_pagamento", "Id_pagamento_tipo", "dbo.pagamento_tipo", "Id");
        }
    }
}
