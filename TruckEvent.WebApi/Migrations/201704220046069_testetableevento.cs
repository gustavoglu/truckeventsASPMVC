namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testetableevento : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.evento", "Usuario_Organizador_Id", "dbo.usuario");
            DropForeignKey("dbo.usuario", "id", "dbo.evento");
        }
        
        public override void Down()
        {
        }
    }
}
