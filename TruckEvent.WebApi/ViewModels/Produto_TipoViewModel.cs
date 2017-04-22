using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class Produto_TipoViewModel
    {
        public Produto_TipoViewModel()
        {
            Id = Guid.NewGuid();

            Produtos = new List<Produto>();
        }
        [Key]
        public Guid? Id { get; set; }

        public string Descricao { get; set; } = null;

        public virtual ICollection<Produto> Produtos { get; set; }

        public DateTime? CriadoEm { get; set; }

        public string CriadoPor { get; set; } = null;

        public DateTime? DeletadoEm { get; set; }

        public string DeletadoPor { get; set; } = null;

        public DateTime? AtualizadoEm { get; set; }

        public string AtualizadoPor { get; set; } = null;

        public bool? Deletado { get; set; }
    }
}