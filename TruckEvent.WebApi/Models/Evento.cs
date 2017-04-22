using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.Models
{
    public class Evento : BaseEntity
    {
        public string Descricao { get; set; } = null;

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public double? TotalValorVendido { get; set; }

        public int? TotalProdutosVendidos { get; set; }

        public string Id_organizador { get; set; } = null;

        public virtual Usuario Usuario_Organizador { get; set; }

        public virtual ICollection<Ficha> Fichas { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; }

        public virtual ICollection<Evento_Usuario> Evento_Usuarios  { get; set; }


    }
}