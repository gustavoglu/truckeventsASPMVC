namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movimentacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.movimentacao",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Tipo_Mov = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        Id_Ficha = c.Guid(nullable: false),
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
                .Index(t => t.Id_Ficha);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.movimentacao", "Id_Ficha", "dbo.ficha");
            DropIndex("dbo.movimentacao", new[] { "Id_Ficha" });
            DropTable("dbo.movimentacao");
        }
    }
}
