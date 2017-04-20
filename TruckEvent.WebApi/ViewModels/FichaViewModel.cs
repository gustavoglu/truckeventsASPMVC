using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.ViewModels
{
    public class FichaViewModel
    {

        public FichaViewModel()
        {
            this.Id = Guid.NewGuid();
            this.Ficha_Produtos = new List<Ficha_ProdutoViewModel>();
        }
        public Guid? Id { get; set; }

        public string Codigo { get; set; } = null;

        public string NomeCliente { get; set; } = null;

        public int? Senha { get; set; }

        public double? Saldo { get; set; }

        public Guid? Id_Evento { get; set; }

        public virtual EventoViewModel Evento { get; set; } = null;

        public virtual ICollection<Ficha_ProdutoViewModel> Ficha_Produtos{ get; set; }
    }
}