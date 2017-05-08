using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.Models
{
    public class Venda_Pagamento : BaseEntity
    {
 
        public double? Valor { get; set; }

        public Guid? Id_venda { get; set; }

        public virtual Venda Venda { get; set; } = null;

        public Guid? Id_pagamento_tipo { get; set; }

        public virtual Pagamento_Tipo Pagamento_Tipo { get; set; } = null;

        public virtual ICollection<Venda_Pagamento_Ficha> Id_Venda_Pagamento_Fichas { get; set; }

    }
}