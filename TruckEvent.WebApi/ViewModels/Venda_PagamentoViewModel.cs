using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.ViewModels
{
    public class Venda_PagamentoViewModel
    {
        public Venda_PagamentoViewModel()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid? Id { get; set; }

        public double? Valor { get; set; }

        public Guid? Id_venda { get; set; }

        public virtual VendaViewModel Venda { get; set; } = null;

        public Guid? Id_pagamento_tipo { get; set; }

        public virtual Pagamento_TipoViewModel Pagamento_Tipo { get; set; } = null;
    }
}