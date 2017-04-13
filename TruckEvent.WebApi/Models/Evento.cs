using System;

namespace TruckEvent.WebApi.Models
{
    public class Evento
    {
        public string Descricao { get; set; }

        public string Id_usuario_organizador { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public double TotalValorVendido { get; set; }

        public int TotalProdutosVendidos { get; set; }
    }
}