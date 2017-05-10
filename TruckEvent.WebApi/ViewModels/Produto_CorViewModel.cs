using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class Produto_CorViewModel : BaseEntityViewModel
    {
        public Produto_CorViewModel() : base()
        { 
            Produtos = new List<ProdutoViewModel>();

        }

        public string Descricao { get; set; } = null;

        public string Cor { get; set; } = null;

        public ICollection<ProdutoViewModel> Produtos { get; set; }

    }
}