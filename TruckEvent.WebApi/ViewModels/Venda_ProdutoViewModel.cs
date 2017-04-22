using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class Venda_ProdutoViewModel
    {
        public Venda_ProdutoViewModel()
        {
            this.Id = Guid.NewGuid();
            this.Venda_Produto_Variacoes = new List<Venda_Produto_Variacao>();
        }

        public Guid? Id { get; set; }

        public Guid? Id_produto { get; set; }

        public Guid? Id_Venda { get; set; }

        public int? Quantidade { get; set; }

        public double? Total { get; set; }

        public virtual Produto Produto { get; set; } = null;

        public virtual Venda Venda { get; set; } = null;

        public virtual ICollection<Venda_Produto_Variacao> Venda_Produto_Variacoes { get; set; }

        public DateTime? CriadoEm { get; set; }

        public string CriadoPor { get; set; } = null;

        public DateTime? DeletadoEm { get; set; }

        public string DeletadoPor { get; set; } = null;

        public DateTime? AtualizadoEm { get; set; }

        public string AtualizadoPor { get; set; } = null;

        public bool? Deletado { get; set; }
    }
}