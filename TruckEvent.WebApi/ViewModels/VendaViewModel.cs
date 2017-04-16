using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.ViewModels
{
    public class VendaViewModel
    {

        public VendaViewModel()
        {
            this.Id = Guid.NewGuid();
            this.Venda_Pagamentos = new List<Venda_PagamentoViewModel>();
            this.Venda_Produtos = new List<Venda_ProdutoViewModel>();
        }
        public Guid? Id { get; set; }

        public DateTime? Data { get; set; }

        public double? TotalVenda { get; set; }

        public double? Troco { get; set; }

        public string NomeCliente { get; set; } = null;

        public Guid? Id_evento { get; set; }

        public virtual EventoViewModel Evento { get; set; } = null;

        public virtual ICollection<Venda_PagamentoViewModel> Venda_Pagamentos { get; set; }

        public virtual ICollection<Venda_ProdutoViewModel> Venda_Produtos { get; set; }

    }
}