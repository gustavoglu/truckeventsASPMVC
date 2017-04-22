using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

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

        public virtual Produto Produto { get; set; }

        public virtual Ficha Ficha { get; set; }

        public bool? ProdutoRetirado { get; set; }

        public DateTime? CriadoEm { get; set; }

        public string CriadoPor { get; set; } = null;

        public DateTime? DeletadoEm { get; set; }

        public string DeletadoPor { get; set; } = null;

        public DateTime? AtualizadoEm { get; set; }

        public string AtualizadoPor { get; set; } = null;

        public bool? Deletado { get; set; }

    }
}