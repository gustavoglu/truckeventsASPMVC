using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.Models
{
    public class Consequencia : BaseEntity
    {
        public string Descricao { get; set; } = null;

        public virtual ICollection<Produto_Variacao> Produto_Variacoes{ get; set; }
    }
}