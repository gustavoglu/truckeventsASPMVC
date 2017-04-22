using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class FichaViewModel
    {

        public FichaViewModel()
        {
            this.Id = Guid.NewGuid();
            this.Ficha_Produtos = new List<Ficha_Produto>();
        }
        public Guid? Id { get; set; }

        public string Codigo { get; set; } = null;

        public string NomeCliente { get; set; } = null;

        public int? Senha { get; set; }

        public double? Saldo { get; set; }

        public Guid? Id_Evento { get; set; }

        public virtual Evento Evento { get; set; } = null;

        public virtual ICollection<Ficha_Produto> Ficha_Produtos{ get; set; }

        public DateTime? CriadoEm { get; set; }

        public string CriadoPor { get; set; } = null;

        public DateTime? DeletadoEm { get; set; }

        public string DeletadoPor { get; set; } = null;

        public DateTime? AtualizadoEm { get; set; }

        public string AtualizadoPor { get; set; } = null;

        public bool? Deletado { get; set; }
    }
}