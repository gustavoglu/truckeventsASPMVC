using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.EntityConfig
{
    public class FichaEntityConfig : EntityTypeConfiguration<Ficha>
    {
        public FichaEntityConfig()
        {
            HasKey(f => f.Id);

            HasRequired(f => f.Evento)
                .WithMany(e => e.Fichas)
                .HasForeignKey(f => f.Id_Evento);

            
        }
    }
}