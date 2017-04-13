using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.Models
{
    public class Produto
    {
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public int Numero { get; set; }

        public Guid Id_produto_cor { get; set; }
        public Guid Id_produto_tipo { get; set; }
        public string Id_usuario { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Produto_Cor Produto_Cor { get; set; }
        public virtual Produto_Tipo Produto_Tipo { get; set; }
    }
}