namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testetableevento2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.evento", "Usuario_Id", "dbo.usuario");
            DropIndex("dbo.evento", new[] { "Usuario_Id" });
        }
        
        public override void Down()
        {
            
            
        }
    }
}
