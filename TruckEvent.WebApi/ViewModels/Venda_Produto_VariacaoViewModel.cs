using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class Venda_Produto_VariacaoViewModel : BaseEntityViewModel
    {
        public Venda_Produto_VariacaoViewModel() : base()
        {
          
        }

        public Guid? Id_produto_variacao { get; set; }

        public Guid? Id_venda_produto { get; set; }

        public virtual Produto_VariacaoViewModel Produto_Variacao { get; set; } = null;

        public virtual Venda_ProdutoViewModel Venda_Produto { get; set; } = null;

    }
}