using System;
using System.Collections;
using System.Collections.Generic;

namespace TruckEvent.WebApi.Models
{
    public class Venda : BaseEntity
    {
        public DateTime Data { get; set; }

        public double TotalVenda { get; set; }

        public double Troco { get; set; }

        public string NomeCliente { get; set; }

        public Guid Id_evento { get; set; }

        public virtual Evento Evento { get; set; }

        public virtual ICollection<Venda_Pagamento> Venda_Pagamentos { get; set; }

        public virtual ICollection<Venda_Produto> Venda_Produtos { get; set; }

    }
}