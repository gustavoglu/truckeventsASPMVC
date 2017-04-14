using System.Collections;
using System.Collections.Generic;

namespace TruckEvent.WebApi.Models
{
    public class Pagamento_Tipo : BaseEntity
    {
        public string Descricao { get; set; }

        public virtual ICollection<Venda_Pagamento>  Venda_Pagamentos { get; set; }
    }
}