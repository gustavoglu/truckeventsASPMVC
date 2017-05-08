using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.EntityConfig
{
    public class Venda_Pagamento_FichaEntityConfig : EntityTypeConfiguration<Venda_Pagamento_Ficha>
    {
        public Venda_Pagamento_FichaEntityConfig()
        {
            HasKey(vpf => vpf.Id);

            HasRequired(vpf => vpf.Venda_Pagamento)
                .WithMany(vp => vp.Id_Venda_Pagamento_Fichas)
                .HasForeignKey(vpf => vpf.Id_Venda_Pagamento);

            HasRequired(vpf => vpf.Ficha)
                .WithMany(f => f.Venda_Pagamento_Fichas)
                .HasForeignKey(vpf => vpf.Id_Ficha);

        }
    }
}