using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class ProdutoViewModel : BaseEntityViewModel
    {
        public ProdutoViewModel() : base()
        {

            Venda_Produtos = new List<Venda_ProdutoViewModel>();

            Ficha_Produtos = new List<Ficha_ProdutoViewModel>();
        }

        public string Descricao { get; set; } = null;

        public double? Valor { get; set; }

        public int? Numero { get; set; }

        public Guid? Id_produto_cor { get; set; }

        public Guid? Id_produto_tipo { get; set; }
   
        public Produto_CorViewModel Produto_Cor { get; set; } = null;

        public Produto_TipoViewModel Produto_Tipo { get; set; } = null;

        public virtual ICollection<Venda_ProdutoViewModel> Venda_Produtos { get; set; }

        public virtual ICollection<Ficha_ProdutoViewModel> Ficha_Produtos { get; set; }



    }
}