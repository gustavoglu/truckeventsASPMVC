using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.EntityConfig
{
    public class Pagamento_TipoEntityConfig : EntityTypeConfiguration<Pagamento_Tipo>
    {
        public Pagamento_TipoEntityConfig()
        {
            ToTable("pagamento_tipo");

            HasKey(p => p.Id);

        }
    }
}