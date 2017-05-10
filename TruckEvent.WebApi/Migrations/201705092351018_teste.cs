namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Venda_Pagamento_FichaViewModel", "Ficha_Id", "dbo.ficha");
            DropForeignKey("dbo.Venda_Pagamento_FichaViewModel", "Venda_Pagamento_Id", "dbo.venda_pagamento");
            DropIndex("dbo.Venda_Pagamento_FichaViewModel", new[] { "Ficha_Id" });
            DropIndex("dbo.Venda_Pagamento_FichaViewModel", new[] { "Venda_Pagamento_Id" });
            DropTable("dbo.Venda_Pagamento_FichaViewModel");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Venda_Pagamento_FichaViewModel",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Id_Ficha = c.Guid(),
                        Id_Venda_Pagamento = c.Guid(),
                        CriadoEm = c.DateTime(),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        DeletadoEm = c.DateTime(),
                        DeletadoPor = c.String(maxLength: 250, unicode: false),
                        AtualizadoEm = c.DateTime(),
                        AtualizadoPor = c.String(maxLength: 250, unicode: false),
                        Deletado = c.Boolean(),
                        Ficha_Id = c.Guid(),
                        Venda_Pagamento_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Venda_Pagamento_FichaViewModel", "Venda_Pagamento_Id");
            CreateIndex("dbo.Venda_Pagamento_FichaViewModel", "Ficha_Id");
            AddForeignKey("dbo.Venda_Pagamento_FichaViewModel", "Venda_Pagamento_Id", "dbo.venda_pagamento", "Id");
            AddForeignKey("dbo.Venda_Pagamento_FichaViewModel", "Ficha_Id", "dbo.ficha", "Id");
        }
    }
}
