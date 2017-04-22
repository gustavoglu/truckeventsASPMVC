namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testetableevento3 : DbMigration
    {
        public override void Up()
        {
            DropTable("evento");
        }
        
        public override void Down()
        {
           
        }
    }
}
