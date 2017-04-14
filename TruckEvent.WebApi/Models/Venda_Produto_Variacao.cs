using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.Models
{
    public class Venda_Produto_Variacao : BaseEntity
    {

        public Guid Id_produto_variacao { get; set; }

        public Guid Id_venda_produto { get; set; }

        public virtual Produto_Variacao Produto_Variacao{ get; set; }

        public virtual Venda_Produto Venda_Produto  { get; set; }
    }
}