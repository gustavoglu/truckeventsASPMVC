using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class Pagamento_TipoViewModel : BaseEntityViewModel
    {
        public Pagamento_TipoViewModel() : base()
        {
            
        }

        public string Descricao { get; set; } = null;

        public virtual ICollection<Venda_PagamentoViewModel> Venda_Pagamentos { get; set; }

    }
}