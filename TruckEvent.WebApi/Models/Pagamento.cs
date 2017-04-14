using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.Models
{
    public class Pagamento : BaseEntity
    {
        public Ficha Ficha { get; set; }

        public double Valor { get; set; }

        public Guid Id_venda { get; set; }

        public virtual Venda Venda { get; set; }
    }
}