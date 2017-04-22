using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.EntityConfig
{
    public class EventoEntityConfig : EntityTypeConfiguration<Evento>
    {
        public EventoEntityConfig()
        {
            ToTable("evento");

            HasKey(e => e.Id);

            HasRequired(e => e.Usuario_Organizador)
                .WithMany(u => u.Eventos)
                .HasForeignKey(e => e.Id_organizador);



        }
    }
}