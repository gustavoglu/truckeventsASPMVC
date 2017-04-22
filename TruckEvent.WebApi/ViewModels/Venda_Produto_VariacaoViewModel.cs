using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class Venda_Produto_VariacaoViewModel
    {
        public Venda_Produto_VariacaoViewModel()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid? Id { get; set; }

        public Guid? Id_produto_variacao { get; set; }

        public Guid? Id_venda_produto { get; set; }

        public virtual Produto_Variacao Produto_Variacao { get; set; } = null;

        public virtual Venda_Produto Venda_Produto { get; set; } = null;

        public DateTime? CriadoEm { get; set; }

        public string CriadoPor { get; set; } = null;

        public DateTime? DeletadoEm { get; set; }

        public string DeletadoPor { get; set; } = null;

        public DateTime? AtualizadoEm { get; set; }

        public string AtualizadoPor { get; set; } = null;

        public bool? Deletado { get; set; }
    }
}