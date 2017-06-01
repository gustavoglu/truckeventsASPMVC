namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TruckEvent.WebApi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TruckEvent.WebApi.Infra.SQLContext>
    {
        public Configuration()
        {
            
            //AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TruckEvent.WebApi.Infra.SQLContext context)
        {
            context.Fichas.Add(new Ficha { Saldo = 30, NomeCliente = "Gustavo", Codigo = "123456" ,Id_Evento = Guid.Parse("E71BD939-E19E-4A3B-BDE2-05EAF2A9E5C6") });
            context.Fichas.Add(new Ficha { Saldo = 35, NomeCliente = "Alex", Codigo = "654321",Id_Evento = Guid.Parse("E71BD939-E19E-4A3B-BDE2-05EAF2A9E5C6") });
            context.Fichas.Add(new Ficha { Saldo = 20, NomeCliente = "Gian", Codigo = "456789",Id_Evento = Guid.Parse("E71BD939-E19E-4A3B-BDE2-05EAF2A9E5C6") });
            context.Fichas.Add(new Ficha { Saldo = 50, NomeCliente = "Vinicius", Codigo = "987654",Id_Evento = Guid.Parse("E71BD939-E19E-4A3B-BDE2-05EAF2A9E5C6") });
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
