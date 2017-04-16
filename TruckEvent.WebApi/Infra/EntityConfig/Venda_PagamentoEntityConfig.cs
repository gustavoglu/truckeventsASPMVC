using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.EntityConfig
{
    public class Venda_PagamentoEntityConfig : EntityTypeConfiguration<Venda_Pagamento>
    {
        public Venda_PagamentoEntityConfig()
        {
            ToTable("venda_pagamento");

            HasKey(vp => vp.Id);

            HasRequired(vp => vp.Venda)
                .WithMany(v => v.Venda_Pagamentos)
                .HasForeignKey(vp => vp.Id_venda);

            HasRequired(vp => vp.Pagamento_Tipo)
                .WithMany(pt => pt.Venda_Pagamentos)
                .HasForeignKey(vp => vp.Id_pagamento_tipo);

        }
    }
}