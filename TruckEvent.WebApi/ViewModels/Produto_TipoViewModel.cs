﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.ViewModels
{
    public class Produto_TipoViewModel
    {
        public Produto_TipoViewModel()
        {
            this.Id = Guid.NewGuid();

            this.Produtos = new List<ProdutoViewModel>();
        }

        public Guid? Id { get; set; }

        public string Descricao { get; set; } = null;

        public virtual ICollection<ProdutoViewModel> Produtos { get; set; }
    }
}