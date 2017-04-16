using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.ViewModels
{
    public class Pagamento_TipoViewModel
    {
        public Pagamento_TipoViewModel()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid? Id { get; set; }

        public string Descricao { get; set; } = null;

        public virtual ICollection<Venda_PagamentoViewModel> Venda_Pagamentos { get; set; }
    }
}