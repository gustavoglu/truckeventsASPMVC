namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smsconf : DbMigration
    {
        public override void Up()
        {
         
            
            AddColumn("dbo.ficha", "CelularCliente", c => c.String(maxLength: 250, unicode: false));
            DropColumn("dbo.ficha", "NumeroCelular");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ficha", "NumeroCelular", c => c.String(maxLength: 250, unicode: false));
            DropColumn("dbo.ficha", "CelularCliente");

        }
    }
}
