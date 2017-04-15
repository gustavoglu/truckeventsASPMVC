using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.EntityConfig
{
    public class Usuario_TipoEntityConfig : EntityTypeConfiguration<Usuario_Tipo>
    {
        public Usuario_TipoEntityConfig()
        {
            HasKey(ut => ut.Id);

        }
    }
}