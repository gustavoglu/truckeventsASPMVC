namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vendapagamentoFicha : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Venda_Pagamento_Ficha",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Id_Ficha = c.Guid(nullable: false),
                        Id_Venda_Pagamento = c.Guid(nullable: false),
                        CriadoEm = c.DateTime(),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        DeletadoEm = c.DateTime(),
                        DeletadoPor = c.String(maxLength: 250, unicode: false),
                        AtualizadoEm = c.DateTime(),
                        AtualizadoPor = c.String(maxLength: 250, unicode: false),
                        Deletado = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ficha", t => t.Id_Ficha)
                .ForeignKey("dbo.venda_pagamento", t => t.Id_Venda_Pagamento)
                .Index(t => t.Id_Ficha)
                .Index(t => t.Id_Venda_Pagamento);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Venda_Pagamento_Ficha", "Id_Venda_Pagamento", "dbo.venda_pagamento");
            DropForeignKey("dbo.Venda_Pagamento_Ficha", "Id_Ficha", "dbo.ficha");
            DropIndex("dbo.Venda_Pagamento_Ficha", new[] { "Id_Venda_Pagamento" });
            DropIndex("dbo.Venda_Pagamento_Ficha", new[] { "Id_Ficha" });
            DropTable("dbo.Venda_Pagamento_Ficha");
        }
    }
}
