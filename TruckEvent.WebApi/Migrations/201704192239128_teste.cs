namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ficha_produto",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Id_Ficha = c.Guid(),
                        Id_Produto = c.Guid(nullable: false),
                        ProdutoRetirado = c.Boolean(),
                        CriadoEm = c.DateTime(),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        DeletadoEm = c.DateTime(),
                        DeletadoPor = c.String(maxLength: 250, unicode: false),
                        AtualizadoEm = c.DateTime(),
                        AtualizadoPor = c.String(maxLength: 250, unicode: false),
                        Deletado = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ficha", t => t.Id_Produto)
                .ForeignKey("dbo.produto", t => t.Id_Produto)
                .Index(t => t.Id_Produto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ficha_produto", "Id_Produto", "dbo.produto");
            DropForeignKey("dbo.ficha_produto", "Id_Produto", "dbo.ficha");
            DropIndex("dbo.ficha_produto", new[] { "Id_Produto" });
            DropTable("dbo.ficha_produto");
        }
    }
}
