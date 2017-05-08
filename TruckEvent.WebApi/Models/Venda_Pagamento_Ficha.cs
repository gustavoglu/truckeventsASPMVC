using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.Models
{
    public class Venda_Pagamento_Ficha : BaseEntity
    {

        public Guid? Id_Ficha { get; set; }

        public Guid? Id_Venda_Pagamento { get; set; }

        public virtual Venda_Pagamento Venda_Pagamento { get; set; }

        public virtual Ficha Ficha { get; set; }
    }
}