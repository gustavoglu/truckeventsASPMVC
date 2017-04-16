using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.EntityConfig
{
    public class Produto_TipoEntityConfig : EntityTypeConfiguration<Produto_Tipo>
    {
        public Produto_TipoEntityConfig()
        {
            ToTable("produto_tipo");

            HasKey(pt => pt.Id);



        }
    }
}