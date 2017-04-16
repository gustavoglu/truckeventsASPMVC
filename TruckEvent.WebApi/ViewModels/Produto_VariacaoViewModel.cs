using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.ViewModels
{
    public class Produto_VariacaoViewModel
    {
        public Produto_VariacaoViewModel()
        {
            this.Id = Guid.NewGuid();

            this.Venda_Produto_Variacoes = new List<Venda_Produto_VariacaoViewModel>();
        }

        public Guid? Id { get; set; }

        public string Descricao { get; set; } = null;

        public double? Valor { get; set; }

        public Guid? Id_consequencia { get; set; }

        public string Id_usuario { get; set; } = null;

        public virtual ConsequenciaViewModel Consequencia { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }


        public virtual ICollection<Venda_Produto_VariacaoViewModel> Venda_Produto_Variacoes { get; set; }
    }
}