using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class VendaViewModel : BaseEntityViewModel
    {

        public VendaViewModel() : base ()
        {
            this.Venda_Pagamentos = new List<Venda_PagamentoViewModel>();

            this.Venda_Produtos = new List<Venda_ProdutoViewModel>();
        }

        public DateTime? Data { get; set; }

        public double? TotalVenda { get; set; }

        public double? Troco { get; set; }

        public string NomeCliente { get; set; } = null;

        public bool? Cancelada { get; set; }

        public Guid? Id_evento { get; set; }

        public virtual EventoViewModel Evento { get; set; } = null;

        public virtual ICollection<Venda_PagamentoViewModel> Venda_Pagamentos { get; set; }

        public virtual ICollection<Venda_ProdutoViewModel> Venda_Produtos { get; set; }


    }
}