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
            ToTable("evento_usuario");

            HasKey(eu => eu.Id);

            HasRequired(eu => eu.Evento)
                .WithMany(e => e.Evento_Usuarios)
                .HasForeignKey(eu => eu.Id_Evento);

            HasRequired(eu => eu.Usuario)
                .WithMany(u => u.Evento_Usuarios)
                .HasForeignKey(eu => eu.Id_Usuario);


        }
    }
}