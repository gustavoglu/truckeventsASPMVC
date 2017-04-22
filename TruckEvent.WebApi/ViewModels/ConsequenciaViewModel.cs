using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class ConsequenciaViewModel
    {
        public ConsequenciaViewModel()
        {
            this.Id = Guid.NewGuid();

            this.Produto_Variacoes = new List<Produto_Variacao>();

        }

        public Guid? Id { get; set; }

        public string Descricao { get; set; } = null;

        public virtual ICollection<Produto_Variacao> Produto_Variacoes { get; set; }

        public DateTime? CriadoEm { get; set; }

        public string CriadoPor { get; set; } = null;

        public DateTime? DeletadoEm { get; set; }

        public string DeletadoPor { get; set; } = null;

        public DateTime? AtualizadoEm { get; set; }

        public string AtualizadoPor { get; set; } = null;

        public bool? Deletado { get; set; }
    }
}