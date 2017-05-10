using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class Venda_PagamentoViewModel : BaseEntityViewModel
    {
        public Venda_PagamentoViewModel() : base()
        {
            this.Venda_Pagamento_Fichas = new List<Venda_Pagamento_FichaViewModel>();
        }


        public double? Valor { get; set; }

        public Guid? Id_venda { get; set; }

        public virtual VendaViewModel Venda { get; set; } = null;

        public Guid? Id_pagamento_tipo { get; set; }

        public virtual Pagamento_TipoViewModel Pagamento_Tipo { get; set; } = null;

        public virtual ICollection<Venda_Pagamento_FichaViewModel> Venda_Pagamento_Fichas { get; set; }

    }
}