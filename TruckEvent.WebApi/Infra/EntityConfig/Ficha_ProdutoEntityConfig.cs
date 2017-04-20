using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.EntityConfig
{
    public class Ficha_ProdutoEntityConfig : EntityTypeConfiguration<Ficha_Produto>
    {
        public Ficha_ProdutoEntityConfig()
        {
            ToTable("ficha_produto");
            HasKey(fp => fp.Id);

            HasRequired(fp => fp.Produto)
                .WithMany(p => p.Ficha_Produtos)
                .HasForeignKey(fp => fp.Id_Produto);


            HasRequired(fp => fp.Ficha)
                .WithMany(f => f.Ficha_Produtos)
                .HasForeignKey(fp => fp.Id_Ficha);
        }
    }
}