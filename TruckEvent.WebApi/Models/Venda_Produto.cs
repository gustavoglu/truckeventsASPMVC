using System;
using System.Collections.Generic;

namespace TruckEvent.WebApi.Models
{
    public class Venda_Produto : BaseEntity
    {
        public Guid? Id_produto{ get; set; }

        public Guid? Id_Venda { get; set; }

        public int? Quantidade { get; set; }

        public double? Total { get; set; }

        public virtual Produto Produto { get; set; } = null;

        public virtual Venda Venda { get; set; } = null;

        public virtual ICollection<Venda_Produto_Variacao> Venda_Produto_Variacoes { get; set; }


    }
}