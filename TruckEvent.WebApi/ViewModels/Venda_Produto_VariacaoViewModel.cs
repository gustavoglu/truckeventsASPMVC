using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.ViewModels
{
    public class Venda_Produto_VariacaoViewModel
    {
        public Venda_Produto_VariacaoViewModel()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid? Id { get; set; }

        public Guid? Id_produto_variacao { get; set; }

        public Guid? Id_venda_produto { get; set; }

        public virtual Produto_VariacaoViewModel Produto_Variacao { get; set; } = null;

        public virtual Venda_ProdutoViewModel Venda_Produto { get; set; } = null;
    }
}