using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.EntityConfig
{
    public class Produto_CorEntityConfig : EntityTypeConfiguration<Produto_Cor>
    {
        public Produto_CorEntityConfig()
        {
            HasKey(pc => pc.Id);

        }
    }
}