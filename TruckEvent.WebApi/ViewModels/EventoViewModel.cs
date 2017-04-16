using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.ViewModels
{
    public class EventoViewModel
    {
        public EventoViewModel()
        {
            this.Id = Guid.NewGuid();

            this.Fichas = new List<FichaViewModel>();
            this.Vendas = new List<VendaViewModel>();
        }

        public Guid? Id { get; set; }

        public string Descricao { get; set; } = null;

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public double? TotalValorVendido { get; set; }

        public int? TotalProdutosVendidos { get; set; }

        public virtual UsuarioViewModel Usuario_Organizador { get; set; } = null;

        public string Id_usuario_organizador { get; set; } = null;

        public virtual ICollection<FichaViewModel> Fichas { get; set; }

        public virtual ICollection<VendaViewModel> Vendas { get; set; }
    }
}