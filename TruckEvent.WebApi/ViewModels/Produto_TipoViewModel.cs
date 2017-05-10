using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class Produto_TipoViewModel : BaseEntityViewModel
    {
        public Produto_TipoViewModel() : base()
        {

            Produtos = new List<ProdutoViewModel>();
        }

        public string Descricao { get; set; } = null;

        public virtual ICollection<ProdutoViewModel> Produtos { get; set; }
    }
}