using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.EntityConfig
{
    public class Venda_ProdutoEntityConfig : EntityTypeConfiguration<Venda_Produto>
    {
        public Venda_ProdutoEntityConfig()
        {
            ToTable("venda_produto");


            HasKey(vp => vp.Id);

            HasRequired(vp => vp.Produto)
                .WithMany(p => p.Venda_Produtos)
                .HasForeignKey(vp => vp.Id_produto);

            HasRequired(vp => vp.Venda)
                .WithMany(v => v.Venda_Produtos)
                .HasForeignKey(vp => vp.Id_Venda);


        }
    }
}