using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.EntityConfig
{
    public class Evento_UsuarioEntityConfig : EntityTypeConfiguration<Evento_Usuario>
    {
        public Evento_UsuarioEntityConfig()
        {
            HasKey(eu => eu.Id);

            HasRequired(eu => eu.Evento)
                .WithRequiredPrincipal()
                .Map(m => m.MapKey("id_evento"));


        }
    }
}