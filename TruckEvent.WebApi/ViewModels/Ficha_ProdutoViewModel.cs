using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.ViewModels
{
    public class Ficha_ProdutoViewModel
    {
        public Ficha_ProdutoViewModel()
        {
            this.Id = Guid.NewGuid();

        }
        public Guid? Id { get; set; }

        public Guid? Id_Ficha { get; set; }

        public Guid? Id_Produto { get; set; }

        public virtual ProdutoViewModel Produto { get; set; }

        public virtual FichaViewModel Ficha { get; set; }

        public bool? ProdutoRetirado { get; set; }

    }
}