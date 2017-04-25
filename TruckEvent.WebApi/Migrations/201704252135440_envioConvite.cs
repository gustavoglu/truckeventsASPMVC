namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class envioConvite : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.usuario", "Email", c => c.String(maxLength: 256, unicode: false));
            AlterColumn("dbo.usuario", "UserName", c => c.String(nullable: false, maxLength: 256, unicode: false));
            CreateIndex("dbo.usuario", "UserName", unique: true, name: "UserNameIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.usuario", "UserNameIndex");
            AlterColumn("dbo.usuario", "UserName", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.usuario", "Email", c => c.String(maxLength: 250, unicode: false));
        }
    }
}
