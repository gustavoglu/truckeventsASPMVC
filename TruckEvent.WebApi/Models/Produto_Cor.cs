using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.Models
{
    public class Produto_Cor : BaseEntity
    {
        public string Descricao { get; set; }

        public string Cor { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}