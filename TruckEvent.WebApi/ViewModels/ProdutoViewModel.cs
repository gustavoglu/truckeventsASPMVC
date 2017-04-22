using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            Id = Guid.NewGuid();

            Venda_Produtos = new List<Venda_Produto>();
            Ficha_Produtos = new List<Ficha_Produto>();
        }
        [Key]
        public Guid? Id { get; set; }

        public string Descricao { get; set; } = null;
        public double? Valor { get; set; }
        public int? Numero { get; set; }

        public Guid? Id_produto_cor { get; set; }
        public Guid? Id_produto_tipo { get; set; }

        //public Produto_CorViewModel Produto_Cor { get; set; } = null;
        //public Produto_TipoViewModel Produto_Tipo { get; set; } = null;

        public Produto_Cor Produto_Cor { get; set; } = null;
        public Produto_Tipo Produto_Tipo { get; set; } = null;

        public virtual ICollection<Venda_Produto> Venda_Produtos { get; set; }

        public virtual ICollection<Ficha_Produto> Ficha_Produtos { get; set; }

        public DateTime? CriadoEm { get; set; }

        public string CriadoPor { get; set; } = null;

        public DateTime? DeletadoEm { get; set; }

        public string DeletadoPor { get; set; } = null;

        public DateTime? AtualizadoEm { get; set; }

        public string AtualizadoPor { get; set; } = null;

        public bool? Deletado { get; set; }

    }
}