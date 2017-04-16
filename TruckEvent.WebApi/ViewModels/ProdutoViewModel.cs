using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            this.Id = Guid.NewGuid();
            this.Venda_Produtos = new List<Venda_ProdutoViewModel>();
        }

        public Guid? Id { get; set; }

        public string Descricao { get; set; } = null;
        public double? Valor { get; set; }
        public int? Numero { get; set; }

        public Guid? Id_produto_cor { get; set; }
        public Guid? Id_produto_tipo { get; set; }

        public virtual Produto_CorViewModel Produto_Cor { get; set; } = null;
        public virtual Produto_TipoViewModel Produto_Tipo { get; set; } = null;

        public virtual ICollection<Venda_ProdutoViewModel> Venda_Produtos { get; set; }
    }
}