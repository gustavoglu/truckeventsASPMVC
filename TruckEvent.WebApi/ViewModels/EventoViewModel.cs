using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{

    public class EventoViewModel : BaseEntityViewModel
    {
        
        public EventoViewModel() : base()
        {
            this.Fichas = new List<FichaViewModel>();
            this.Vendas = new List<VendaViewModel>();
            this.Evento_Usuarios = new List<Evento_UsuarioViewModel>();
        }

        public string Descricao { get; set; } = null;

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public double? TotalValorVendido { get; set; }

        public int? TotalProdutosVendidos { get; set; }

        public string Id_organizador { get; set; } = null;

        public virtual UsuarioViewModel Usuario_Organizador { get; set; }
       
        public virtual ICollection<FichaViewModel> Fichas { get; set; }

        public virtual ICollection<VendaViewModel> Vendas { get; set; }

        public virtual ICollection<Evento_UsuarioViewModel> Evento_Usuarios { get; set; }

    }
}