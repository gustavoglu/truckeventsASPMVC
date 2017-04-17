namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.usuario", "UserAdmin", c => c.Boolean());
            AddColumn("dbo.usuario", "UserPrincipal", c => c.Boolean());
            AddColumn("dbo.usuario", "Organizador", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.usuario", "Organizador");
            DropColumn("dbo.usuario", "UserPrincipal");
            DropColumn("dbo.usuario", "UserAdmin");
        }
    }
}
