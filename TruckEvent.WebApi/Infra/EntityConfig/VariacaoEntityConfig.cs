using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.EntityConfig
{
    public class VariacaoEntityConfig : EntityTypeConfiguration<Variacao>
    {
        public VariacaoEntityConfig()
        {
            HasKey(v => v.Id);

        }

    }
}