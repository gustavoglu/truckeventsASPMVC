using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.EntityConfig
{
    public class MovimentacaoEntityConfig : EntityTypeConfiguration<Movimentacao>
    {
        public MovimentacaoEntityConfig()
        {
            HasKey(m => m.Id);
            ToTable("movimentacao");

            HasRequired(m => m.Ficha)
                .WithMany(f => f.Movimentacoes)
                .HasForeignKey(m => m.Id_Ficha);

        }
    }
}