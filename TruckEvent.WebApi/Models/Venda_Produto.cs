using System;

namespace TruckEvent.WebApi.Models
{
    public class Venda_Produto
    {
        public Guid Id_produto{ get; set; }

        public Guid Id_Venda { get; set; }

        public int Quantidade { get; set; }

        public double Total { get; set; }

        public virtual Produto Produto { get; set; }

        public virtual Venda Venda { get; set; }


    }
}