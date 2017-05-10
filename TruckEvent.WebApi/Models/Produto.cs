using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.Models
{
    public class Produto : BaseEntity
    {
        public string Descricao { get; set; } = null;
        public double? Valor { get; set; }
        public int? Numero { get; set; }

        public Guid? Id_produto_cor { get; set; }
        public Guid? Id_produto_tipo { get; set; }

        public virtual Produto_Cor Produto_Cor { get; set; } = null;
        public virtual Produto_Tipo Produto_Tipo { get; set; } = null;

        [JsonIgnore]
        public virtual ICollection<Venda_Produto> Venda_Produtos { get; set; }

        [JsonIgnore]
        public virtual ICollection<Ficha_Produto> Ficha_Produtos { get; set; }
    }
}