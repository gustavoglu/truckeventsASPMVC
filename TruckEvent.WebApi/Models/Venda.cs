using System;

namespace TruckEvent.WebApi.Models
{
    public class Venda
    {
        public DateTime Data { get; set; }

        public double TotalVenda { get; set; }

        public double Troco { get; set; }

        public string NomeCliente  { get; set; }



        public Guid Id_evento { get; set; }

        public Guid Id_venda_pagamento_tipo { get; set; }

        public virtual Evento Evento { get; set; }

        public virtual Venda_Pagamento_Tipo Venda_Pagamento_Tipo  { get; set; }

    }
}