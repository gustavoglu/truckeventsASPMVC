namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TokenEnvioMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tokenenvio",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Token = c.String(maxLength: 250, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        ExpiraEm = c.DateTime(nullable: false),
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
        
        public override void Down()
        {
            DropTable("dbo.tokenenvio");
        }
    }
}
