namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class evento5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.evento", "Id_organizador", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.evento", "Id_organizador");
        }
    }
}
