namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TruckEvent.WebApi.Infra.Repository.EntityRepository;
    using TruckEvent.WebApi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TruckEvent.WebApi.Infra.SQLContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TruckEvent.WebApi.Infra.SQLContext context)
        {
            //var usuarioTipodbSet = context.Usuario_Tipos;
            //context.Usuario_Tipos.Add(new Usuario_Tipo() { Descricao = "Admin", UserAdmin = true });
            //context.Usuario_Tipos.Add(new Usuario_Tipo() { Descricao = "Usuario Loja" });
            //context.Usuario_Tipos.Add(new Usuario_Tipo() { Descricao = "Principal Loja", UserAdmin = false, UserPrincipal = true });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
