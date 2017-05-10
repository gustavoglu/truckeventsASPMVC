using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class Venda_Pagamento_FichaViewModel : BaseEntityViewModel
    {
        public Venda_Pagamento_FichaViewModel() : base()
        {

        }

        public Guid? Id_Ficha { get; set; }

        public Guid? Id_Venda_Pagamento { get; set; }

        public virtual Venda_PagamentoViewModel Venda_Pagamento { get; set; }

        public virtual FichaViewModel Ficha { get; set; }

    }
}