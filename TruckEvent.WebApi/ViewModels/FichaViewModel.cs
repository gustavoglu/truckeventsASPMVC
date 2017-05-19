using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class FichaViewModel : BaseEntityViewModel
    {

        public FichaViewModel() : base()
        {
         
            this.Ficha_Produtos = new List<Ficha_ProdutoViewModel>();

            this.Venda_Pagamento_Fichas = new List<Venda_Pagamento_FichaViewModel>();
        }
   
        public string Codigo { get; set; } = null;

        public string NomeCliente { get; set; } = null;

        public int? Senha { get; set; }

        public double? Saldo { get; set; }

        public Guid? Id_Evento { get; set; }

        public virtual EventoViewModel Evento { get; set; } = null;

        public virtual ICollection<Ficha_ProdutoViewModel> Ficha_Produtos { get; set; }

        public virtual ICollection<Venda_Pagamento_FichaViewModel> Venda_Pagamento_Fichas { get; set; }

        public virtual ICollection<MovimentacaoViewModel> Movimentacoes { get; set; }

    }
}