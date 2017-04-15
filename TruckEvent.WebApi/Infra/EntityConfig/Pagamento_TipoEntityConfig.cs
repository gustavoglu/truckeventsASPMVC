using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.EntityConfig
{
    public class Pagamento_TipoEntityConfig : EntityTypeConfiguration<Venda_Pagamento>
    {
        public Pagamento_TipoEntityConfig()
        {
            HasKey(p => p.Id);

            HasRequired(p => p.Venda)
                .WithMany(v => v.Venda_Pagamentos)
                .HasForeignKey(p => p.Id_venda);
        }
    }
}