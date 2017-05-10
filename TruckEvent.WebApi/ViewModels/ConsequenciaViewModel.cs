using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class ConsequenciaViewModel : BaseEntityViewModel
    {
        public ConsequenciaViewModel() : base()
        {

            this.Produto_Variacoes = new List<Produto_VariacaoViewModel>();

        }

        public string Descricao { get; set; } = null;

        public virtual ICollection<Produto_VariacaoViewModel> Produto_Variacoes { get; set; }

     
    }
}