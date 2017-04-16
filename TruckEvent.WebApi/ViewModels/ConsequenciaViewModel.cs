using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.ViewModels
{
    public class ConsequenciaViewModel
    {
        public ConsequenciaViewModel()
        {
            this.Id = Guid.NewGuid();

            this.Produto_Variacoes = new List<Produto_VariacaoViewModel>();

        }

        public Guid? Id { get; set; }

        public string Descricao { get; set; } = null;

        public virtual ICollection<Produto_VariacaoViewModel> Produto_Variacoes { get; set; }
    }
}