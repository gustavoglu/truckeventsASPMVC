using System;
using System.Collections;
using System.Collections.Generic;

namespace TruckEvent.WebApi.Models
{
    public class Evento : BaseEntity
    {
        public string Descricao { get; set; }

        public string Id_usuario_organizador { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public double TotalValorVendido { get; set; }

        public int TotalProdutosVendidos { get; set; }

        public virtual Usuario Usuario_Organizador { get; set; }

        public virtual ICollection<Ficha> Fichas { get; set; }

        public virtual ICollection<Venda> Vendas{ get; set; }
    }
}