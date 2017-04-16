using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.EntityConfig
{
    public class Venda_Produto_VariacaoEntityConfig : EntityTypeConfiguration<Venda_Produto_Variacao>
    {
        public Venda_Produto_VariacaoEntityConfig()
        {

            ToTable("venda_produto_variacao");

            HasKey(vpv => vpv.Id);

            HasRequired(vpv => vpv.Produto_Variacao)
                .WithMany(pv => pv.Venda_Produto_Variacoes)
                .HasForeignKey(vpv => vpv.Id_produto_variacao);

            HasRequired(vpv => vpv.Venda_Produto)
                .WithMany(vp => vp.Venda_Produto_Variacoes)
                .HasForeignKey(vpv => vpv.Id_venda_produto);

        }
    }
}