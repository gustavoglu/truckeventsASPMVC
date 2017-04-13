using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.Models
{
    public class Produto_Variacao
    {
        public string Descricao { get; set; }

        public double Valor { get; set; }

        public Guid Id_consequencia { get; set; }

        public string Id_usuario { get; set; }

        public virtual Consequencia Consequencia { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}