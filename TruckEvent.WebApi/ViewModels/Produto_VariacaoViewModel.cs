using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class Produto_VariacaoViewModel
    {
        public Produto_VariacaoViewModel()
        {
            this.Id = Guid.NewGuid();

            this.Venda_Produto_Variacoes = new List<Venda_Produto_Variacao>();
        }

        public Guid? Id { get; set; }

        public string Descricao { get; set; } = null;

        public double? Valor { get; set; }

        public Guid? Id_consequencia { get; set; }

        public string Id_usuario { get; set; } = null;

        public virtual Consequencia Consequencia { get; set; }

        public virtual Usuario Usuario { get; set; }


        public virtual ICollection<Venda_Produto_Variacao> Venda_Produto_Variacoes { get; set; }
    }
}