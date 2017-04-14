using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.EntityConfig
{
    public class ProdutoEntityConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoEntityConfig()
        {
            HasKey(p => p.Id);

            HasRequired(p => p.Produto_Cor)
            .WithMany(c => c.Produtos)
            .HasForeignKey(p => p.Id_produto_cor);

            HasRequired(p => p.Produto_Tipo)
                .WithMany(t => t.Produtos)
                .HasForeignKey(p => p.Id_produto_tipo);
            
        }
    }
}