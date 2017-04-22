using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class EventoViewModel
    {
        public EventoViewModel()
        {
            this.Id = Guid.NewGuid();

            this.Fichas = new List<Ficha>();
            this.Vendas = new List<Venda>();
        }

        public Guid? Id { get; set; }

        public string Descricao { get; set; } = null;

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public double? TotalValorVendido { get; set; }

        public int? TotalProdutosVendidos { get; set; }

        //public Usuario Usuario_Organizador { get; set; }

        //public string Id_usuario_organizador { get; set; } = null;

        public string Id_organizador { get; set; } = null;

        public virtual ICollection<Ficha> Fichas { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; }

        public DateTime? CriadoEm { get; set; }

        public string CriadoPor { get; set; } = null;

        public DateTime? DeletadoEm { get; set; }

        public string DeletadoPor { get; set; } = null;

        public DateTime? AtualizadoEm { get; set; }

        public string AtualizadoPor { get; set; } = null;

        public bool? Deletado { get; set; }
    }
}