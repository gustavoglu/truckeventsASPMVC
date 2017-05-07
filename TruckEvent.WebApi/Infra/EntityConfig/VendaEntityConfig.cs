using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.EntityConfig
{
    public class VendaEntityConfig : EntityTypeConfiguration<Venda>
    {
        public VendaEntityConfig()
        {
            ToTable("venda");

            HasKey(v => v.Id);

            HasRequired(v => v.Evento)
                .WithMany(e => e.Vendas)
                .HasForeignKey(v => v.Id_evento);


        }
    }
}