namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial2 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.variacao");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.variacao",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        Valor = c.Double(),
                        CriadoEm = c.DateTime(),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        DeletadoEm = c.DateTime(),
                        DeletadoPor = c.String(maxLength: 250, unicode: false),
                        AtualizadoEm = c.DateTime(),
                        AtualizadoPor = c.String(maxLength: 250, unicode: false),
                        Deletado = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
