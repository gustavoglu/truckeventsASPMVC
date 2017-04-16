using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.Models
{
    public class Produto_Tipo : BaseEntity
    {
        public string Descricao { get; set; } = null;

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}