using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.EntityConfig
{
    public class ConsequenciaEntityConfig : EntityTypeConfiguration<Consequencia>
    {
        public ConsequenciaEntityConfig()
        {
            ToTable("consequencia");

            HasKey(i => i.Id);

        }
    }
}