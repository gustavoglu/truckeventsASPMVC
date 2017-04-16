using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.ViewModels
{
    public class Venda_ProdutoViewModel
    {
        public Venda_ProdutoViewModel()
        {
            this.Id = Guid.NewGuid();
            this.Venda_Produto_Variacoes = new List<Venda_Produto_VariacaoViewModel>();
        }

        public Guid? Id { get; set; }

        public Guid? Id_produto { get; set; }

        public Guid? Id_Venda { get; set; }

        public int? Quantidade { get; set; }

        public double? Total { get; set; }

        public virtual ProdutoViewModel Produto { get; set; } = null;

        public virtual VendaViewModel Venda { get; set; } = null;

        public virtual ICollection<Venda_Produto_VariacaoViewModel> Venda_Produto_Variacoes { get; set; }
    }
}