namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fichaproduto : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ficha_produto", new[] { "Ficha_Id" });
            DropIndex("dbo.ficha_produto", new[] { "Produto_Id" });
            DropColumn("dbo.ficha_produto", "Id_Produto");
            DropColumn("dbo.ficha_produto", "Id_Produto");
            RenameColumn(table: "dbo.ficha_produto", name: "Ficha_Id", newName: "Id_Produto");
            RenameColumn(table: "dbo.ficha_produto", name: "Produto_Id", newName: "Id_Produto");
            AlterColumn("dbo.ficha_produto", "Id_Ficha", c => c.Guid());
            AlterColumn("dbo.ficha_produto", "Id_Produto", c => c.Guid(nullable: false));
            AlterColumn("dbo.ficha_produto", "Id_Produto", c => c.Guid(nullable: false));
            CreateIndex("dbo.ficha_produto", "Id_Produto");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ficha_produto", new[] { "Id_Produto" });
            AlterColumn("dbo.ficha_produto", "Id_Produto", c => c.Guid());
            AlterColumn("dbo.ficha_produto", "Id_Produto", c => c.Guid());
            AlterColumn("dbo.ficha_produto", "Id_Ficha", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.ficha_produto", name: "Id_Produto", newName: "Produto_Id");
            RenameColumn(table: "dbo.ficha_produto", name: "Id_Produto", newName: "Ficha_Id");
            AddColumn("dbo.ficha_produto", "Id_Produto", c => c.Guid(nullable: false));
            AddColumn("dbo.ficha_produto", "Id_Produto", c => c.Guid(nullable: false));
            CreateIndex("dbo.ficha_produto", "Produto_Id");
            CreateIndex("dbo.ficha_produto", "Ficha_Id");
        }
    }
}
