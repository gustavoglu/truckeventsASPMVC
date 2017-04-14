using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.EntityConfig
{
    public class PagamentoEntityConfig : EntityTypeConfiguration<Pagamento>
    {
        public PagamentoEntityConfig()
        {
            HasKey(p => p.Id);

            HasRequired(p => p.Venda)
                .WithMany(v => v.Pagamentos)
                .HasForeignKey(p => p.Id_venda);
        }
    }
}